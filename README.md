

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

Outros tópicos para estudar

- [ ] Options Pattern (IOptions<T>, IOptionsSnapshot<T>, IOptionsMonitor<T>): Esta é a forma recomendada de consumir as configurações em sua aplicação, mapeando-as para classes C# fortemente tipadas. Isso traz segurança de tipo e é essencial para configurações que recarregam (reloadOnChange).

- [ ] Provedores de Cofre de Segredos em Nuvem: Se você trabalha com nuvem (Azure, AWS, Google Cloud), investigar provedores como AddAzureKeyVault (para Azure Key Vault) é fundamental para gerenciar segredos em produção de forma segura e escalável.

- [ ] Provedores Personalizados Mais Complexos: Para cenários muito específicos, onde a configuração viria de um banco de dados, um serviço REST, ou um formato de arquivo proprietário, a criação de provedores personalizados mais avançados poderia ser um estudo interessante.




