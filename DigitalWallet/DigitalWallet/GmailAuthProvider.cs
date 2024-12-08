using System;
using System.Text.RegularExpressions;

namespace DigitalWallet
{
    public class GmailAuthProvider : ILoginProvider
    {
        private readonly string _email;
        private readonly string _password;

        public GmailAuthProvider(string email, string password)
        {
            _email = email;
            _password = password;
            
            if (!IsValidGmailAddress(email))
            {
                throw new UnauthorizedAccessException("Invalid email address. Must be a valid Gmail address.");
            }
        }

        public bool Validate(string login, string password)
        {
            return login == _email && password == _password;
        }
        static bool IsValidGmailAddress(string email)
        {
            string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    return Regex.IsMatch(email, emailPattern);
        }

    }
}