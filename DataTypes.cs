using System;
using System.Collections;

namespace learn_csharp
{
    internal class DataTypes
    {
        enum SubArea
        {
            Undefined,
            Arrays,
            ArrayLists
        }

        private static SubArea subArea = SubArea.ArrayLists;

        public static void Start()
        {
            Console.WriteLine("Running: {0}\n", subArea);
            switch (subArea)
            {
                case SubArea.Arrays:
                    Arrays();
                    break;
                case SubArea.ArrayLists:
                    ArrayLists();
                    break;
                default:
                    Console.WriteLine("Invalid `{0}` selected.", nameof(subArea));
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

        private static void ArrayLists()
        {
            // Example with Array
            int[] myArray = new int[] { 1, 2, 3 };
            Console.WriteLine("First element in myArray: " + myArray[0]);

            // Example with ArrayList
            ArrayList myArrayList = new ArrayList();
            myArrayList.Add(1);
            myArrayList.Add("Two");
            myArrayList.Add(3);
            Console.WriteLine("Second element in myArrayList: " + myArrayList[1]); // Two

            // Adding elements
            myArrayList.Add(4); // adds 4 to the end of the ArrayList
            Console.WriteLine("Last element in myArrayList (after adding 4): " + myArrayList[myArrayList.Count - 1]); // 4

            myArrayList.Insert(1, 22); // inserts 999 at index 2
            Console.WriteLine("Second element in myArrayList (after inserting 22 at index 1): " + myArrayList[1]); // 22
            // myArrayList.Insert(10, 999);
            // ^ System.ArgumentOutOfRangeException: 'Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')'

            // Updating elements
            myArrayList[1] = 33; // updates the element at index 2 to 33
            Console.WriteLine("Second element in myArrayList (after updating element at index 1 to 33): " + myArrayList[1]); // 33
            // myArrayList[10] = 33;
            // ^ System.ArgumentOutOfRangeException: 'Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')'

            // Removing elements
            myArrayList.Remove(202); // removes the first occurrence of 2

            myArrayList.RemoveAt(1); // removes the element at index 0
            Console.WriteLine("Second element in myArrayList (after removing element at index 1): " + myArrayList[1]); // Two
            // myArrayList.RemoveAt(10);
            // ^ System.ArgumentOutOfRangeException: 'Index was out of range. Must be non-negative and less than the size of the collection. (Parameter 'index')'

            myArrayList.Clear(); // removes all elements from the ArrayList
            Console.WriteLine("myArrayList.Count (after clearing): " + myArrayList.Count); // 0
        }
    }
}
