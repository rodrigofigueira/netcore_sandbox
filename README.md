Para criar o secrets
dotnet user-secrets init

Para adicionar os secrets para teste
dotnet user-secrets set "MinhaApi:ChaveApi" "sua_chave_secreta_aqui_123"
dotnet user-secrets set "ConexaoDb:Senha" "MinhaSenhaSuperSecreta"

todo
[] Melhorar a instruções para configurar o projeto de Configurations