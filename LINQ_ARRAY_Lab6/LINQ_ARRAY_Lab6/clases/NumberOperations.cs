using LINQ_ARRAY_Lab6.Interfaces;

namespace LINQ_ARRAY_Lab6;

public class NumberOperations : INumberOperations
{
    public double CalculateSumWithoutSmallest(IEnumerable<double> numbers, int count)
    {
        return numbers.OrderBy(n => n).Skip(count).Sum();
    }

    public IEnumerable<double> GetSmallestNumbers(IEnumerable<double> numbers, int count)
    {
        return numbers.OrderBy(n => n).Take(count);
    }
}