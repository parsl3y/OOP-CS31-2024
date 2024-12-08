
    public class PaymentAccount
    {
        public virtual void ProcessPayment(decimal amount)
        {
            
        }
    }
    public class PaymentProcessor
    {
        public void Process(PaymentAccount account, decimal amount)
        {
            account.ProcessPayment(amount);
        }
    }

    public class BankAccount : PaymentAccount
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} via BankAccount.");
        }
    }

    public class PayoneerAccount : PaymentAccount
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} via PayoneerAccount.");
        }
    }

    public class WiseAccount : PaymentAccount
    {
        public override void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of {amount} via WiseAccount.");
        }
    }
namespace PaymentProcess
{
    public class Program
    {
        public static void Main(string[] args)
        {
            PaymentProcessor processor = new PaymentProcessor();

            Console.WriteLine("Take a choice:");
            Console.WriteLine("Bank - BankAccount");
            Console.WriteLine("Payoneer - PayoneerAccount");
            Console.WriteLine("Wise - WiseAccount");

            string? accountType = Console.ReadLine();
            PaymentAccount? account = CreateAccount(accountType);

            if (account != null)
            {
                Console.Write("Amount deposit: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());
                processor.Process(account, amount);
            }
            else
            {
                throw new Exception("Account not found");
            }
        }

        public static PaymentAccount CreateAccount(string? accountType)
        {
            return accountType switch
            {
                "Bank" => new BankAccount(),
                "Payoneer" => new PayoneerAccount(),
                "Wise" => new WiseAccount(),
                _ => null
            };
        }
    }
}
