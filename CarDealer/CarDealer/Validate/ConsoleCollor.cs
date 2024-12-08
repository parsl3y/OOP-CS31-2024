namespace CarDealer.Validate;

public class ConsoleCollor
{
    public void ShowInvalidChoiceMessage(string item)
    {
        var originalColor = Console.ForegroundColor;
    
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"Invalid {item}.");
    
        Console.ForegroundColor = originalColor;
    }
    public void ShowSuccesChoiceMessage(string item)
    {
        var originalColor = Console.ForegroundColor;
    
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"Succes {item}.");
    
        Console.ForegroundColor = originalColor;
    }
}