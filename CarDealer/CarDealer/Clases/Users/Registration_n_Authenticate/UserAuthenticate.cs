using CarDealer.Interfaces;
using CarDealer.Validate;

namespace CarDealer.Users.Registration_n_Authenticate
{
    public class UserAuthenticate : IUserAuthenticate
    {
        private readonly IValidateAuth _authProvider;
        private Dictionary<string, string> _users;
        private bool _isAuthenticated = false;
        public bool IsAuthenticated() => _isAuthenticated; 
   
        public UserAuthenticate(IValidateAuth authProvider, Dictionary<string, string> users) 
        {
            _authProvider = authProvider;
            _users = users;
        }

 

        public bool Authenticate(string username, string password)
        {
            if (_authProvider.ValidateUser(username, password))
            {
                _isAuthenticated = true;
                Console.WriteLine("User is authenticated.");
                return true;
            }

            Console.WriteLine("User is not authenticated.");
            return false;
        }

        public bool Register(string username, string password)
        {
            if (_users.ContainsKey(username))
            {
                Console.WriteLine("Username already exists.");
                return false;
            }

            _users.Add(username, password);
            Console.WriteLine("User registered successfully.");
            return true;
        }
        
    }
}