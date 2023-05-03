# HashSet

- HashSet is a collection that contains unique elements only. Elements are not sorted.
- Provides constant-time performance for the basic operations such as Add, Remove, Contains, and Count.

## Operations:
- Add(element):
  - Adds an element to the HashSet if it's not already present.
- Remove(element):
  - Removes an element from the HashSet if it's present.
- Contains(element):
  - Returns true if the element is present in the HashSet, otherwise false.
- Count:
  - Returns the number of unique elements in the HashSet.
- UnionWith(other):
  - Modifies the current HashSet to contain all elements that are present in itself, other HashSet or both.
- IntersectWith(other):
  - Modifies the current HashSet to contain only elements that are also in a specified HashSet.
- ExceptWith(other):
  - Modifies the current HashSet to contain only elements that are not in a specified HashSet.
- SymmetricExceptWith(other):
  - Modifies the current HashSet to contain only elements that are present either in the current HashSet or in the specified HashSet, but not in both.

## Pros:
- HashSet provides constant-time performance for basic operations, such as Add, Remove, Contains, and Count.
- HashSet does not allow duplicate elements.
- HashSet provides methods to perform set operations, such as UnionWith, IntersectWith, ExceptWith, and SymmetricExceptWith.

## Cons:
- HashSet does not preserve the order of elements.
- HashSet uses more memory than a List for storing the same number of elements.

## C# Syntax:
  ```
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
  
  int[] arr2 = new int[] { 10, 10, 15, 20, 20, 25};
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
  ```

## Possible Exceptions:


---

### sources:
- 