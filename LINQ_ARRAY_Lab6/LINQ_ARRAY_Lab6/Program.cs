using System;
using System.Linq;
using System.Collections.Generic;
using LINQ_ARRAY_Lab6;
using LINQ_ARRAY_Lab6.Interfaces;


class Program
{
    static void Main()
    {
        var str = "a, 1, 2, f, -1, 0, 4, 10, 4, 4f, 8, 9, 3";

        var stringParser = new StringParser();
        var numberOperations = new NumberOperations();
        var service = new NumberProcessing(stringParser, numberOperations);

        service.Process(str);
    }
}
