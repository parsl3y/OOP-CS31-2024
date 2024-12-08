using System;
using System.Text;

namespace DigitalWallet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            while (true)
            {
                Console.WriteLine("-----Digital Wallet!-----");
                Console.WriteLine("Register - R");
                Console.WriteLine("Login - L");
                Console.WriteLine("Show All Wallets - S");
                Console.WriteLine("Exit - E");
                Console.Write("Select an option: ");

                string choice = Console.ReadLine();

                try
                {
                    switch (choice.ToUpper())
                    {
                        case "R": 
                            Console.WriteLine("Select authentication method:");
                            Console.WriteLine("Gmail (Email) - G");
                            Console.WriteLine("Privat24 (Phone Number) - P");
                            Console.Write("Select an option: ");
                            string providerChoice = Console.ReadLine();

                            ILoginProvider authProvider = null;
                            string login = null;
                            string password = null;

                            switch (providerChoice.ToUpper())
                            {
                                case "G": 
                                    Console.Write("Enter email (must be a valid Gmail address): ");
                                    login = Console.ReadLine();
                                    Console.Write("Enter password: ");
                                    password = ReadPasswordRegistration();
                                    authProvider = new GmailAuthProvider(login, password);
                                    break;

                                case "P": 
                                    Console.Write("Enter phone number (must be 10 digits): ");
                                    login = Console.ReadLine();
                                    Console.Write("Enter password: ");
                                    password = ReadPasswordRegistration();
                                    authProvider = new Privat24AuthProvider(login, password);
                                    break;

                                default:
                                    throw new UnauthorizedAccessException("Invalid provider choice.");
                            }

                            if (authProvider != null)
                            {
                                DigitalWallet.RegWallet(login, password, authProvider);
                                Console.WriteLine("Wallet registered successfully.");
                            }

                            break;

                        case "L": 
                            Console.Write("Enter login: ");
                            string loginForAuth = Console.ReadLine();
                            Console.Write("Enter password: ");
                            string passwordForAuth = ReadPasswordLogin();

                            var wallet = DigitalWallet.GetWallet(loginForAuth);
                            if (wallet == null)
                            {
                                throw new UnauthorizedAccessException("Account not found.");
                            }

                            wallet.Authenticate(loginForAuth, passwordForAuth);
                            Console.WriteLine("Authentication successful!");

                            bool exit = false;
                            while (!exit)
                            {
                                Console.WriteLine("Menu:");
                                Console.WriteLine("Show Balance - B");
                                Console.WriteLine("Deposit - D");
                                Console.WriteLine("Withdraw - W");
                                Console.WriteLine("Show Transaction Log - T");
                                Console.WriteLine("Logout - O");
                                Console.WriteLine("Exit - E");
                                Console.Write("Select an option: ");

                                string innerChoice = Console.ReadLine();

                                switch (innerChoice.ToUpper())
                                {
                                    case "B": 
                                        wallet.ShowBalance();
                                        break;
                                    case "D":
                                        Console.Write("Enter amount to deposit: ");
                                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                                        wallet.Deposit(depositAmount);
                                        Console.WriteLine("Deposit successful.");
                                        break;
                                    case "W": 
                                        Console.Write("Enter amount to withdraw: ");
                                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                                        if (wallet.Withdraw(withdrawAmount))
                                        {
                                            Console.WriteLine("Withdrawal successful.");
                                        }
                                        break;
                                    case "T": 
                                        wallet.ShowTransactionLog();
                                        break;
                                    case "O": 
                                        wallet.Logout();
                                        exit = true;
                                        break;
                                    case "E": 
                                        exit = true;
                                        Console.WriteLine("Goodbye!");
                                        break;
                                    default:
                                        throw new UnauthorizedAccessException("Invalid option. Try again.");
                                }
                            }

                            break;

                        case "S": 
                            Console.Write("Enter the keyword to show all wallets: ");
                            string keyword = Console.ReadLine();
                            if (keyword == "SecretWallet")
                            {
                                DigitalWallet.ShowAllWallets();
                            }
                            else
                            {
                                throw new UnauthorizedAccessException("Invalid keyword. Access denied.");
                            }

                            break;

                        case "E": 
                            return;

                        default:
                            throw new UnauthorizedAccessException("Invalid option. Try again.");
                    }
                }
                catch (UnauthorizedAccessException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static string ReadPasswordRegistration()
        {
            StringBuilder password = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.Remove(password.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password.Append(info.KeyChar);
                    Console.Write("*");
                }
            }

            Console.WriteLine();
            return password.ToString();
        }

        static string ReadPasswordLogin()
        {
            StringBuilder password = new StringBuilder();
            while (true)
            {
                ConsoleKeyInfo info = Console.ReadKey(true);
                if (info.Key == ConsoleKey.Enter)
                {
                    break;
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (password.Length > 0)
                    {
                        password.Remove(password.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else
                {
                    password.Append(info.KeyChar);
                }
            }

            Console.WriteLine();
            return password.ToString();
        }
    }
}
