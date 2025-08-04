namespace StressAndLoadTestAPI.Services;

public class TaskServiceSingleton : BaseService
{
    public TaskServiceSingleton()
    {
        Console.WriteLine($"Singleton instanciado. ID: {this.GetHashCode()}");
    }
}
