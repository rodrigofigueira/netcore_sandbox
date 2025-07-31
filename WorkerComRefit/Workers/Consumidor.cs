namespace WorkerComRefit.Workers;

public class Consumidor(ILogger<Consumidor> logger, IJokes jokes, IConfiguration configuration) : BackgroundService
{
    private readonly int TEMPO_CONSUMO = int.Parse(configuration["Tempo:Consumo"]!);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var joke = jokes.GetNextJoke();

            if (joke is not null)
            {
                logger.LogInformation("Piada retornada {piada}", joke.Value);
            }

            logger.LogInformation("Total atual pós consumo {total}", jokes.Count());

            await Task.Delay(TEMPO_CONSUMO, stoppingToken);
        }
    }
}
