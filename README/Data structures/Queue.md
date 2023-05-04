# Queue

- Stores elements in FIFO (First In First Out)

## Operations:
- `Enqueue(item);`: Adds an element to the end of the queue.
- `Dequeue();`: Removes and returns the element from the front of the queue.
- `Peek();`: Returns the element at the front of the queue without removing it.
- `Count`: Returns the number of elements in the queue.
- Note: Calling `Dequeue();` and `Peek();` on empty queue throws exception

## Pros:
- Queues are useful in scenarios where the order of elements needs to be maintained, such as in a print queue or a message queue.
- Queues are easy to implement and maintain.

## Cons:
- Accessing elements in the middle of a queue is not efficient.
- Queues have a limited capacity and can overflow if elements are continuously added.

## C# Syntax:
  ```
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
  ```

---

### sources:
- https://www.youtube.com/watch?v=l8OVYcpBlnI