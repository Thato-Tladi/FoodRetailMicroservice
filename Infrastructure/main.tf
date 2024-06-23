# VPC
resource "aws_vpc" "food_retail_vpc" {
  cidr_block           = var.VPC_CIDR
  enable_dns_support   = true
  enable_dns_hostnames = true
}

# Internet gateway
resource "aws_internet_gateway" "gw" {
  vpc_id = aws_vpc.food_retail_vpc.id
}

# Route table
resource "aws_route_table" "route_table" {
  vpc_id = aws_vpc.food_retail_vpc.id

  route {
    cidr_block = "0.0.0.0/0"
    gateway_id = aws_internet_gateway.gw.id
  }
}

# Subnets
resource "aws_subnet" "subnet1" {
  vpc_id            = aws_vpc.food_retail_vpc.id
  cidr_block        = var.PUB_SUB1_CIDR
  availability_zone = var.ZONE1
}

resource "aws_subnet" "subnet2" {
  vpc_id            = aws_vpc.food_retail_vpc.id
  cidr_block        = var.PUB_SUB2_CIDR
  availability_zone = var.ZONE2
}

# Route table associations
resource "aws_route_table_association" "route_table_asso" {
  subnet_id      = aws_subnet.subnet1.id
  route_table_id = aws_route_table.route_table.id
}

resource "aws_route_table_association" "route_table_asso1" {
  subnet_id      = aws_subnet.subnet2.id
  route_table_id = aws_route_table.route_table.id
} 

# Security group for environment
resource "aws_security_group" "food_retail_sg" {
  name        = "food-retail-sg"
  description = "Allow inbound HTTP and HTTPS traffic"
  vpc_id      = aws_vpc.food_retail_vpc.id

  ingress {
    from_port   = 80
    to_port     = 80
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }
  
  ingress {
    from_port   = 443
    to_port     = 443
    protocol    = "tcp"
    cidr_blocks = ["0.0.0.0/0"]
  }

  egress {
    from_port   = 0
    to_port     = 0
    protocol    = "-1"
    cidr_blocks = ["0.0.0.0/0"]
  }
}

# AWS RDS SQL Server instance
resource "aws_db_instance" "food_retail_rds" {
  allocated_storage       = 20
  storage_type            = "gp2"
  engine                  = "sqlserver-ex"
  instance_class          = "db.t3.micro"
  username                = jsondecode(data.aws_secretsmanager_secret_version.creds.secret_string)["username"]
  password                = jsondecode(data.aws_secretsmanager_secret_version.creds.secret_string)["password"]
  skip_final_snapshot     = true
  publicly_accessible     = true
  identifier              = "foodretaildb"
  multi_az                = false
  db_subnet_group_name    = aws_db_subnet_group.sql_subnet_group.name
  vpc_security_group_ids  = [aws_security_group.food_retail_sg.id]
}

# AWS Elastic Beanstalk Application and Environment
resource "aws_elastic_beanstalk_application" "food_retail_app" {
  name        = "food-retail-application"
  description = "Food Retail Microservice built on .NET"
}

resource "aws_elastic_beanstalk_environment" "food_retail_env" {
  name                = "food-retail-env"
  application         = aws_elastic_beanstalk_application.food_retail_app.name
  solution_stack_name = "64bit Amazon Linux 2 v3.3.5 running .NET Core"
  cname_prefix        = "foodretail"

  setting {
    namespace = "aws:ec2:vpc"
    name      = "VPCId"
    value     = aws_vpc.food_retail_vpc.id
  }

  setting {
    namespace = "aws:ec2:vpc"
    name      = "Subnets"
    value     = "${aws_subnet.subnet1.id},${aws_subnet.subnet2.id}"
  }

  setting {
    namespace = "aws:ec2:vpc"
    name      = "ELBSubnets"
    value     = "${aws_subnet.subnet1.id},${aws_subnet.subnet2.id}"
  }

  setting {
    namespace = "aws:elasticbeanstalk:environment"
    name      = "SecurityGroups"
    value     = aws_security_group.food_retail_sg.id
  }

  depends_on = [aws_security_group.food_retail_sg]
}

# S3 bucket for frontend
resource "aws_s3_bucket" "food_retail_frontend" {
  bucket = "food-retail-frontend-${formatdate("YYYYMMDD", timestamp())}"

  tags = {
    Name        = "Food Retail Frontend"
    Environment = "Production"
  }
}

resource "aws_s3_bucket_website_configuration" "food_retail_website_config" {
  bucket = aws_s3_bucket.food_retail_frontend.id

  index_document {
    suffix = "index.html"
  }

  error_document {
    key = "404.html"
  }
}

# Configuring static website hosting on bucket
resource "aws_s3_bucket_public_access_block" "food_retail_access_block" {
  bucket = aws_s3_bucket.food_retail_frontend.id

  block_public_acls   = true
  block_public_policy = true
  ignore_public_acls  = true
  restrict_public_buckets = true
}

output "website_url" {
  description = "The website URL of the S3 bucket"
  value       = "http://${aws_s3_bucket.food_retail_frontend.bucket_regional_domain_name}"
}

