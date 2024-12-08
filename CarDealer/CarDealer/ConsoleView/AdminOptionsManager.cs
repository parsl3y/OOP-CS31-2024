using CarDealer.ConsoleView;
using CarDealer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using CarDealer.CarDealer;
using CarDealer.Validate;

public static class AdminOptionsManager
{
    private static  ConsoleCollor _consoleCollor;

    public static void ManageAdminOptions(ICarDealer selectedDealer, List<ICarDealer> carDealers)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        bool managingAdmin = true;
        while (managingAdmin)
        {
            Console.WriteLine("----- Admin Menu -----");
            Console.WriteLine("V. View Cars");
            Console.WriteLine("ADD. Add Car");
            Console.WriteLine("REMOVE. Remove Car");
            Console.WriteLine("WALLET. Manage Account (View/Deposit)");
            Console.WriteLine("EXCHANGE. Exchange Cars");
            Console.WriteLine("BUY. Buy Car from Another Dealer");
            Console.WriteLine("BACK. Return to Account Menu");
            Console.Write("Select an option: ");
            string adminChoice = Console.ReadLine()?.ToUpper();
            _consoleCollor = new ConsoleCollor();
            switch (adminChoice)
            {
                case "V":
                    Console.WriteLine("----- Available Cars -----");
                    foreach (var car in selectedDealer.CarInventory.GetCars())
                    {
                        Console.WriteLine($"{car.Model} - {car.Price:C} - Year: {car.Year} - Mileage: {car.Mileage} km");
                    }
                    break;

                case "ADD":
                    selectedDealer.CarInventory.AddCarToInventoryOption(selectedDealer);
                    _consoleCollor.ShowSuccesChoiceMessage("Car successfully added.");
                    break;

                case "REMOVE":
                    selectedDealer.CarInventory.RemoveCarOption(selectedDealer);
                    _consoleCollor.ShowSuccesChoiceMessage("Car successfully removed.");
                    break;

                case "WALLET":
                    ManageAccountBalanceOptions.ManageAccountBalance(selectedDealer);
                    break;

                case "EXCHANGE":
                    ExchangeCars(selectedDealer, carDealers);
                    break;

                case "BUY":
                    selectedDealer.BuyCarFromAnotherDealer(carDealers);
                    break;

                case "BACK":
                    managingAdmin = false;
                    break;

                default:
                    _consoleCollor.ShowInvalidChoiceMessage("Invalid option. Please try again.");
                    break;
            }
        }
    }
    private static void ExchangeCars(ICarDealer selectedDealer, List<ICarDealer> carDealers)
    {
        Console.WriteLine("----- Exchange Cars -----");
        Console.WriteLine("Select another dealer for the exchange:");

        var otherDealers = carDealers.Where(dealer => dealer != selectedDealer).ToList();
        for (int i = 0; i < otherDealers.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {otherDealers[i].Name}");
        }

        Console.Write("Select a dealer: ");
        if (int.TryParse(Console.ReadLine(), out int otherDealerChoice) && 
            otherDealerChoice >= 1 && otherDealerChoice <= otherDealers.Count)
        {
            var otherDealer = otherDealers[otherDealerChoice - 1];

            var myCar = SelectCar(selectedDealer, "your");
            if (myCar != null)
            {
                var theirCar = SelectCar(otherDealer, "the other dealer's");
                if (theirCar != null)
                {
                    selectedDealer.ExchangeCars(selectedDealer, otherDealer, myCar, theirCar);
                    _consoleCollor.ShowSuccesChoiceMessage("Cars exchanged successfully.");
                }
            }
        }
        else
        {
            _consoleCollor.ShowInvalidChoiceMessage("Invalid choice of another dealer.");
        }
    }
    private static Cars SelectCar(ICarDealer dealer, string owner)
    {
        Console.WriteLine($"Select a car from {owner}:");
        var availableCars = dealer.GetAvailableCars().ToList();
        for (int i = 0; i < availableCars.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {availableCars[i].Model}");
        }

        Console.Write("Select a car: ");
        if (int.TryParse(Console.ReadLine(), out int carChoice) && 
            carChoice >= 1 && carChoice <= availableCars.Count)
        {
            return availableCars[carChoice - 1];
        }
        else
        {
            _consoleCollor.ShowInvalidChoiceMessage($"Invalid choice of {owner} car.");
            return null;
        }
    }
}
