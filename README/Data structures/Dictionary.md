# Dictionary

- Collection of key-value pairs, where keys are unique
- Allows quick access to elements based on a key, similar to a real-life dictionary that allows you to look up a word and get its definition
  
## Terminology:
- Key: unique identifier for each element in the dictionary.
- Value: the data associated with the key in the dictionary.
- KeyValuePair: represents a single key/value pair in the dictionary.

## Operations:
- Add; `myDictionary.Add(1, "One");`
- Access/Update; `myDictionary[7] = "Seven";`
- Remove; `myDictionary.Remove(7);`
- Check if a pair with given key/value exits; `myDictionary.ContainsKey(7);` or `myDictionary.ContainsValue("Seven");`
- iterate over collection; `foreach (KeyValuePair<int, string> pair in myDictionary) {...}`

## Pros:
- Fast access to elements based on key.
- Supports generic types, which makes it type-safe and avoids the need for boxing/unboxing.
- Easy to use syntax.

## Cons:
- Not thread-safe by default.
- Elements are not sorted.

## C# Syntax:
  ```
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
  ```

## Possible Exceptions:
- `KeyNotFoundException`: This exception is thrown when trying to access a key that does not exist in the dictionary. For example, when trying to access the value of a key that is not present using the indexer [].
- `ArgumentException`: This exception is thrown when trying to add a duplicate key to the dictionary. For example, when trying to add a key-value pair with a key that already exists in the dictionary using the Add() method.
- `ArgumentNullException`: This exception is thrown when trying to add a null key to the dictionary using the Add() method or when trying to pass a null key to other methods like ContainsKey(), Remove(), TryGetValue(), etc.
- `InvalidOperationException`: This exception is thrown when trying to modify the dictionary while iterating over it using an enumerator.

## `Dictionary` vs `ConcurrentDictionary`:
- Thread-safety: Dictionary is not thread-safe, while ConcurrentDictionary is thread-safe. This means that multiple threads can safely access and modify a ConcurrentDictionary instance simultaneously, whereas with Dictionary you would need to use locking or other synchronization techniques to avoid race conditions.
- Performance: ConcurrentDictionary has slightly worse performance than Dictionary for single-threaded scenarios, but better performance for multi-threaded scenarios. This is because the thread-safety mechanisms used in ConcurrentDictionary can introduce some overhead when there is only one thread accessing the data structure.
- API: ConcurrentDictionary has a slightly different API than Dictionary to support its thread-safety features. For example, it provides a GetOrAdd method that atomically retrieves a value from the dictionary or adds it if it does not exist.

In general, you should use Dictionary when you are working in a single-threaded environment or when you can guarantee that all access to the dictionary will be properly synchronized. Use ConcurrentDictionary when you need to safely access and modify the dictionary from multiple threads simultaneously.

Keep in mind that ConcurrentDictionary can have some performance overhead compared to Dictionary when there is only one thread accessing it, so you should weigh the benefits of thread-safety against the potential performance impact.

---

### sources:
- https://www.youtube.com/watch?v=DVXqDV_A-mw