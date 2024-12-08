using CarDealer.Interfaces;

namespace CarDealer.Validate;

public class GetValidDealerChoices
{
    public ICarDealer? GetValidDealerChoice(ConsoleCollor _consoleCollor, List<ICarDealer> carDealers)
    {
        Console.Write("Select a dealer: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && 
            choice > 0 && 
            choice <= carDealers.Count)
        {
            return carDealers[choice - 1];
        }

        _consoleCollor.ShowInvalidChoiceMessage("dealer");
        return null;
    }
}