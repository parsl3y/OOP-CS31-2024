using CarDealer.Interfaces;
using CarDealer.Validate;

namespace CarDealer.ConsoleView
{
    public class ManageAccountBalanceOptions
    {
        private static ConsoleCollor _consoleCollor = new ConsoleCollor(); // Додано

        public static void ManageAccountBalance(ICarDealer selectedDealer)
        {
            Console.WriteLine("----- Manage Account -----");
            Console.WriteLine("BALANCE. View Current Balance");
            Console.WriteLine("DEP. Deposit Balance");
            Console.WriteLine("BACK. Go Back");
            Console.Write("Select an option: ");
            string balanceChoice = Console.ReadLine()?.ToUpper();

            switch (balanceChoice)
            {
                case "BALANCE":
                    Console.WriteLine($"Your balance: {selectedDealer.CurrentAccount.ShowBalance():C}");
                    break;

                case "DEP":
                    Console.Write("Enter amount to deposit: ");
                    if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                    {
                        bool success = selectedDealer.CurrentAccount.Deposit(depositAmount);
                        if (success)
                        {
                            _consoleCollor.ShowSuccesChoiceMessage($"Balance successfully deposited by {depositAmount:C}");
                        }
                        else
                        {
                            _consoleCollor.ShowInvalidChoiceMessage("Error depositing balance.");
                        }
                    }
                    else
                    {
                        _consoleCollor.ShowInvalidChoiceMessage("Invalid amount."); 
                    }
                    break;

                case "BACK":
                    break;

                default:
                    _consoleCollor.ShowInvalidChoiceMessage("Invalid option. Please try again."); 
                    break;
            }
        }
    }
}
