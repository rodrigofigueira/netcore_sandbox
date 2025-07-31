namespace WorkerComRefit.Data;

public class Jokes : IJokes
{
    private readonly Queue<Joke> jokeList = new();

    public void Add(Joke joke) => jokeList.Enqueue(joke);
    public Joke? GetNextJoke()
    {
        if (jokeList.Count != 0)
        {
            return jokeList.Dequeue();
        }
        return null;
    }

    public int Count() => jokeList.Count;
}
