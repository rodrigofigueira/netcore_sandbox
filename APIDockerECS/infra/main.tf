# Define o provedor AWS
provider "aws" {
  region = var.aws_region
}

# --- Data Sources para encontrar a VPC padrão e as subnets ---
data "aws_vpc" "default" {
  default = true
}

data "aws_subnets" "default" {
  filter {
    name   = "vpc-id"
    values = [data.aws_vpc.default.id]
  }
}

# --- Recursos do ECR ---
resource "aws_ecr_repository" "api_repo" {
  name = var.ecr_repo_name

  tags = {
    Name = var.ecr_repo_name
  }
}

# --- Recursos do ECS ---
resource "aws_ecs_cluster" "api_cluster" {
  name = var.ecs_cluster_name
}

resource "aws_iam_role" "ecs_task_execution_role" {
  name = "${var.ecs_task_name}-execution-role"

  assume_role_policy = jsonencode({
    Version = "2012-10-17"
    Statement = [
      {
        Action = "sts:AssumeRole"
        Effect = "Allow"
        Sid    = ""
        Principal = {
          Service = "ecs-tasks.amazonaws.com"
        }
      },
    ]
  })
}

resource "aws_iam_role_policy_attachment" "ecs_task_execution_policy" {
  role       = aws_iam_role.ecs_task_execution_role.name
  policy_arn = "arn:aws:iam::aws:policy/service-role/AmazonECSTaskExecutionRolePolicy"
}

resource "aws_ecs_task_definition" "api_task" {
  family                   = var.ecs_task_name
  requires_compatibilities = ["FARGATE"]
  network_mode             = "awsvpc"
  cpu                      = var.task_cpu
  memory                   = var.task_memory
  execution_role_arn       = aws_iam_role.ecs_task_execution_role.arn

  container_definitions = jsonencode([
    {
      name      = var.ecs_task_name
      image     = "${aws_ecr_repository.api_repo.repository_url}:${var.image_tag}"
      essential = true
      portMappings = [
        {
          containerPort = var.container_port
          hostPort      = var.container_port
        }
      ]
    }
  ])
}

# --- Recursos de Rede e Security Group ---
resource "aws_vpc_security_group_ingress_rule" "allow_http" {
  security_group_id = aws_security_group.api_sg.id
  description       = "Allow HTTP from anywhere"
  cidr_ipv4         = "0.0.0.0/0"
  from_port         = var.container_port
  ip_protocol       = "tcp"
  to_port           = var.container_port
}

resource "aws_security_group" "api_sg" {
  name        = "${var.ecs_task_name}-sg"
  description = "Security group for the API container"
  vpc_id      = data.aws_vpc.default.id

  tags = {
    Name = "${var.ecs_task_name}-sg"
  }
}

# --- Recursos do Serviço ECS ---
resource "aws_ecs_service" "api_service" {
  name            = var.ecs_service_name
  cluster         = aws_ecs_cluster.api_cluster.id
  task_definition = aws_ecs_task_definition.api_task.arn
  desired_count   = 1
  launch_type     = "FARGATE"

  capacity_provider_strategy {
    capacity_provider = "FARGATE_SPOT"
    weight            = 100
  }

  network_configuration {
    security_groups  = [aws_security_group.api_sg.id]
    subnets          = data.aws_subnets.default.ids
    assign_public_ip = true
  }
}

output "ecr_repository_url" {
  description = "The URL of the ECR repository"
  value       = aws_ecr_repository.api_repo.repository_url
}

output "ecs_service_name" {
  description = "The name of the ECS service"
  value       = aws_ecs_service.api_service.name
}  