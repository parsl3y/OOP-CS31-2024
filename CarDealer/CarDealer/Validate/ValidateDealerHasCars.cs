using CarDealer.CarDealer;
using CarDealer.Interfaces;

namespace CarDealer.Validate;

public class ValidateDealerHasCars
{
    private readonly ConsoleCollor _consoleCollor;

    public ValidateDealerHasCars(ConsoleCollor consoleCollor)
    {
        _consoleCollor = consoleCollor;
    }

    public bool Validate(ICarDealer sellingDealer, List<Cars> availableCars)
    {
        if (availableCars.Count == 0)
        {
            _consoleCollor.ShowInvalidChoiceMessage($"{sellingDealer.Name} does not have any cars available for purchase.");
            return false;
        }
        return true;
    }
}