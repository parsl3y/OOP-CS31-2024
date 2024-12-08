using System.Net;
using CarDealer.Interfaces;
using CarDealer.Users;
namespace CarDealer.Users.Registration_n_Authenticate;

public class UserRegistation : IUserRegestration
{
    private static Dictionary<string, Users> users = new Dictionary<string, Users>();

    public bool RegisterUser(string username, string password)
    {
        if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
        {
            /*throw new ArgumentException("Username and password are required");*/
            Console.WriteLine("Username and password are required");
            return false;
        }
        
        if(users.ContainsKey(username))
        {
            /*throw new ArgumentException ("Username already exists");*/
            Console.WriteLine("Username already exists");
            return false;
        }
        
        users[username] = new Users(username, password);
        Console.WriteLine("Username registered successfully");
            return true;
    }
    public Dictionary<string, Users> GetUsers() => users;
}