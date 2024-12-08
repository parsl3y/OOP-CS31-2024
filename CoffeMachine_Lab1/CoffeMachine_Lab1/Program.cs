namespace CoffeMachine_Lab1;
using CoffeeMachine_Lab1;
class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CoffeeMachine machine = new CoffeeMachine(50, 200); 

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("-----MENU-----");
            Console.WriteLine("Espresso");
            Console.WriteLine("Latte");
            Console.WriteLine("Display. Coffe Machine Content");
            Console.WriteLine("Q. Exit");
            Console.Write("Choise:");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "Espresso":
                    machine.MakeEspresso();
                    break;
                case "Latte":
                    machine.MakeLatte();
                    break;
                case "Display":
                    machine.DisplayStatus();
                    break;
                case "Q":
                    exit = true;
                    break;
                default:
                    Console.WriteLine("System Error try othe choice");
                    break;
            }

            Console.WriteLine();
        }
    }
}