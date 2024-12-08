using CarDealer.CarDealer;

namespace CarDealer.Validate;

public class GetValidCarChoice
{
    private readonly ConsoleCollor _consoleCollor;

    public GetValidCarChoice(ConsoleCollor consoleCollor) 
    {
        _consoleCollor = consoleCollor;
    }

    public Cars? SelectCar(List<Cars> availableCars) 
    {
        Console.Write("Select the car: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && 
            choice > 0 && 
            choice <= availableCars.Count)
        {
            return availableCars[choice - 1];
        }

        _consoleCollor.ShowInvalidChoiceMessage("car");
        return null;
    }
}