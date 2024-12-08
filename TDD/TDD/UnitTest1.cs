using System.Collections;
using Xunit;

namespace TDD;

public class UnitTest1

{ 
    [Theory]
    [InlineData("1005, 1",1)]
    public void Should_return_ignore_big_numbers_exceptionstring(string input, int expected)
    {
        //arrange
        var calc = new StringCalculator();
        //act
        var result = calc.Add(input);
        //assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("-2, 1", "Negative numbers are not allowed.")]
    public void Should_return_negative_numbers_exceptionstring(string input, string expectedMessage)
    {
        // arrange
        var calc = new StringCalculator();
        // act
        var exception = Assert.Throws<ArgumentException>(() => calc.Add(input));
        // assert
        Assert.Equal(expectedMessage, exception.Message);
    }


    
    [Theory]
    [InlineData("// 1,2, 3,4,5\n 6",21)]
    public void Should_return_different_delimetr_unknowk_numbers_string(string input, int expected)
    {
        //arrange
        var calc = new StringCalculator();
        //act
        var result = calc.Add(input);
        //assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("1,2\n 3,4,5\n 6",21)]
    public void Should_return_two_delimetr_unknowk_numbers_string(string input, int expected)
    {
        //arrange
        var calc = new StringCalculator();
        //act
        var result = calc.Add(input);
        //assert
        Assert.Equal(expected, result);
    }

    
    [Theory]
    [InlineData("1,2,3,4,5,6",21)]
    public void Should_return_commas_delimetr_unknowk_numbers_string(string input, int expected)
    {
        //arrange
        var calc = new StringCalculator();
        //act
        var result = calc.Add(input);
        //assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("1,2",3)]
    public void Should_return_commas_delimetr_two_numbers_string(string input, int expected)
    {
        //arrange
        var calc = new StringCalculator();
        //act
        var result = calc.Add(input);
        //assert
        Assert.Equal(expected, result);
    }
    
    [Fact]
    public void Should_return_one_number_string()
    {
        //arrange
        var calc = new StringCalculator();
        //act
        var result = calc.Add("1");
        //assert
        Assert.Equal(1, result);
    }
    
    [Fact]
    public void Should_return_empty_string()
    {
        //arrange
        var calc = new StringCalculator();
        //act
        var result = calc.Add("");
        //assert
        Assert.Equal(0, result);
    }

}

