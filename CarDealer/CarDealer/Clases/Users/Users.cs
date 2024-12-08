namespace CarDealer.Users
{
    public class Users
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

     
        public Users(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
