namespace CarDealer.Interfaces.CurrentAccountIntefrace;

public interface ICurrentAccount
{
    bool Deposit(decimal amount);
    bool Withdraw(decimal amount);
    decimal ShowBalance();
}