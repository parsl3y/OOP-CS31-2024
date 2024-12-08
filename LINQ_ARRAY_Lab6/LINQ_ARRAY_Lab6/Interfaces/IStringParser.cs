namespace LINQ_ARRAY_Lab6.Interfaces;

public interface IStringParser
{
    IEnumerable<double> ParseNumbers(string input);
}