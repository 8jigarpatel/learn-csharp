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
// code
```

## Possible Exceptions:


---

### sources:
- 