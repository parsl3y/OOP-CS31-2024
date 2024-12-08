using LINQ_ARRAY_Lab6.Interfaces;

namespace LINQ_ARRAY_Lab6;

public class NumberProcessing
{
    private readonly IStringParser _stringParser;
    private readonly INumberOperations _numberOperations;

    public NumberProcessing(IStringParser stringParser, INumberOperations numberOperations)
    {
        _stringParser = stringParser;
        _numberOperations = numberOperations;
    }

    public void Process(string input)
    {
        var numbers = _stringParser.ParseNumbers(input);

        Console.WriteLine("Only number ARRAY: " + string.Join(", ", numbers));

        var smallestNumbers = _numberOperations.GetSmallestNumbers(numbers, 3);
        Console.WriteLine("3s min numbers: " + string.Join(", ", smallestNumbers));

        var sumWithoutSmallest = _numberOperations.CalculateSumWithoutSmallest(numbers, 3);
        Console.WriteLine($"Sum without 3s min numbers: {sumWithoutSmallest}");
    }
}