# Algorithms

## Search

<details>
<summary>Linear Search</summary>

  - Suitable for small collections or when the elements are not sorted
  - Time complexity: `O(n)`

  ```
  int[] numbers = new int[] { 5, 6, 3, 2, 4, 1};
  int target = 4;

  for (int i = 0; i < numbers.Length; i++) {
    if (numbers[i] == target) {
        return i;
    }
  }
  return -1;
  ```
</details>

<details>
<summary>Binary Search</summary>

  - Suitable for large sorted collections
  - Works by repeatedly dividing the search space in half and narrowing down the search range until the target element is found (i.e., uses a divide and conquer approach)
  - Time complexity: `O(log n)`

  ```
  int[] numbers = new int[] { 0, 2, 3, 5, 7, 8, 9, 11};
  int target = 9;

  int start = 0;
  int end = numbers.Length - 1; // !!! -1 because (start <= end)
  while (start <= end>) {
    int mid = start + (end - start) / 2;
    if (numbers[mid] > target) { end = mid - 1; } 
    else if (numbers[mid] < target) { start = mid + 1; }
    else return mid;
  }
  return -1;
  ```
</details>

## Sort
<details>
<summary>Bubble Sort</summary>

  - Repeatedly compare adjacent elements and swaps them if they are in the wrong order
  - use for sorting small collections where simplicity is prioritized over efficiency
  - Time complexity: `O(n^2)`

  ```
  int[] arr = new int[] { 5, 4, 3, -1, 9, 5, 2, 3, 2, -1, 8, 9, -1, 9, 7, 1 };
  for (int i = 0; i < arr.Length - 1; i++) // if length is 5, iterate 4 times (i: 0, 1, 2, 3)
  {
      bool swapped = false;
      for (int j = 1; j < arr.Length - i; j++) // start at 1 (to compare element at 1 and 0, and... go until length - i (i.e., depending on 'i' in the main loop - which pass))
      {
          if (arr[j] < arr[j - 1])
          {
              swapped = true;
              int temp = arr[j];
              arr[j] = arr[j - 1];
              arr[j - 1] = temp;
          }
      }
      if (!swapped)
      {
          break;
      }
  }
  ```
</details>

<details>
<summary>Selection Sort</summary>

  - Repeatedly select the largest (or smallest) element from the unsorted part of the collection and place it in its correct position
  - Same as bubble sort, use for sorting small collections where simplicity is prioritized over efficiency
  - Time complexity: `O(n^2)`

  ```
  int[] nums = new int[] { 5, 1, 2, 3, 4 };
  for (int i = 0; i < nums.Length - 1; i++) //  !!! -1 
  {
      int maxIndex = SelectionSortGetMaxIndex(nums, 0, nums.Length - 1 - i); // find max element's index
      if (nums[maxIndex] > nums[nums.Length - 1 - i]) // if max element is bigger than "current pass's" last element, swap them
      {
          int temp = nums[maxIndex];
          nums[maxIndex] = nums[nums.Length - 1 - i];
          nums[nums.Length - 1 - i] = temp;
      }
  }

  private static int SelectionSortGetMaxIndex(int[] nums, int start, int end)
  {
      int maxIndex = start;
      for (int i = start; i <= end; i++)
      {
          if (nums[i] > nums[maxIndex])
          {
              maxIndex = i;
          }
      }
      return maxIndex;
  }
  ```
</details>

<details>
<summary>Insertion Sort</summary>

  - Build the final sorted array one element at a time, shifting elements larger than the current element to the right
  - Use when the collection is small in size or partially sorted
  - Time complexity: `O(n^2)`

  ```
  int[] nums = new int[] { 7, 3, 1, 2, 4, 6 };
  for (int i = 0; i < nums.Length - 1; i++)
  {
      for (int j = i + 1; j > 0; j--)
      {
          if (nums[j - 1] > nums[j])
          {
              int temp = nums[j];
              nums[j] = nums[j - 1];
              nums[j - 1] = temp;
          }
          else
          {
              break;
          }
      }
  }
  ```
</details>

<details>
<summary>Cyclic Sort</summary>

  - Specifically for arrays containing integers in a specific range
  - Iterate through the array and place each element in its correct position by swapping elements cyclically
  - Time complexity: `O(n^2)`

  ```
  // smallest zero
  int[] numbers = new int[] { 3, 5, 0, 2, 4, 1, 6 };

  int i = 0;
  while (i < numbers.Length)
  {
      if (numbers[i] != i)
      {
          int keep = numbers[numbers[i]];
          numbers[numbers[i]] = numbers[i];
          numbers[i] = keep;
  
          //int keep = numbers[i];
          //numbers[i] = numbers[numbers[i]];
          //numbers[keep] = keep;
          continue;
      }
      i++;
  }
  ```
  ```
  // smallest one
  int[] numbers = new int[] { 3, 5, 7, 2, 4, 1, 6 };

  int i = 0;
  while (i < numbers.Length)
  {
      if (numbers[i] != i + 1)
      {
          // OPTION 1
          // keep other, update other, update current
  
          //int keep = numbers[numbers[i] - 1];
          //numbers[numbers[i] - 1] = numbers[i];
          //numbers[i] = keep;
  
          // OPTION 2
          // keep current, update current, update other
          int keep = numbers[i];
          numbers[i] = numbers[numbers[i] - 1];
          numbers[keep - 1] = keep;
          continue;
      }
      i++;
}
  ```
</details>

<!--

<details>
<summary>Topit Title</summary>

  - Notes: 
  - More notes: 

  ```
  code
  ```
</details>

-->