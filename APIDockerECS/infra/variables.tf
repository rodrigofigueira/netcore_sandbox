variable "aws_region" {
  description = "The AWS region to create resources in."
  type        = string
  default     = "us-east-1"
}

variable "ecr_repo_name" {
  description = "The name for the ECR repository."
  type        = string
  default     = "apidockerecs-repo"
}

variable "ecs_cluster_name" {
  description = "The name for the ECS cluster."
  type        = string
  default     = "api-test-cluster"
}

variable "ecs_task_name" {
  description = "The name for the ECS task and related resources."
  type        = string
  default     = "api-test-task"
}

variable "ecs_service_name" {
  description = "The name for the ECS service."
  type        = string
  default     = "api-test-service"
}

variable "image_tag" {
  description = "The Docker image tag to deploy."
  type        = string
  default     = "latest"
}

variable "container_port" {
  description = "The port the container exposes."
  type        = number
  default     = 8080
}

variable "task_cpu" {
  description = "The amount of CPU units to allocate for the task."
  type        = number
  default     = 256 # 0.25 vCPU
}

variable "task_memory" {
  description = "The amount of memory (in MiB) to allocate for the task."
  type        = number
  default     = 512 # 0.5 GB
}