namespace DigitalWallet
{
    public interface IDigitalWallet 
    {
        bool Deposit(decimal amount);
        void ShowBalance();
        bool Withdraw(decimal amount);
        void ShowTransactionLog();
        
    }
}