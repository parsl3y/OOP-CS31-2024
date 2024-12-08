using System.Security.Cryptography;
using System.Text;

namespace DigitalWallet;

public class DigitalWallet : IDigitalWallet
{
    private decimal balance;
    private string login;
    private string hashedPassword;
    private List<string> transactionLog = new List<string>();

    public DigitalWallet(string login, string password)
    {
        balance = 0;
        this.login = login;
        hashedPassword = HashPassword(password);

    }
    private string HashPassword(string password) // SHA256 - алгоритм шифрування 
        // одностороння
    {
        using (SHA256 sha256Hash = SHA256.Create())
        {

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
    public void Deposit(decimal amount)
    {
        balance += amount;
        string logEntry = $"{DateTime.Now}: Додали {amount:C}";
        transactionLog.Add(logEntry);

    }
    public void ShowBalance()
    {
        Console.WriteLine($"Balance: {balance:C}");
    }
    public void Withdraw(decimal amount)
    {
        if (balance >= amount)
        {
            balance -= amount;
            string logEntry = $"{DateTime.Now}: Зняли {amount:C}";
            transactionLog.Add(logEntry);

        }
        else
        {
            Console.WriteLine("Insufficient funds");
        }
    }

    public void ShowTransactionLog()
    {
        Console.WriteLine("Transaction Log:");
        foreach (var entry in transactionLog)
        {
            Console.WriteLine(entry);
        }

    }
}