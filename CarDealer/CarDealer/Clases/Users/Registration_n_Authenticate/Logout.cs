using CarDealer.Interfaces;

namespace CarDealer.Users.Registration_n_Authenticate;

public class Logout : IUserLogout
{
    public bool _isAuthenticated = true;
    
    public bool LogoutUser()
    {
        if (_isAuthenticated)
        {
            _isAuthenticated = false;
            Console.WriteLine("User logged out.");
            return true;
        }
        /*throw new Exception("User logged out.");*/
        Console.WriteLine("User logged out.");
        return false;
    }
}