

using System.Collections;
using System.Globalization;
using System.Net.Mail;

public class StringCalculator
{
    public StringCalculator()
    {
       
    }

    public int Add(string str)
    {
        int result = 0;
        if (string.IsNullOrWhiteSpace(str))
        {
            return result;
        }

        var delimmeters = new List<char>{',', '\n'};

        if (str.StartsWith("//"))
        {
            delimmeters.Add(str[2]);
            str = str.Substring(3);
        }
        var numbers = str.Split(delimmeters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

        foreach (var stringNumber in numbers)
        {
            
            int number = int.Parse(stringNumber);
            if (number < 0)
            {
                throw new ArgumentException("Negative numbers are not allowed.");
                
            } 
            
             if (number <= 1000)
            {
                result += number;
            }


        }

        return result;
    }

}

  


