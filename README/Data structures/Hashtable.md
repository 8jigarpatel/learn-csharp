# Hashtable

- Older collection and has been mostly replaced by Dictionary
  - main difference between HashTable and Dictionary is that HashTable is thread-safe, whereas Dictionary is not. If thread-safety is required, `ConcurrentDictionary<TKey, TValue>` can be used instead
- Hashtable non-generic key-based collection is used to store key-value pairs.
  - non-generic meaning it can store key-value pairs of any type, unlike Dictionary in C#, which is a generic collection and can store key-value pairs of specific types
  - key-based meaning it stores key-value pairs, unlike Array, ArrayList, and List that are index-based collections
- uses a hash function to compute an index.
  
## Terminology:
- Blah

## Operations:
- Add; `htable.Add(1,"One");`
- Remove; `htable.Remove(11);`
- Clear; `htable.Clear();`
- Count; `htable.Count;`
- ContainsKey; `htable.ContainsKey(1);`
- ContainsValue; `htable.ContainsValue(11);`

## Pros:
- prvoides fast access to items, even for large collections.

## Cons:
- does not preserve the order of the items in the collection
- not thread safe

## C# Syntax:
  ```
  Hashtable htable = new Hashtable();
  htable.Add(1,"One");
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
  ```

---

### sources:
- https://www.youtube.com/playlist?list=PL2Q8rFbm-4ru_qCllHPOgkpU8XtO25Wh3