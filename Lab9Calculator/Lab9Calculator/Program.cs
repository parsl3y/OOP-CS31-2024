using System.Numerics;

public class Calculator<T> where T : INumber<T>
{
    public T Add(T a, T b)
    {
        return a + b;
    }

    public T Subtract(T a, T b)
    {
        return a - b;
    }

    public T Multiply(T a, T b)
    {
        return a * b;
    }

    public T Divide(T a, T b)
    {
        if (b == T.Zero)
            throw new DivideByZeroException("Cannot divide by zero.");
        return a / b;
    }

    public T Pow(T a, int exponent)
    {
        T result = T.One;
        for (int i = 0; i < exponent; i++)
        {
            result *= a;
        }
        return result;
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        var intCalculator = new Calculator<int>();
        Console.WriteLine(intCalculator.Add(5, 3));        
        Console.WriteLine(intCalculator.Subtract(10, 4)); 
        Console.WriteLine(intCalculator.Multiply(2, 3));  
        Console.WriteLine(intCalculator.Divide(10, 2));      
        Console.WriteLine(intCalculator.Pow(2, 3));         

        var doubleCalculator = new Calculator<double>();
        Console.WriteLine(doubleCalculator.Add(5.5, 3.2));   
        Console.WriteLine(doubleCalculator.Subtract(10.1, 4.1));
        Console.WriteLine(doubleCalculator.Multiply(2.5, 3.1)); 
        Console.WriteLine(doubleCalculator.Divide(10.5, 2.5));  
        Console.WriteLine(doubleCalculator.Pow(1.5, 3));   
        
        var decimalCalculator = new Calculator<decimal>();
        Console.WriteLine(decimalCalculator.Add(5.5m, 3.2m));   
        Console.WriteLine(decimalCalculator.Subtract(10.1m, 4.1m));
        Console.WriteLine(decimalCalculator.Multiply(2.5m, 3.1m)); 
        Console.WriteLine(decimalCalculator.Divide(10.5m, 2.5m));  
        Console.WriteLine(decimalCalculator.Pow(1.5m, 3));  
    }
}
