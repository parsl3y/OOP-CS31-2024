using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;

namespace DigitalWallet
{
    public class DigitalWallet : IDigitalWallet
    {
        private const int SaltSize = 16;
        private string _salt;
        private decimal _balance;
        private string _login;
        private string _hashedPassword;
        private List<string> _transactionLog = new List<string>();
        private ILoginProvider _authProvider;
        private bool _isAuthenticated = false;
        private static Dictionary<string, DigitalWallet> wallets = new Dictionary<string, DigitalWallet>();

        private DigitalWallet(string login, string password, ILoginProvider authProvider)
        {
            _login = login;
            _salt = GenerateSalt();
            _hashedPassword = HashPassword(password, _salt);
            _balance = 0;
            _authProvider = authProvider;
        }

        public static bool RegWallet(string login, string password, ILoginProvider authProvider)
        {
            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Password cannot be empty.");
                return false;
            }

            if (wallets.ContainsKey(login))
            {
                Console.WriteLine("A wallet with this login already exists.");
                return false;
            }
            else
            {
                wallets[login] = new DigitalWallet(login, password, authProvider);
                Console.WriteLine("Wallet registered successfully.");
                return true;
            }
        }

        public static DigitalWallet GetWallet(string login)
        {
            wallets.TryGetValue(login, out var wallet);
            return wallet;
        }

        public bool Deposit(decimal amount)
        {
            if (!_isAuthenticated)
            {
                Console.WriteLine("You must be authenticated to perform this operation.");
                return false;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Deposit amount must be greater than zero.");
                return false;
            }

            _balance += amount;
            string logEntry = $"{DateTime.UtcNow}: Deposited {amount:C}";
            _transactionLog.Add(logEntry);
            return true; 
        }

        public bool Withdraw(decimal amount)
        {
            if (!_isAuthenticated)
            {
                Console.WriteLine("You must be authenticated to perform this operation.");
                return false;
            }

            if (amount <= 0)
            {
                Console.WriteLine("Withdrawal amount must be greater than zero.");
                return false;
            }

            if (_balance >= amount)
            {
                _balance -= amount;
                string logEntry = $"{DateTime.UtcNow}: Withdrawn {amount:C}";
                _transactionLog.Add(logEntry);
                return true; 
            }
       
                return false;
            
        }

        public void ShowBalance()
        {
            Console.WriteLine($"Balance: {_balance:C}");
        }

        public void ShowTransactionLog()
        {
            Console.WriteLine("Transaction Log:");
            foreach (var entry in _transactionLog)
            {
                Console.WriteLine(entry);
            }
        }

        public bool Authenticate(string login, string password)
        {
            if (_authProvider.Validate(login, password))
            {
                _isAuthenticated = true;
                Console.WriteLine("Authenticated successfully.");
                return true; 
            }
            else
            {
                Console.WriteLine("Invalid credentials.");
                return false; 
            }
        }

        public bool Logout()
        {
            if (_isAuthenticated)
            {
                _isAuthenticated = false;
                Console.WriteLine("Logged out successfully.");
                return true; 
            }
            else
            {
                Console.WriteLine("You are not logged in.");
                return false; 
            }
        }

        public static void ShowAllWallets()
        {
            Console.WriteLine("Registered Wallets:");
            foreach (var wallet in wallets.Values)
            {
                Console.WriteLine($"Login: {wallet._login}, PasswordHash: {wallet._hashedPassword}");
            }
        }

        private string HashPassword(string password, string salt)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                string saltedPassword = password + salt;
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(saltedPassword));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private string GenerateSalt()
        {
            var rng = new RNGCryptoServiceProvider();
            byte[] saltBytes = new byte[SaltSize];
            rng.GetBytes(saltBytes);
            return Convert.ToBase64String(saltBytes);
        }
    }
}
