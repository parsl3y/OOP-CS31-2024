using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigitalWallet
{
    public interface IDigitalWallet 
    {
        void Deposit(decimal amount);
        void ShowBalance();
        void Withdraw(decimal amount);
        void ShowTransactionLog();
    }

}
