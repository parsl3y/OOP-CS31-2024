namespace CarDealer.Validate;

public interface IValidateAuth
{
    bool ValidateUser(string username, string password);
}