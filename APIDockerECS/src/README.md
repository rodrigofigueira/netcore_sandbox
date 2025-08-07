# Api + Docker + ECS

Projeto para API dockerizada no ECS, a princípio terá somente um endpoint para testar a publicação.

Provisionei a infra direto no console mas vou fazer isso por terraform


## Endpoint exposto
```
/weatherforecast
```

## Códigos - ajustar 

```
aws ecr get-login-password --region <sua-regiao> | docker login --username AWS --password-stdin <id-da-sua-conta>.dkr.ecr.<sua-regiao>.amazonaws.com

docker tag apidockerecs:latest <id-da-sua-conta>.dkr.ecr.<sua-regiao>.amazonaws.com/apidockerecs-repo:latest

docker push <id-da-sua-conta>.dkr.ecr.<sua-regiao>.amazonaws.com/apidockerecs-repo:latest
```

### Subir infra por terraform os itens abaixo

- [ ] Security Group com Inbound Rule TCP 0.0.0.0/0
- [ ] Registrar imagem no ECR
- [ ] Marcar imagem localmente
- [ ] Push da imagem
- [ ] Roles
- [ ] Task
- [ ] Cluster
- [ ] Service