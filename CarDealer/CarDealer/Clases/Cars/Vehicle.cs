namespace CarDealer;

public class Vehicle
{
    public string Model { get; set; }
    public decimal Price { get; set; }


    public Vehicle()
    {
    }

    public Vehicle(string model, decimal price)
    {
        Model = model;
        Price = price;
    }
}