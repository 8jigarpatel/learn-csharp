# ArrayList

- A dynamically-sized collection of objects of any type.
- Largely superseded by the generic List class in newer versions of .NET Framework and .NET Core. List provides type safety and performance benefits, while still allowing you to store a collection of objects of different types if you use a common base class or interface.

## Operations:
- Add; `myArrayList.Add(obj);` // adds object at the end of the ArrayList
- Insert; `myArrayList.Insert(2, 5);` // adds 5 at index 2
- Update; `myArrayList[2] = 33;` //  updates the element at index 2 to 33
- Remove; `myArrayList.Remove(obj);` // removes the first occurrence of obj
- RemoveAt; `myArrayList.RemoveAt(3);` // removes the element at index 3
- Clear; `myArrayList.Clear();` // removes all elements from the ArrayList

## Pros:
- ArrayList can grow or shrink automatically.

## Cons:
- Not type-safe. You can store elements of any type.
- requires boxing and unboxing operations when storing and retrieving value types, which can impact performance.
- Can be slower than Array for certain operations.
- Can lead to `System.ArgumentOutOfRangeException` exceptions when performing insert/update/removeAt operations at invalid index (invalid = negative OR beyond size of collection).

## C# Syntax:
```
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
```
