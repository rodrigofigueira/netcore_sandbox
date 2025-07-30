

# Netcore Sandbox



Repositório para estudos de .netcore



# 01 -Configurations



Estudo de ConfigurationBuilder com os providers para Json, CommandLine, EnvironmentVariables, UserSecrets, XML e InMemory.



### Pacotes instalados



````

Microsoft.Extensions.Configuration

Microsoft.Extensions.Configuration.CommandLine

Microsoft.Extensions.Configuration.EnvironmentVariables 

Microsoft.Extensions.Configuration.Json

Microsoft.Extensions.Configuration.UserSecrets

Microsoft.Extensions.Configuration.Xml

````



### Os comandos abaixo são necessários para criação dos secrets



````

dotnet user-secrets init



dotnet user-secrets set "MinhaApi:ChaveApi" "sua\_chave\_secreta\_aqui\_123"

dotnet user-secrets set "ConexaoDb:Senha" "MinhaSenhaSuperSecreta"

````



### Todo





