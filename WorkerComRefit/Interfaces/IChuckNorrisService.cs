namespace WorkerComRefit.Interfaces;

public interface IChuckNorrisService
{
    [Get("/jokes/random")]
    Task<Joke> GetJokes();
}