using LINQ_ARRAY_Lab6.Interfaces;

public class StringParser : IStringParser
{
    public IEnumerable<double> ParseNumbers(string input)
    {
        return input.Split(',')
            .Select(part =>
            {
                double number;
                return double.TryParse(part.Trim(), out number) ? (double?)number : null;
            })
            .Where(num => num.HasValue)
            .Select(num => num.Value);
    }
}