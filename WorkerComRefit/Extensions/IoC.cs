using WorkerComRefit.Workers;

namespace WorkerComRefit.Extensions;

public static class IoC
{
    public static void Injection(this IServiceCollection service, IConfiguration configuration)
    {
        service.AddHostedService<Produtor>();
        service.AddHostedService<Consumidor>();
        service.AddSingleton<IJokes, Jokes>();

        service.AddRefitClient<IChuckNorrisService>()
               .ConfigureHttpClient(c =>
               {
                   c.BaseAddress = new Uri(configuration["Service:Url"]!);
                   c.Timeout = TimeSpan.FromSeconds(10);
               });
    }

}
