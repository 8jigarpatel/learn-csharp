# Stack

- Stores elements in LIFO (Last In First Out)
- similar to a stack of plates in which the last item placed on top is the first item to be removed

## Operations:
- `Push(item);`: adds an item to the top of the stack.
- `Pop();`: removes and returns the item at the top of the stack.
- `Peek();`: returns the item at the top of the stack without removing it.
- `Count`: returns the number of items in the stack.
- `Clear()'`: removes all items from the stack.
- Note: Calling `Pop();` and `Peek();` on empty stack throws exception

## Pros:
- Fast insertion and removal of items at the top of the stack.
- Simple and intuitive to use.

## Cons:
- Slow access to items at the bottom of the stack.

## C# Syntax:
  ```
  // Generic
  Stack<int> myIntStack = new Stack<int>();

  // Non-Generica
  Stack myStack = new Stack();
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
  ```

---

### sources:
- https://www.youtube.com/watch?v=gUMwKyOXoQM