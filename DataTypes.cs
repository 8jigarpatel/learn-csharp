using System;
using System.Collections;
using System.Collections.Generic;

namespace learn_csharp
{
    internal class DataTypes
    {
        enum SubArea
        {
            Undefined,
            Array,
            ArrayList,
            Dictionary,
            HashSet,
            Hashtable,
            List,
            Queue,
            PriorityQueue,
            Stack
        }

        private static SubArea subArea = SubArea.PriorityQueue;

        public static void Start()
        {
            Console.WriteLine("Running: {0}\n", subArea);
            switch (subArea)
            {
                case SubArea.Array:
                    Arrays();
                    break;
                case SubArea.ArrayList:
                    ArrayLists();
                    break;
                case SubArea.Dictionary:
                    Dictionary();
                    break;
                case SubArea.HashSet:
                    HashSet();
                    break;
                case SubArea.Hashtable:
                    Hashtable();
                    break;
                case SubArea.List:
                    List();
                    break;
                case SubArea.Queue:
                    Queue();
                    break;
                case SubArea.PriorityQueue:
                    PriorityQueue();
                    break;
                case SubArea.Stack:
                    Stack();
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

        private static void Dictionary()
        {
            Dictionary<int, string> myDictionary = new Dictionary<int, string>();
            // add
            myDictionary.Add(1, "One");
            // myDictionary.Add(1, "One"); // System.ArgumentException: 'An item with the same key has already been added. Key: 1'
            myDictionary.Add(2, "Two");
            myDictionary.Add(3, "Three");

            // access/update - existing
            Console.WriteLine($"myDictionary[1]: {myDictionary[1]}"); // One
            myDictionary[1] = "NewOne";
            Console.WriteLine($"myDictionary[1]: {myDictionary[1]}"); // NewOne

            // access non-existing key
            // Console.WriteLine($"myDictionary[7]: {myDictionary[7]}"); // System.Collections.Generic.KeyNotFoundException: 'The given key '7' was not present in the dictionary.'

            // access/update new
            myDictionary[7] = "Seven";
            Console.WriteLine($"myDictionary[7]: {myDictionary[7]}"); // Seven

            // ContainsKey/ContainsValue - check if key-value pair exists using key or value
            Console.WriteLine($"myDictionary.ContainsKey(7): {myDictionary.ContainsKey(7)}"); // True
            Console.WriteLine($"myDictionary.ContainsValue(\"Seven\"): {myDictionary.ContainsValue("Seven")}"); // True

            // Count
            Console.WriteLine($"myDictionary.Count: {myDictionary.Count}"); // 4
            myDictionary.Remove(7); // existing
            myDictionary.Remove(77); // non-existing, does nothing
            Console.WriteLine($"myDictionary.Count: {myDictionary.Count}"); // 3

            // foreach record(KeyValuePair)
            foreach (KeyValuePair<int, string> pair in myDictionary)
            {
                Console.WriteLine($"{pair.Key} - {pair.Value}");
            }
            // 1 - NewOne
            // 2 - Two
            // 3 - Three
        }

        private static void HashSet()
        {
            // Create an empty HashSet of integers
            HashSet<int> hset1 = new HashSet<int>();
            hset1.Add(0);
            hset1.Add(5);
            hset1.Add(10);
            hset1.Add(15);
            Console.WriteLine($"hset1.Count: {hset1.Count}"); // 4
            Console.WriteLine($"hset1.Contains(20): {hset1.Contains(20)}"); // False
            hset1.Remove(20); // remove non-existing element, no error, does nothing
            Console.WriteLine($"hset1.Contains(15): {hset1.Contains(15)}"); // True
            hset1.Remove(15); // remove existing element
            Console.WriteLine($"hset1.Contains(15): {hset1.Contains(15)}"); // False
            Console.WriteLine($"hset1.Count: {hset1.Count}"); // 3
            // hset1 - 0, 5, 10
            Console.WriteLine("\n");

            int[] arr2 = new int[] { 10, 10, 15, 20, 20, 25 };
            Console.WriteLine($"arr2.Length: {arr2.Length}"); // 6
            HashSet<int> hset2 = new HashSet<int>(arr2); // create HashSet from an array of int
            Console.WriteLine($"hset2.Count: {hset2.Count}"); // 4, because duplicates from array were discarded when HashSet was created from the array
            Console.WriteLine("\n");

            Console.WriteLine("Set Operations:");

            Console.WriteLine($"hset1 initial: {string.Join(",", hset1)}"); // 0,5,10
            Console.WriteLine($"hset2 initial: {string.Join(",", hset2)}"); // 10,15,20,25

            hset1.UnionWith(hset2);
            Console.WriteLine($"hset1 after `hset1.UnionWith(hset2);`: {string.Join(",", hset1)}"); // 0,5,10,15,20,25
            Console.WriteLine($"hset2 after `hset1.UnionWith(hset2);`: {string.Join(",", hset2)}"); // 10,15,20,25

            hset1.IntersectWith(hset2);
            Console.WriteLine($"hset1 after `hset1.IntersectWith(hset2);`: {string.Join(",", hset1)}"); // 10,15,20,25
            Console.WriteLine($"hset2 after `hset1.IntersectWith(hset2);`: {string.Join(",", hset2)}"); // 10,15,20,25
        }

        private static void Hashtable()
        {
            Hashtable htable = new Hashtable();
            htable.Add(1, "One");
            htable.Add("1", 1);

            Console.WriteLine($"htable.Count: {htable.Count}"); // 2
            Console.WriteLine($"htable[1]: {htable[1]}"); // One
            Console.WriteLine($"htable[\"1\"]: {htable["1"]}"); // 1
            Console.WriteLine($"htable[\"blah\"]: {htable["blah"]}"); // null

            // htable.Add(1, "OneOne"); // System.ArgumentException: 'Item has already been added. Key in dictionary: '1'  Key being added: '1''

            htable[1] = "NewOne"; // access/update existing
            Console.WriteLine($"htable[1]: {htable[1]}"); // NewOne

            htable[105] = "One05"; // add new
            Console.WriteLine($"htable[105]: {htable[105]}"); // One05

            htable.Remove(1);
            htable.Add(1, "OneOne");
            Console.WriteLine($"htable[1]: {htable[1]}"); // OneOne

            htable.Remove(11); // non-existing key, does nothing

            Console.WriteLine($"htable.ContainsKey(1): {htable.ContainsKey(1)}"); // True
            Console.WriteLine($"htable.ContainsValue(11): {htable.ContainsValue(11)}"); // False
        }

        private static void List()
        {
            // Create a new list of integers, and add numbers
            List<int> numbers = new List<int>();
            numbers.Add(1);
            numbers.Add(3);
            numbers.Add(2);
            numbers.Add(4);

            Console.WriteLine($"numbers: {string.Join(", ", numbers)}"); // 1, 3, 2, 4
            Console.WriteLine($"numbers.Count: {numbers.Count}"); // 4
            Console.WriteLine($"numbers.Count: {numbers.Contains(5)}"); // False
            Console.WriteLine($"numbers.IndexOf(4): {numbers.IndexOf(4)}"); // 3

            numbers.Add(5);
            Console.WriteLine($"numbers after `numbers.Add(5);`: {string.Join(", ", numbers)}"); // 1, 3, 2, 4, 5
            numbers[4] = 55;
            Console.WriteLine($"numbers after `numbers[4] = 55;`: {string.Join(", ", numbers)}"); // 1, 3, 2, 4, 55
            // numbers.Insert(10,10); // System.ArgumentOutOfRangeException: 'Index must be within the bounds of the List. (Parameter 'index')'
            numbers.Insert(5, 6);
            Console.WriteLine($"numbers after `numbers.Insert(5,6);`: {string.Join(", ", numbers)}"); // 1, 3, 2, 4, 55, 6

            // Remove / RemoveAt
            numbers.Remove(55);
            Console.WriteLine($"numbers after `numbers.Remove(55);`: {string.Join(", ", numbers)}"); // 1, 3, 2, 4, 6
            numbers.RemoveAt(4);
            Console.WriteLine($"numbers after `numbers.RemoveAt(4);`: {string.Join(", ", numbers)}"); // 1, 3, 2, 4

            // Sort the list
            numbers.Sort();
            Console.WriteLine($"numbers after `numbers.Sort();`: {string.Join(", ", numbers)}"); // 1, 2, 3, 4

            // Clear the list
            numbers.Clear();
            Console.WriteLine($"numbers after `numbers.Clear();`: {string.Join(", ", numbers)}"); //
        }

        private static void Queue()
        {
            // Non-generic
            Queue myNonGenQueue = new Queue();

            // Generic 
            Queue<int> myQueue = new Queue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);

            Console.WriteLine("foreach (var q in myQueue) {...}");
            foreach (var q in myQueue)
            {
                Console.WriteLine(q);
            }

            Console.WriteLine($"myQueue.Count: {myQueue.Count}");

            Console.WriteLine($"myQueue.Peek(): {myQueue.Peek()}");
            Console.WriteLine($"myQueue.Pop(): {myQueue.Dequeue()}");
            Console.WriteLine($"myQueue.Peek(): {myQueue.Peek()}");

            Console.WriteLine($"myQueue.Count: {myQueue.Count}");
            Console.WriteLine($"myQueue.Contains(5): {myQueue.Contains(5)}");
            Console.WriteLine($"myQueue.Contains(55): {myQueue.Contains(55)}");

            myQueue.Clear();
            Console.WriteLine($"myQueue.Count after `myQueue.Clear();`: {myQueue.Count}");
        }

        private static void PriorityQueue()
        {
            // 347. Top K Frequent Elements
            int[] input = new int[] { 1, 2, 3, 1, 2, 1, 4, 5, 2, 6, 7, 2, 3, 2, 8, 2, 9 };
            Dictionary<int, int> dict = new();
            foreach (int i in input)
            {
                dict[i] = dict.GetValueOrDefault(i) + 1;
            }

            PriorityQueue<int, int> que = new PriorityQueue<int, int>(Comparer<int>.Create((a, b) => b - a));
            foreach (KeyValuePair<int, int> pair in dict)
            {
                que.Enqueue(pair.Key, pair.Value);
            }

            while (que.Count > 0)
            {
                Console.WriteLine($"{que.Dequeue()}");
            }
        }

        private static void Stack()
        {
            Stack myStack = new Stack();
            Stack<int> myStack2 = new Stack<int>();
            myStack.Push("START");
            myStack.Push(1);
            myStack.Push(true);
            myStack.Push("Three");
            myStack.Push(4);
            myStack.Push(null);
            myStack.Push(5);
            myStack.Push("END");

            Console.WriteLine("foreach (var s in myStack) {...}");
            foreach (var s in myStack)
            {
                Console.WriteLine(s);
            }

            Console.WriteLine($"myStack.Count: {myStack.Count}");

            Console.WriteLine($"myStack.Peek(): {myStack.Peek()}");
            Console.WriteLine($"myStack.Pop(): {myStack.Pop()}");
            Console.WriteLine($"myStack.Peek(): {myStack.Peek()}");

            Console.WriteLine($"myStack.Count: {myStack.Count}");
            Console.WriteLine($"myStack.Contains(5): {myStack.Contains(5)}");
            Console.WriteLine($"myStack.Contains(\"Five\"): {myStack.Contains("Five")}");

            myStack.Clear();
            Console.WriteLine($"myStack.Count after `myStack.Clear();`: {myStack.Count}");
        }
    }
}
