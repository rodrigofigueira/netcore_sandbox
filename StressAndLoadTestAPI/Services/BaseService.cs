namespace StressAndLoadTestAPI.Services;

public class BaseService
{
    public BaseService()
    {
        SimulateWork();
    }

    public void SimulateWork()
    {
        long result = 0;
        for (int i = 0; i < 1_000_000; i++)
        {
            result += i;
        }
    }
}
