using CarDealer.Interfaces;
using CarDealer.Interfaces.CurrentAccountIntefrace;
using CarDealer.Validate;

namespace CarDealer.CurrentAccount;

public class CurrentAccount : ICurrentAccount
{
    private readonly IUserAuthenticate _userAuthenticator;
    
    private const decimal minAmountValue = 0m;
    public decimal Balance { get; set; }

    public CurrentAccount(IUserAuthenticate userAuthenticator, decimal balance)
    {
        _userAuthenticator = userAuthenticator;
        Balance = balance;
    }

    public bool Deposit(decimal amount)
    {
        if (!_userAuthenticator.IsAuthenticated())
        {
            Console.WriteLine("Current account is not authenticated");
            return false;
        }

        if (amount <= minAmountValue)
        {
            Console.WriteLine("Deposit amount must be greater than zero.");
            return false;
        }

        Balance += amount;
        Console.WriteLine($"Deposited amount: {amount:C}");
        return true;
    }

    public bool Withdraw(decimal amount)
    {
        if (!_userAuthenticator.IsAuthenticated())
        {
            Console.WriteLine("Current account is not authenticated");
            return false;
        }

        if (amount <= minAmountValue)
        {
            Console.WriteLine("Withdrawal amount must be greater than zero.");
            return false;
        }

        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"Successful withdrawal: {amount:C}");
            return true;
        }

        Console.WriteLine("Withdrawal amount exceeds current balance.");
        return false;
    }
    
    public decimal ShowBalance()
    {
        return Balance;
    }
}