using ProxyPatrn;

class Program
{
    static void Main()
    {
        Console.WriteLine("User with Role 'User':");
        IDataProvider userProxy = new ProxyDataProvider("User");
        userProxy.GetData();

        Console.WriteLine("\nUser with Role 'Admin':");
        IDataProvider adminProxy = new ProxyDataProvider("Admin");
        adminProxy.GetData();
    }
}