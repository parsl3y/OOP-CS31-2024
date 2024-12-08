using System;
using System.Collections.Generic;
using System.Linq;
using CarDealer.CarDealer;
using CarDealer.Interfaces;
using CarDealer.Interfaces.InventoryInterface;

namespace CarDealer.Inventory
{
    public class CarCarInventory : ICarInventory 
    {
        private List<Cars> _cars = new List<Cars>();

        public List<Cars> GetCars()
        {
            return new List<Cars>(_cars);
        }
            
        public bool AddCar(Cars car)
        {
            if (car.IsValid(out string validationMessage))
            {
                _cars.Add(car);
                Console.WriteLine("Car added to the inventory.");
                return true;
            }
                Console.WriteLine(validationMessage);
                return false;
        }


        public bool RemoveCar(Cars car)
        {
            if (car == null)
            {
                Console.WriteLine("Car model wasn't found.");
                return false;
            }
            _cars.Remove(car);
            Console.WriteLine("Car removed from inventory.");
            return true;
        }
        
        public bool ContainsCar(Cars car)
        {
            return _cars.Contains(car);
        }
   
        public void AddCarToInventoryOption(ICarDealer dealer)
        {
            Console.WriteLine("----- Add a car to inventory -----");
            Console.Write("Enter the car model: ");
            string model = Console.ReadLine();

            Console.Write("Enter the car price: ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Enter the car year: ");
            int year = int.Parse(Console.ReadLine());

            Console.Write("Enter the car mileage: ");
            int mileage = int.Parse(Console.ReadLine());

            Cars newCar = new Cars
            {
                Model = model,
                Price = price,
                Year = year,
                Mileage = mileage
            };

            if (AddCar(newCar))
            {
                Console.WriteLine("Car successfully added to inventory.");
            }
            else
            {
                Console.WriteLine("Failed to add the car to inventory.");
            }
        }
        public bool GetAvailableCarsWithMarkup() //не виношу до машин
        {
            var carsWithMarkup = GetCars().GetCarsWithMarkup(); 

            if (carsWithMarkup.Any())
            {
                Console.WriteLine("Available cars with markup:");
                foreach (var car in carsWithMarkup)
                {
                    Console.WriteLine($"{car.Model} - {car.Price:C} - Year: {car.Year} - Mileage: {car.Mileage} km");
                }
                return true;
            }
            Console.WriteLine("No cars available.");
            return false;
        }

        public void RemoveCarOption(ICarDealer dealer)
        {
            Console.WriteLine("----- Remove a car from inventory -----");
            Console.Write("Enter the car model to remove: ");
            string modelToRemove = Console.ReadLine();

            var carToRemove = _cars.FirstOrDefault(car => car.Model.Equals(modelToRemove, StringComparison.OrdinalIgnoreCase));

            if (carToRemove != null)
            {
                RemoveCar(carToRemove);
                Console.WriteLine("Car successfully removed from inventory.");
            }
            else
            {
                Console.WriteLine("Car not found.");
            }
        }
    }
}
