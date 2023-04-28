using System;
using System.Linq;

internal class Program
{
    enum Run
    {
        Undefined,
        Arrays,
        Operators,
        TypeConversions,
        ConditionalStatements,
        Loops,
        Methods
    }

    private static Run run = Run.Methods;

    private static void Main(string[] args)
    {
        switch (run)
        {
            case Run.Arrays:
                Arrays();
                break;
            case Run.Operators:
                Operators();
                break;
            case Run.TypeConversions:
                TypeConversions();
                break;
            case Run.ConditionalStatements:
                ConditionalStatements();
                break;
            case Run.Loops:
                Loops();
                break;
            case Run.Methods:
                Methods();
                break;
            default:
                Console.WriteLine("Please update `run` parameter.");
                break;
        };
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

        // For element's condition based search (Find/FindLast - to retrieve element, FindIndex/FindLastIndex - to retrieve index of element)
        Console.WriteLine(Array.FindIndex(myArray, x => x.Contains("ee"))); // 2
        Console.WriteLine(Array.FindLastIndex(myArray, x => x.Contains("wo"))); // 12
        Console.WriteLine(Array.Find(myArray, x => x.Contains("ee"))); // Three
        Console.WriteLine(Array.FindLast(myArray, x => x.Contains("wo"))); // Two

        Console.WriteLine(string.Join(",", Array.FindAll(myArray, x => x.Contains("wo")))); // all 'Two's

        // Sort/Reverse
        int[] myNums = { 5, 4, 3, 2, 1 };
        Array.Sort(myNums);
        Console.WriteLine(string.Join(",", myNums)); // 1,2,3,4,5
        Array.Reverse(myNums);
        Console.WriteLine(string.Join(",", myNums)); // 5,4,3,2,1
    }

    private static void Operators()
    {
        int numerator = 25;
        int denominator = 3;

        int quotient = numerator / denominator; // 8 (8*3 = 24)
        int remainder = numerator % denominator; // 1 (24+1 = 25)

        Console.WriteLine("numerator: {0}, and denominator: {1}", numerator, denominator);
        Console.WriteLine("quotient: {0}", quotient);
        Console.WriteLine("remainder: {0}", remainder);

        int? problems = null;
        Console.WriteLine("There are {0} problems.", problems ?? 0); // There are 0 problems
    }

    private static void TypeConversions()
    {
        // Implicit - two conditions must satisfy
        //    1. no loss of information
        //    2. no possibility of exception
        // e.g., from int to float
        int i1 = 100;
        float f1 = i1; // 100
        Console.WriteLine(f1);

        // Explicit - two conditions aren't met
        // e.g., from float to int
        float f2 = 555.55F;
        // int i2 = f2; // Cannot implicitly convert type 'type1' to 'type2'. An explicit conversion exists (are you missing a cast?)
        int i2 = (int)f2; // 555
        Console.WriteLine(i2);
        int i22 = Convert.ToInt32(f2); // 556
        Console.WriteLine(i22);

        float f3 = 555555555555;
        int i3 = (int)f3; // -2147483648
        Console.WriteLine(i3);
        // int i33 = Convert.ToInt32(f3); // System.OverflowException: 'Value was either too large or too small for an Int32.'

        string validIntStr = "999";
        int validInt = Convert.ToInt32(validIntStr); // 999
        // string invalidIntStr = "999.99";
        // int invalidInt = Convert.ToInt32(invalidIntStr); // System.FormatException: 'Input string was not in a correct format.'

        // Parse & TryParse
        string intStr1 = "700";
        int intFromStrParse1 = int.Parse(intStr1); // 700
        bool tryParseSuccess1 = int.TryParse(intStr1, out int intFromStrTryParse1);
        Console.WriteLine(tryParseSuccess1); // false
        Console.WriteLine(intFromStrTryParse1); // 0

        string intStr2 = "200Blah";
        // int intFromStrParse2 = int.Parse(intStr2); // System.FormatException: 'Input string was not in a correct format.'
        bool tryParseSuccess2 = int.TryParse(intStr2, out int intFromStrTryParse2);
        Console.WriteLine(tryParseSuccess2); // false
        Console.WriteLine(intFromStrTryParse2); // 0

        string intStr3 = "999999999999";
        // int intFromStrParse3 = int.Parse(intStr3); // System.OverflowException: 'Value was either too large or too small for an Int32.'
        bool tryParseSuccess3 = int.TryParse(intStr3, out int intFromStrTryParse3);
        Console.WriteLine(tryParseSuccess3); // false
        Console.WriteLine(intFromStrTryParse3); // 0
    }

    private static void ConditionalStatements()
    {
        // if & switch
        int number = 10;
        if (number == 10)
        {
            Console.WriteLine("Number is 10");
        }
        else if (number == 20)
        {
            Console.WriteLine("Number is 20");
        }
        else
        {
            Console.WriteLine("Number is neither 10 nor 20");
        }

        if (number == 10 || number == 20)
        {
            Console.WriteLine("Number is {0}", number);
        }
        else
        {
            Console.WriteLine("Number is neither 10 nor 20");
        }

        switch (number)
        {
            case 10:
                Console.WriteLine("Number is 10");
                break;
            case 20:
                Console.WriteLine("Number is 20");
                break;
            default:
                Console.WriteLine("Number is neither 10 nor 20");
                break;
        }

        switch (number)
        {
            case 10:
            case 20:
                Console.WriteLine("Number is {0}", number);
                break;
            default:
                Console.WriteLine("Number is neither 10 nor 20");
                break;
        }

        // && and ||
        if (number > 0 && number <= 20)
        {
            Console.WriteLine("Number is greater than 0 AND less than or equal 20");
        }

        if (number < 0 || number > 100)
        {
            Console.WriteLine("Number is less than 0 OR greater than 100");
        }
    }

    private static void Loops()
    {
        // while
        int whileStart = 0;
        while (whileStart <= 10)
        {
            if (whileStart % 2 == 0)
            {
                Console.WriteLine(whileStart);
            }
            whileStart += 2;
        }

        // do while
        int doWhileStart = 0;
        do
        {
            if (doWhileStart % 2 == 0)
            {
                Console.WriteLine(doWhileStart);
            }
            doWhileStart += 2;
        } while (doWhileStart <= 10);

        // for
        for (int i = 0; i <= 10; i += 2)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine(i);
            }
        }

        // foreach
        int[] zeroToTen = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        foreach (int number in zeroToTen)
        {
            if (number % 2 == 0)
            {
                Console.WriteLine(number);
            }
        }

        /*
         */
    }

    private static void Methods()
    {
        int i = 10;
        Console.WriteLine(i); // 10
        ChangeValueOfInt(i);
        Console.WriteLine(i); // 10
        ChangeValueOfIntRef(ref i);
        Console.WriteLine(i); // 20

        string s = "Jigar";
        Console.WriteLine(s); // "Jigar"
        ChangeValueOfString(s);
        Console.WriteLine(s); // "Jigar"
        ChangeValueOfStringRef(ref s);
        Console.WriteLine(s); // "Jigar Patel"

        int one = 10;
        int two = 5;
        DoSumAndProduct(one, two, out int sum, out int product);
        Console.WriteLine(sum); // 15
        Console.WriteLine(product);  // 50

        Console.WriteLine(SumAll(5)); // 5
        Console.WriteLine(SumAll(5, 5)); // 10
        Console.WriteLine(SumAll(5, 5, 5)); // 15
    }

    private static void ChangeValueOfInt(int input)
    {
        input = 20;
        Console.WriteLine(input + " - from ChangeValueOfInt"); // 20
    }

    private static void ChangeValueOfIntRef(ref int input)
    {
        input = 20;
        Console.WriteLine(input + " - from ChangeValueOfIntRef"); // 20
    }

    private static void ChangeValueOfString(string input)
    {
        input += " Patel";
        Console.WriteLine(input + " - from ChangeValueOfString"); // "Jigar Patel"
    }

    private static void ChangeValueOfStringRef(ref string input)
    {
        input += " Patel";
        Console.WriteLine(input + " - from ChangeValueOfStringRef"); // "Jigar Patel"
    }

    private static void DoSumAndProduct(int one, int two, out int sum, out int product)
    {
        sum = one + two;
        product = one * two;
    }

    private static int SumAll(params int[] nums)
    {
        return nums.Sum();

        //int sum = 0;
        //foreach(int num in nums)
        //{
        //    sum += num;
        //}
        //return sum;
    }
}
