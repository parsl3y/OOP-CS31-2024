using Xunit;

public class CalculatorTests
{
    [Theory]
    [InlineData(5, 3, 8)]
    [InlineData(-1, -1, -2)]
    [InlineData(0, 0, 0)]
    public void Add_IntValues_ReturnsCorrectResult(int a, int b, int expected)
    {
        var calculator = new Calculator<int>();
        var result = calculator.Add(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 4, 6)]
    [InlineData(0, 0, 0)]
    [InlineData(-1, -1, 0)]
    public void Subtract_IntValues_ReturnsCorrectResult(int a, int b, int expected)
    {
        var calculator = new Calculator<int>();
        var result = calculator.Subtract(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, 3, 6)]
    [InlineData(0, 100, 0)]
    [InlineData(-2, -3, 6)]
    public void Multiply_IntValues_ReturnsCorrectResult(int a, int b, int expected)
    {
        var calculator = new Calculator<int>();
        var result = calculator.Multiply(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 2, 5)]
    [InlineData(-10, -2, 5)]
    [InlineData(0, 1, 0)]
    public void Divide_IntValues_ReturnsCorrectResult(int a, int b, int expected)
    {
        var calculator = new Calculator<int>();
        var result = calculator.Divide(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 0)]
    public void Divide_ByZero_ThrowsDivideByZeroException(int a, int b)
    {
        var calculator = new Calculator<int>();
        Assert.Throws<DivideByZeroException>(() => calculator.Divide(a, b));
    }

    [Theory]
    [InlineData(2, 3, 8)]
    [InlineData(5, 0, 1)]
    [InlineData(3, 2, 9)]
    public void Pow_IntValues_ReturnsCorrectResult(int a, int exponent, int expected)
    {
        var calculator = new Calculator<int>();
        var result = calculator.Pow(a, exponent);
        Assert.Equal(expected, result);
    }
}
