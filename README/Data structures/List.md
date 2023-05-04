# List

- Collection of elements of the same type, accessible by an index (just like array!)
- provides dynamic resizing, efficient element manipulation, and a variety of useful methods to manipulate and query the elements.
  
## Terminology:
- Element: A single item in the list
- Index: A zero-based integer representing the position of an element in the list
- Capacity: The number of elements that the list can currently hold without needing to resize
- Count: The number of elements currently in the list

## Operations:
- Add: Add an element to the end of the list
- Insert: Insert an element at a specified index
- Remove: Remove the first occurrence of an element from the list
- RemoveAt: Remove the element at a specified index
- Clear: Remove all elements from the list
- Contains: Check if an element is present in the list
- IndexOf: Get the index of the first occurrence of an element in the list
- Sort: Sort the elements in the list in ascending order
- Reverse: Reverse the order of the elements in the list
- TrimExcess: Set the capacity of the list to the actual number of elements

## Pros:
- Provides dynamic resizing, making it easy to add or remove elements
- Efficient element access and manipulation through indexing
- A wide range of useful methods for manipulating and querying the elements

## Cons:
- Inserting or removing elements in the middle of the list can be slow as it requires shifting all the subsequent elements
- It is not suitable for large collections of items due to the contiguous memory allocation

## Array vs List:
- Size: The size of an array is fixed once it is declared, while the size of a list can be dynamically resized by adding or removing elements.
- Performance: Accessing elements in an array is generally faster than accessing elements in a list. However, adding and removing elements in a list is faster than in an array.
- Built-In Methods: Arrays provide basic methods like Copy, Reverse, Sort etc. whereas List provides an extensive set of methods like Add, Insert, Remove, RemoveAt, RemoveRange, Clear, Contains, etc.

## C# Syntax:
  ```
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
  numbers.Insert(5,6);
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
  ```

## Possible Exceptions:
- `ArgumentNullException`: Thrown when a null argument is passed to a method that does not accept it. For example, passing a null value as the parameter to `List<T>.Add` method.
- `ArgumentOutOfRangeException`: Thrown when the argument provided to a method is outside the range of acceptable values. For example, trying to access an index that is less than zero or greater than the length of the list in the `List<T>.this[int index]` property.
- `InvalidOperationException`: Thrown when the operation is not valid for the current state of the object. For example, trying to modify a list while it is being enumerated.
- `NotSupportedException`: Thrown when the requested operation is not supported by the collection. For example, trying to modify a list that has been created with the `List<T>.AsReadOnly` method.

---

### sources:
- 
