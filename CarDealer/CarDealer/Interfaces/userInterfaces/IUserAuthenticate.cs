namespace CarDealer.Interfaces;

public interface IUserAuthenticate 
{
    bool Authenticate(string username, string password);
    bool IsAuthenticated();
}