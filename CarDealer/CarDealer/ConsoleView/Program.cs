using CarDealer;
using CarDealer.CurrentAccount;
using CarDealer.Interfaces;
using CarDealer.Inventory;
using CarDealer.Users.Registration_n_Authenticate;
using CarDealer.Validate; // Додано
using System.Collections.Generic;
using System.Linq;
using CarDealer.CarDealer;

class Program
{
    const string AdminSecretCode = "SuperSecret123";
    private static  ConsoleCollor _consoleCollor;
    
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;


        var users = new Dictionary<string, string>();
        var authProvider = new AuthProvider(users);
        var userAuthenticate = new UserAuthenticate(authProvider, users);

        var dealerA = new CarDealer.CarDealer.CarDealer("Dealer A", new CarCarInventory(),
            new CurrentAccount(userAuthenticate, 0));
        dealerA.AddCarsToInventory(new Cars("Toyota Camry", 30000m, 1993, 2000));
        dealerA.AddCarsToInventory(new Cars("Honda Accord", 28000m, 2006, 200));

        var dealerB = new CarDealer.CarDealer.CarDealer("Dealer B", new CarCarInventory(),
            new CurrentAccount(userAuthenticate, 20000));
        dealerB.AddCarsToInventory(new Cars("Ford Fusion", 25000m, 2010, 200));
        dealerB.AddCarsToInventory(new Cars("Chevrolet Malibu", 24000m, 2015, 150));

        var carDealers = new List<ICarDealer> { dealerA, dealerB };
        _consoleCollor = new ConsoleCollor();

        var consoleColor = new ConsoleColor(); 

        while (true)
        {
            Console.WriteLine("----- User Management -----");
            Console.WriteLine("R. Register");
            Console.WriteLine("L. Login");
            Console.WriteLine("Q. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine()?.ToUpper();

            switch (choice)
            {
                case "R":
                    Console.Write("Enter username: ");
                    string regUsername = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string regPassword = Console.ReadLine();
                    userAuthenticate.Register(regUsername, regPassword);
                    _consoleCollor.ShowSuccesChoiceMessage("Registration successful!");
                    break;

                case "L":
                    Console.Write("Enter username: ");
                    string loginUsername = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string loginPassword = Console.ReadLine();
                    if (userAuthenticate.Authenticate(loginUsername, loginPassword))
                    {
                        _consoleCollor.ShowSuccesChoiceMessage("Welcome to your account!"); 

                        bool continueSelectingDealer = true;

                        while (continueSelectingDealer)
                        {
                            Console.WriteLine("----- Choose a Car Dealer -----");
                            foreach (var dealer in carDealers)
                            {
                                Console.WriteLine($"- {dealer.Name}");
                            }

                            Console.Write("Choose a dealer by name: ");
                            string dealerName = Console.ReadLine();

                            var selectedDealer = carDealers.FirstOrDefault(d =>
                                d.Name.Equals(dealerName, StringComparison.OrdinalIgnoreCase));
                            if (selectedDealer != null)
                            {
                                Console.WriteLine($"You selected {selectedDealer.Name}.");

                                bool loggedIn = true;
                                while (loggedIn)
                                {
                                    Console.WriteLine("----- Account Menu ----- " +
                                                      "\nV. View Cars " +
                                                      "\nS. Search Cars Across Dealers" +
                                                      "\nA. Admin Menu" +
                                                      "\nLOUT. Logout" +
                                                      "\nR. Return to dealer selection" +
                                                      "\nQ. Exit" +
                                                      "\nChoose an option:  ");

                                    string accountChoice = Console.ReadLine()?.ToUpper();

                                    switch (accountChoice)
                                    {
                                        case "V":
                                            Console.WriteLine("----- Available Cars -----");
                                            if (!selectedDealer.CarInventory.GetAvailableCarsWithMarkup())
                                            {
                                                _consoleCollor.ShowInvalidChoiceMessage("No cars available with markup."); 
                                            }
                                            break;

                                        case "S":
                                            Console.Write("Enter the car model to search for: ");
                                            string searchModel = Console.ReadLine();
                                            selectedDealer.SearchCarAcrossDealers(carDealers, searchModel);
                                            break;

                                        case "A":
                                            Console.Write("Enter secret code: ");
                                            string secretCode = Console.ReadLine();

                                            if (secretCode == AdminSecretCode)
                                            {
                                                AdminOptionsManager.ManageAdminOptions(selectedDealer, carDealers);
                                            }
                                            else
                                            {
                                                _consoleCollor.ShowInvalidChoiceMessage("Invalid secret code.");
                                            }
                                            break;

                                        case "LOUT":
                                            _consoleCollor.ShowSuccesChoiceMessage("Logging out..."); 
                                            loggedIn = false; 
                                            continueSelectingDealer = false; 
                                            break;
                                        
                                        case "R":
                                            loggedIn = false; 
                                            break;

                                        case "Q":
                                            return;

                                        default:
                                            _consoleCollor.ShowInvalidChoiceMessage("Invalid option. Please try again."); 
                                            break;
                                    }
                                }
                            }
                            else
                            {
                                _consoleCollor.ShowInvalidChoiceMessage("Invalid dealer choice."); 
                            }
                        }
                    }
                    else
                    {
                        _consoleCollor.ShowInvalidChoiceMessage("Authentication failed. Please check your credentials.");
                    }
                    break;

                case "Q":
                    return;

                default:
                    _consoleCollor.ShowInvalidChoiceMessage("Invalid option. Please try again."); 
                    break;
            }
        }
    }
}
