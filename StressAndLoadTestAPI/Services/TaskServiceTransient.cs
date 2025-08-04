namespace StressAndLoadTestAPI.Services;

public class TaskServiceTransient : BaseService
{
    public TaskServiceTransient()
    {
        Console.WriteLine($"Transient instanciado. ID: {this.GetHashCode()}");
    }
}
