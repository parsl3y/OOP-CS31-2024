namespace ProxyPatrn;

public class ProxyDataProvider : IDataProvider
{
    private RealDataProvider _realDataProvider;
    private readonly string _userRole;

    public ProxyDataProvider(string userRole)
    {
        _userRole = userRole;
    }

    public void GetData()
    {  
        if (_userRole != "Admin")
        {
            Console.WriteLine("Access denied.");
            return;
        }

        if (_realDataProvider == null)
        {
            _realDataProvider = new RealDataProvider();
        }

        _realDataProvider.GetData();
    }
}