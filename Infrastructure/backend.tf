terraform {
  backend "s3" {
    bucket  = "food-retail-microservice-state"
    key     = "terraform.tfstate"
    region  = "eu-west-1"
  }
}