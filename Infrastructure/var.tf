variable "REGION" {
  type    = string
  default = "eu-west-1"
}

variable "ZONE1" {
  default = "eu-west-1a"
}

variable "ZONE2" {
  default = "eu-west-1b"
}

variable "VPC_NAME" {
  default = "docgen_vpc"
}

variable "VPC_CIDR" {
  default = "10.0.0.0/16"
}

variable "PUB_SUB1_CIDR" {
  default = "10.0.1.0/24"
}

variable "PUB_SUB2_CIDR" {
  default = "10.0.2.0/24"
}