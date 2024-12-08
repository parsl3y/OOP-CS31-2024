using CarDealer.CarDealer;

namespace CarDealer.Interfaces.InventoryInterface;

public static class CarInventoryExtensions
{
    public static List<Cars> GetCarsWithMarkup(this IEnumerable<Cars> cars)
    {
        const decimal markupPercentage = 0.05m;
        return cars.Select(car => new Cars
        {
            Model = car.Model,
            Price = car.Price * (1 + markupPercentage), 
            Year = car.Year,
            Mileage = car.Mileage
        }).ToList();
    }
}