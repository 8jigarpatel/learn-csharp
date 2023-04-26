using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Arrays();
        Console.WriteLine("END");
    }

    private static void Arrays()
    {
        string[] cars;
        cars = new string[] { "Nissan", "Mazda" };
        // OR, cars = new string[2] { "Nissan", "Mazda" };

        string[] mehCars = new string[2];
        mehCars[0] = "BMW";
        mehCars[1] = "Mercedes";

        string[] fastCars = { "Mustang", "Lexus" };
        string[] niceCars = new string[] { "Mustang", "Toyota" };
        string[] goodCars = new string[2] { "Honda", "Ford" };

        // Access / Update element
        string firstFastcar = fastCars[0]; // "Mustang"

        // Get length 
        int numFastCars = fastCars.Length; // 2  

        // iterate - for
        for (int i = 0; i < fastCars.Length; i++)
        {
            Console.WriteLine(fastCars[i]);
        }

        // iterate - foreach
        foreach (string car in fastCars)
        {
            Console.WriteLine(car);
        }

        // sorting
        string[] abc = { "a", "b", "c" };
        string[] cba = new string[] { "c", "b", "a" };
        string[] bca = new string[3] { "b", "c", "a" };

        string[][] blah = new string[3][] { abc, cba, bca };
        foreach (var strArray in blah)
        {
            Array.Sort(strArray);
            Console.WriteLine(string.Join(",", strArray));
        }
        // OUTPUT:
        // a,b,c
        // a,b,c
        // a,b,c

        int[] i123 = { 1, 2, 3 };
        int[] i321 = new int[] { 3, 2, 1 };
        int[] i213 = new int[3] { 2, 1, 3 };

        int[][] bleh = new int[][] { i123, i321, i213 };
        for (int i = 0; i < bleh.Length; i++)
        {
            Array.Sort(bleh[i]);
            Console.WriteLine(string.Join(",", bleh[i]));
        }
        // OUTPUT:
        // 1,2,3
        // 1,2,3
        // 1,2,3

        // multidimensional array - grid
        int[,] matrix = new int[3, 3];
        matrix[0, 0] = 1;
        matrix[0, 1] = 2;
        matrix[0, 2] = 3;
        matrix[1, 0] = 4;
        matrix[1, 1] = 5;
        matrix[1, 2] = 6;
        matrix[2, 0] = 7;
        matrix[2, 1] = 8;
        matrix[2, 2] = 9;
        Console.WriteLine($"{matrix[0, 0]} - {matrix[0, 1]} - {matrix[0, 2]}");
        Console.WriteLine($"{matrix[1, 0]} - {matrix[1, 1]} - {matrix[1, 2]}");
        Console.WriteLine($"{matrix[2, 0]} - {matrix[2, 1]} - {matrix[2, 2]}");
        // OUTPUT:
        // 1 - 2 - 3
        // 4 - 5 - 6
        // 7 - 8 - 9

        // jagged array
        int[][] jagged = new int[3][];
        jagged[0] = new int[] { 1, 2 };
        jagged[1] = new int[] { 3, 4, 5 };
        jagged[2] = new int[] { 6, 7, 8, 9 };
        foreach (int[] array in jagged)
        {
            Console.WriteLine(string.Join(",", array));
        }
        // OUTPUT:
        // 1,2
        // 3,4,5
        // 6,7,8,9

        // IndexOf -------------------->    0      1       2       3      4       5       6       7       8      9      10      11     12      13      
        string[] myArray = new string[] { "One", "Two", "Three", "One", "Two", "Three", "Four", "Five", "One", "Two", "Three", "One", "Two", "Three" };
        Console.WriteLine(Array.IndexOf(myArray, "Zero")); // -1, element doesn't exist in Array
        Console.WriteLine(Array.IndexOf(myArray, "Three")); // 2
        Console.WriteLine(Array.IndexOf(myArray, "Three", 3)); // 5
        Console.WriteLine(Array.IndexOf(myArray, "Three", 6, 5)); // 10
        Console.WriteLine(Array.LastIndexOf(myArray, "Three")); // 13

        // Sort/Reverse
        int[] myNums = { 5, 4, 3, 2, 1 };
        Array.Sort(myNums);
        Console.WriteLine(string.Join(",", myNums)); // 1,2,3,4,5
        Array.Reverse(myNums);
        Console.WriteLine(string.Join(",", myNums)); // 5,4,3,2,1
    }
}