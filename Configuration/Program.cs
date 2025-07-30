Console.WriteLine("Demonstrando Chained Configuration");

var configModuloA = new ConfigurationBuilder()
                .AddJsonFile("Assets/ModuloA.json", optional: false, reloadOnChange: true)
                .Build();

configModuloA.PrintConfiguracao("Módulo A");

var configModuloB = new ConfigurationBuilder()
                .AddJsonFile("Assets/ModuloB.json", optional: false, reloadOnChange: true)
                .Build();

configModuloB.PrintConfiguracao("Módulo B");

var configEncadeada = new ConfigurationBuilder()
                .AddConfiguration(configModuloA)
                .AddConfiguration(configModuloB)
                .Build();

configEncadeada.PrintConfiguracao("Módulo Encadeado");

Console.ReadLine();