using CarDealer.Validate;

public class AuthProvider : IValidateAuth
{
    private readonly Dictionary<string, string> _users;

    public AuthProvider(Dictionary<string, string> users)
    {
        _users = users;
    }

    public bool ValidateUser(string username, string password)
    {
        return _users.ContainsKey(username) && _users[username] == password;
    }
}