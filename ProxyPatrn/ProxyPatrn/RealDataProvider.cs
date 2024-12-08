namespace ProxyPatrn;

public class RealDataProvider : IDataProvider
{
    public RealDataProvider()
    {
        Console.WriteLine("Initial more Data ...");
    }

    public void GetData()
    {
        Console.WriteLine("Initial Data.");
    }
}