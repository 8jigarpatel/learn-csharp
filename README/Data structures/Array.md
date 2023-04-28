# Array

- Linear data structure
- An array is a collection of items (elements) stored at contiguous memory locations.
- The idea is to store multiple items of the same type together.
- This makes it easier to calculate the position of each element by simply adding an offset to a base value,
  i.e., the memory location of the first element of the array (generally denoted by the name of the array).
- Multidimensional array and jagged array:
  - A multidimensional array is an array with multiple dimensions, whereas a jagged array is an array of arrays.
  - The main difference is that a multidimensional array must have the same number of elements in each dimension, while a jagged array can have different lengths for each sub-array.
  
## Terminology:
- Element
- Index
- Length
- Rank (dimension)

## Operations:
- access / update element; `arrayName[index]`
- iterate through elements; `for (...) {};` or `foreach (...) {};`
- sort elements; `Array.Sort(arrayName);`
   - parameters: startIndex & length > starting index of sort and number of elements to sort
- reverse elements; `Array.Reverse(arrayName);`
    - parameters: startIndex & length > starting index of reverse section and number of elements to reverse
- IndexOf/LastIndexOf:
   - find index of a specific element
   - `Array.IndexOf(myArray, "Zero");` or ``Array.LastIndexOf(myArray, "Three");``
   - parameter: startIndex > starting index of search; `Array.IndexOf(myArray, "Three", 3);`
   - parameter: count > number of elements to search; `Array.IndexOf(myArray, "Three", 6, 5);`
- FindIndex/FindLastIndex:
    - find and return index of an element that matches a specified condition
    - `Array.FindIndex(myArray, x => x.Contains("ee"));` or `Array.FindLastIndex(myArray, x => x.Contains("wo"));`
    - parameter: startIndex > starting index of search; `Array.IndexOf(myArray, "Three", 3);`
    - parameter: count > number of elements to search; `Array.IndexOf(myArray, "Three", 6, 5);`
- Find/FindLast:
    - find and return an element that matches a specified condition
    - `Array.Find(myArray, x => x.Contains("ee"));` or `Array.FindLast(myArray, x => x.Contains("wo"));`
- FindAll:
    - find and return all elements that matches a specified condition
    - `Array.FindAll(myArray, x => x.Contains("wo"));`

## Pros:
- Strongly typed - can only store data elements of the same type.
- Arrays allow random access to elements. This makes accessing elements by position faster.

## Cons:
- Array size can't change once created, makes insertion and deletion difficult
- Relies on int indexes to store/retrieve items

## C# Syntax:
```
// DataType[] arrayName;
// arrayName = new DataType[] {Data1, Data2};
// OR, arrayName = new DataType[DataSize] {Data1, Data2};

// DataType[] arrayName = new DataType[ArraySize];
// arrayName[0] = Data1;
// arrayName[1] = Data2;

// DataType[] arrayName = { Data1, Data2};
// DataType[] arrayName = new DataType[]{ Data1, Data2};
// DataType[] arrayName = new DataType[2]{ Data1, Data2};

// DataType[] arrayName = new DataType[]; // ERROR: size must be supplied when data isn't supplied
```

For Example:

```
string[] cars;
cars = new string[] { "Nissan", "Mazda" };
// OR, cars = new string[2] { "Nissan", "Mazda" };

string[] mehCars = new string[2];
mehCars[0] = "BMW";
mehCars[1] = "Mercedes";

string[] fastCars = { "Mustang", "Lexus" };
string[] niceCars = new string[] { "Mustang", "Toyota" };
string[] goodCars = new string[2] { "Honda", "Ford" };
```

Operations:
```
// Access / Update element
string firstFastcar = fastCars[0]; // "Mustang"
fastCars[0] = "Lexus";

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
Console.WriteLine(Array.FindLast(myArray, x => x.Contains("wo"))); // T

// Sort/Reverse
int[] myNums = { 5, 4, 3, 2, 1 };
Array.Sort(myNums);
Console.WriteLine(string.Join(",", myNums)); // 1,2,3,4,5
Array.Reverse(myNums);
Console.WriteLine(string.Join(",", myNums)); // 5,4,3,2,1
```

---

### sources:
- https://www.geeksforgeeks.org/what-is-array/
- https://www.geeksforgeeks.org/array-data-structure/
- https://www.geeksforgeeks.org/introduction-to-arrays-data-structure-and-algorithm-tutorials/
- https://www.geeksforgeeks.org/applications-advantages-and-disadvantages-of-array-data-structure/
- https://www.w3schools.com/cs/cs_arrays.php
- https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/arrays/