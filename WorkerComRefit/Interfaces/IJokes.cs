namespace WorkerComRefit.Interfaces;

public interface IJokes
{
    public int Count();
    public void Add(Joke joke);
    public Joke? GetNextJoke();
}
