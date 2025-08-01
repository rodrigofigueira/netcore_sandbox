namespace StressAndLoadTestAPI.Services;

public class TaskServiceSingleton
{
    private readonly Stopwatch _stopwatch = Stopwatch.StartNew();
    private readonly Random _random = new();

    public TaskServiceSingleton()
    {
        Console.WriteLine($"Singleton instanciado. ID: {this.GetHashCode()}");
    }

    public async Task SimulateWorkAsync()
    {
        int delay = _random.Next(50, 201);
        await Task.Delay(delay);
    }

    public long GetLifetime() => _stopwatch.ElapsedMilliseconds;
}
