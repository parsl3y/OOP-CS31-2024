namespace DigitalWallet
{
    public interface ILoginProvider
{
    bool Validate(string login, string password);
}


}