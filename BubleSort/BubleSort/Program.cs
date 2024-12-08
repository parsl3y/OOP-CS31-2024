using System;
class Program
{
    public delegate bool SortTypeDelegate(int x, int y);
    
    

    
    public static void BubbleSort(int[] array, SortTypeDelegate compare)
    {
        for (int i = 0; i < array.Length - 1; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)  
            {                                               
                if (compare(array[j], array[j + 1])) // без делегата    
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
    public static void PrintArray(int[] array)
    {
        foreach (int element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
    static void Main()
    {
        int[] array = new int[10];
        Random random = new Random();

        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100);
        }

        Console.WriteLine("Basic array");
        PrintArray(array);

        BubbleSort(array, (x, y) => x  < y);

     
        Console.WriteLine("\nSorted array:");
        PrintArray(array);
           
        BubbleSort(array, (x, y) => x  > y);
        Console.WriteLine("\nSorted array:");
        PrintArray(array);
    }
 
}