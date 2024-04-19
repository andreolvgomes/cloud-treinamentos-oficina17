provider "aws" {
  region = "ap-southeast-2"
}

#S3 para o tfstate
resource "aws_s3_bucket" "tf_state" {
  bucket = "s3-terraform-state-oficina-17"
  force_destroy = true  
  tags = {
    Name        = "tf_state"
    terrform    = "true"
    owner       = "grupo-2"
    project     = "workshop_17"    
  }
}

resource "aws_s3_bucket_versioning" "test_s3_bucket_versioning" {
  bucket = aws_s3_bucket.tf_state.id
  versioning_configuration {
    status = "Enabled"
  }
}

#nomear tudo para terraform_state_workshop_16
resource "aws_s3_bucket_public_access_block" "public_access" {
  bucket                  = aws_s3_bucket.tf_state.id
  block_public_acls       = true
  block_public_policy     = true
  ignore_public_acls      = true
  restrict_public_buckets = true
}

#:TODO
#criar s3 e lock dynamo db para tf state