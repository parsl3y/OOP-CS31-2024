namespace LINQ_ARRAY_Lab6.Interfaces;

public interface INumberOperations
{
    double CalculateSumWithoutSmallest(IEnumerable<double> numbers, int count);
    IEnumerable<double> GetSmallestNumbers(IEnumerable<double> numbers, int count);
}