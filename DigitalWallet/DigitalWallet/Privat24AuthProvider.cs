using System;
using System.Text.RegularExpressions;

namespace DigitalWallet
{
    public class Privat24AuthProvider : ILoginProvider
    {
        private readonly string _phoneNumber; // можна get просто для доступу лише читання
        private readonly string _password;

        public Privat24AuthProvider(string phoneNumber, string password)
        {
            _phoneNumber = phoneNumber;
            _password = password;
            
            if (!IsValidPhoneNumber(phoneNumber))
            {
                throw new UnauthorizedAccessException("Invalid phone number. Must be 10 digits.");
            }
        }
        public bool Validate(string login, string password)
        {
            return _phoneNumber == login && _password == password;
        }
        static bool IsValidPhoneNumber(string phoneNumber)
        {
            return Regex.IsMatch(phoneNumber, @"^\d{10}$");
        }
    }
}