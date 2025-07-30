namespace ChainedConfiguration;

public static class Extension
{
    public static void PrintConfiguracao(this IConfiguration configuration, string titulo)
    {
        Console.WriteLine("");
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine($"{titulo}");
        Console.WriteLine("------------------------------------------------------------");

        foreach (var item in configuration.AsEnumerable().OrderBy(k => k.Key))
        {
            if (item.Value != null)
            {
                var chave = item.Key.Split(":")[0];
                var chaveFormatada = item.Key.Replace($"{chave}:", "");
                Console.WriteLine($"{chaveFormatada}: {item.Value}");
            }
        }
    }
}
