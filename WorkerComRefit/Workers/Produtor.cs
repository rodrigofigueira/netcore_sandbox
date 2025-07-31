namespace WorkerComRefit.Workers;

public class Produtor(ILogger<Produtor> logger
                    , IChuckNorrisService chuckNorrisService
                    , IJokes jokes
                    , IConfiguration configuration) : BackgroundService
{
    private readonly int TEMPO_PRODUCAO = int.Parse(configuration["Tempo:Producao"]!);

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var joke = await chuckNorrisService.GetJokes();
                jokes.Add(joke);
                logger.LogInformation("Piada inserida, total atual {total}", jokes.Count());
            }
            catch (ApiException ex)
            {
                logger.LogError(ex, "Erro ao chamar a API do Chuck Norris: {StatusCode} - {Content}", ex.StatusCode, ex.Content);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ocorreu um erro inesperado.");
            }
            await Task.Delay(TEMPO_PRODUCAO, stoppingToken);
        }
    }
}
