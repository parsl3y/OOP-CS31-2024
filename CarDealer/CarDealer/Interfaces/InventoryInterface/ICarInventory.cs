using CarDealer.CarDealer;

namespace CarDealer.Interfaces.InventoryInterface
{
    public interface ICarInventory
    {
        bool AddCar(Cars car);
        bool RemoveCar(Cars car);
        List<Cars> GetCars();
        bool GetAvailableCarsWithMarkup();
        void AddCarToInventoryOption(ICarDealer dealer);
        void RemoveCarOption(ICarDealer dealer);
        bool ContainsCar(Cars car); 
    }
}