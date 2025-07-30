Console.WriteLine("Demonstrando Chained Configuration");

var builderJsonA = new ConfigurationBuilder()
                .AddJsonFile("Assets/Modulo.json")
                .Build();

builderJsonA.PrintConfiguracao("Json - Módulo");

var builderJsonB = new ConfigurationBuilder()
                .AddJsonFile("Assets/appsettings.json")
                .Build();

builderJsonB.PrintConfiguracao("Json - appsettings");


var builderInMemory = new ConfigurationBuilder()
                .AddInMemoryCollection(
                [
                    new KeyValuePair<string, string?>("Configuracao:ExclusivaIMemory", "Configuração exclusiva InMemory"),
                    new KeyValuePair<string, string?>("Configuracao:Compartilhada", "Valor Compartilhada InMemory"),
                ])
                .Build();

builderInMemory.PrintConfiguracao("In Memory");


var builderXML = new ConfigurationBuilder()
                 .AddXmlFile("Assets/Config.xml")
                 .Build();

builderXML.PrintConfiguracao("XML");

var builderVarAmbiente = new ConfigurationBuilder()
                            .AddEnvironmentVariables()
                            .Build();

builderVarAmbiente.PrintConfiguracao("Var Ambiente");

var builderCLI = new ConfigurationBuilder()
                     .AddCommandLine(args)
                     .Build();

builderCLI.PrintConfiguracao("CLI");

var configEncadeada = new ConfigurationBuilder()
                .AddConfiguration(builderJsonA)
                .AddConfiguration(builderJsonB)
                .AddConfiguration(builderInMemory)
                .AddConfiguration(builderXML)
                //.AddConfiguration(builderVarAmbiente) // não adicionei pois tem muito volume
                .AddConfiguration(builderCLI)
                .Build();

configEncadeada.PrintConfiguracao("Módulo Encadeado");

Console.ReadLine();