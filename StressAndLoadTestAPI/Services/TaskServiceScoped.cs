namespace StressAndLoadTestAPI.Services;

public class TaskServiceScoped : BaseService
{
    public TaskServiceScoped()
    {
        Console.WriteLine($"Scoped instanciado. ID: {this.GetHashCode()}");
    }
}
