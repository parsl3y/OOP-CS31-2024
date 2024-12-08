using System;
using System.Threading;
using CoffeMachine_Lab1;

namespace CoffeeMachine_Lab1
{
    public class CoffeeMachine : ICoffeeMachine
    {
        private decimal _waterVolume;
        private decimal _coffeeSeedsAmount;
        private bool _isBoil;

        public CoffeeMachine(decimal water, decimal coffeeSeeds)
        {
            _waterVolume = water;
            _coffeeSeedsAmount = coffeeSeeds;
            _isBoil = false;
        }

        private bool HeatWater(decimal volume)
        {
            if (_waterVolume >= volume)
            {
                _waterVolume -= volume;
                _isBoil = true;
                Console.WriteLine("Boiling water...");
                DisplayProgress(50, "Heating water");
                Console.WriteLine("\nWater is boiled!");
                return true; 
            }
            else
            {
                Console.WriteLine("Not enough water available.");
                return false; 
            }
        }

        private bool GrindBeans(int amount)
        {
            if (_coffeeSeedsAmount >= amount)
            {
                _coffeeSeedsAmount -= amount;
                Console.WriteLine($"Grinding beans {amount} for coffee...");
                DisplayProgress(30, "Grinding beans");
                Console.WriteLine("\nGrinding completed!");
                return true; 
            }
            else
            {
                Console.WriteLine("Not enough coffee beans.");
                return false; 
            }
        }

        private void DisplayProgress(int totalSteps, string task)
        {
            for (int i = 0; i <= totalSteps; i++)
            {
                Console.Write($"\r{task}: [{new string('\u2588', i)}{new string('.', totalSteps - i)}] {i * 100 / totalSteps}%");
                Thread.Sleep(50);
            }
        }

        public bool MakeEspresso()
        {
            const decimal EspressoWaterVolume = 30;
            const int requiredBeans = 20;

            if (_coffeeSeedsAmount < requiredBeans)
            {
                Console.WriteLine("Not enough coffee beans.");
                return false; 
            }

            if (_waterVolume < EspressoWaterVolume)
            {
                Console.WriteLine("Not enough water available.");
                return false; 
            }

            Console.WriteLine("Making espresso...");
            bool beansGround = GrindBeans(requiredBeans);
            bool waterBoiled = HeatWater(EspressoWaterVolume);

            if (beansGround && waterBoiled && _isBoil)
            {
                Console.WriteLine("Espresso is ready!");
                _isBoil = false;
                return true; 
            }

            return false; 
        }

        public bool MakeLatte()
        {
            const decimal LatteWaterVolume = 100;
            const int requiredBeans = 20;

            if (_coffeeSeedsAmount < requiredBeans)
            {
                Console.WriteLine("Not enough coffee beans.");
                return false; 
            }

            if (_waterVolume < LatteWaterVolume)
            {
                Console.WriteLine("Not enough water available.");
                return false; 
            }

            Console.WriteLine("Making latte...");
            bool beansGround = GrindBeans(requiredBeans);
            bool waterBoiled = HeatWater(LatteWaterVolume);

            if (beansGround && waterBoiled && _isBoil)
            {
                Console.WriteLine("Latte is ready!");
                _isBoil = false;
                return true; 
            }

            return false; 
        }

    

        public void DisplayStatus()
        {
            Console.WriteLine("----------------------------------------");
            Console.WriteLine($"Water volume: {_waterVolume} ml");
            Console.WriteLine($"Coffee beans amount: {_coffeeSeedsAmount} grams");
            Console.WriteLine($"Water boiled: {(_isBoil ? "Yes" : "No")}");
            Console.WriteLine("----------------------------------------");
        }
    }
}
