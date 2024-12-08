using System.Drawing;
using System.Linq.Expressions;
using CarDealer.Interfaces;
using CarDealer.Interfaces.CurrentAccountIntefrace;
using CarDealer.Interfaces.InventoryInterface;
using CarDealer.Validate;

namespace CarDealer.CarDealer;

public class CarDealer : ICarDealer
{
    private readonly ICarInventory _carInventory;
    private readonly ICurrentAccount _currentAccount;
    private readonly ConsoleCollor _consoleCollor;
    private readonly GetValidCarChoice _carChoiceGetter;
    private readonly ValidateDealerHasCars _validateDealer;
    private readonly GetValidDealerChoices _getValidDealerChoice;
    public string Name { get; }
    public ICurrentAccount CurrentAccount => _currentAccount;
    public ICarInventory CarInventory => _carInventory;

    public CarDealer(string name, ICarInventory carInventory, ICurrentAccount currentAccount)
    {
        Name = name;
        _carInventory = carInventory;
        _currentAccount = currentAccount;
        _consoleCollor = new ConsoleCollor();
        _carChoiceGetter = new GetValidCarChoice(_consoleCollor); 
        _validateDealer = new ValidateDealerHasCars(_consoleCollor);
        _getValidDealerChoice = new GetValidDealerChoices(); 
    }

    public IEnumerable<Cars> GetAvailableCars()
    {
        return _carInventory.GetCars();
    }

    public void SearchCarAcrossDealers(List<ICarDealer> carDealers, string model)
    {
        Console.WriteLine($"Searching for car model: {model}");

        bool carFound = false;

        foreach (var dealer in carDealers)
        {
            var availableCars = dealer.GetAvailableCars();

            var foundCar =
                availableCars.FirstOrDefault(car => car.Model.Equals(model, StringComparison.OrdinalIgnoreCase));

            if (foundCar != null)
            {
                Console.WriteLine(
                    $"Found {foundCar.Model} at {dealer.Name}. Price: {foundCar.Price:C}, Year: {foundCar.Year}, Mileage: {foundCar.Mileage}");
                carFound = true;
            }
        }

        if (!carFound)
        {
            _consoleCollor.ShowInvalidChoiceMessage($"No dealers found with the car model: {model}");
        }
    }


    public void AddCarsToInventory(Cars car)
    {
        _carInventory.AddCar(car);
    }

    public void ExchangeCars(ICarDealer dealerA, ICarDealer dealerB, Cars carFromA, Cars carFromB) // повернення
    {
        decimal priceDifference = Math.Abs(carFromA.Price - carFromB.Price);

        if (carFromA.Price > carFromB.Price)
        {
            if (!TryMakePayment(dealerB, dealerA, priceDifference))
                return;
        }
        else if (carFromB.Price > carFromA.Price)
        {
            if (!TryMakePayment(dealerA, dealerB, priceDifference))
                return;
        }

        dealerA.CarInventory.RemoveCar(carFromA);
        dealerB.CarInventory.RemoveCar(carFromB);

        dealerA.CarInventory.AddCar(carFromB);
        dealerB.CarInventory.AddCar(carFromA);
    }

    private bool TryMakePayment(ICarDealer payer, ICarDealer receiver, decimal amount)
    {
        if (payer.CurrentAccount.ShowBalance() < amount)
        {
            _consoleCollor.ShowInvalidChoiceMessage($"{payer.Name} does not have enough funds to pay the difference of {amount:C}.");
            return false;
        }

        payer.CurrentAccount.Withdraw(amount);
        receiver.CurrentAccount.Deposit(amount);
        Console.WriteLine($"{payer.Name} paid the difference of {amount:C} for the exchange.");
        return true;
    }

    public void BuyCar(Cars car)
    {
        _carInventory.AddCar(car);
        _currentAccount.Withdraw(car.Price);
        Console.WriteLine($"Car {car.Model} bought for {car.Price:C}");
    }

    public void SellCar(Cars car)
    {
        _carInventory.RemoveCar(car);
        _currentAccount.Deposit(car.Price);
        Console.WriteLine($"Car {car.Model} sold for {car.Price:C}");
    }

    public bool PurchaseCarFromDealer(ICarDealer sellingDealer, Cars car)
    {
        if (sellingDealer.CarInventory.ContainsCar(car))
        {
            decimal price = car.Price;

            if (_currentAccount.ShowBalance() < price)
            {
                _consoleCollor.ShowInvalidChoiceMessage($"{Name} does not have enough funds to buy {car.Model} for {price:C}.");
         
                return false;
            }

            _currentAccount.Withdraw(price);
            sellingDealer.SellCar(car);
            AddCarsToInventory(car);
            _consoleCollor.ShowSuccesChoiceMessage($"{Name} purchased {car.Model} from {sellingDealer.Name} for {price:C}.");
      
        }

        return true;
    }
    
    public bool BuyCarFromAnotherDealer(List<ICarDealer> carDealers)
    {
        ICarDealer? selectedDealer = SelectDealerToPurchaseFrom(carDealers);
        if (selectedDealer == null) return false;  

        var availableCars = selectedDealer.GetAvailableCars().ToList();
        if (!_validateDealer.Validate(selectedDealer, availableCars)) return false; 

        Cars? selectedCar = SelectCarToPurchase(availableCars);
        if (selectedCar != null && PurchaseCarFromDealer(selectedDealer, selectedCar))
        {
            _consoleCollor.ShowSuccesChoiceMessage($"Successfully purchased {selectedCar.Model} from {selectedDealer.Name}.");
            Console.ResetColor();
            return true; 
        }

        return false;  
    }


    public ICarDealer? SelectDealerToPurchaseFrom(List<ICarDealer> carDealers)
    {
        Console.WriteLine("Select another dealer to purchase a car from:");
        foreach (var dealer in carDealers.Where(d => d != this))
        {
            Console.WriteLine($"{carDealers.IndexOf(dealer) + 1}. {dealer.Name}");
        }

        return _getValidDealerChoice.GetValidDealerChoice(_consoleCollor,carDealers);
    }



public Cars? SelectCarToPurchase(List<Cars> availableCars)
{
    Console.WriteLine("Select a car to purchase:");
    for (int i = 0; i < availableCars.Count; i++)
    {
        Console.WriteLine($"{i + 1}. {availableCars[i].Model} - Price: {availableCars[i].Price:C}");
    }

    return _carChoiceGetter.SelectCar(availableCars);
}






}





    

