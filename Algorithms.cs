using System;
using System.Collections.Generic;
using System.Globalization;

namespace learn_csharp
{
    internal class Algorithms
    {
        enum SubArea
        {
            Undefined,
            LinearAndBinarySearch,
            BubbleSort,
            SelectionSort,
            InsertionSort,
            CyclicSort
        }

        private static SubArea subArea = SubArea.CyclicSort;

        public static void Start()
        {
            Console.WriteLine("Running: {0}\n", subArea);
            switch (subArea)
            {
                case SubArea.LinearAndBinarySearch:
                    LinearAndBinarySearch();
                    break;
                case SubArea.BubbleSort:
                    BubbleSort();
                    break;
                case SubArea.SelectionSort:
                    SelectionSort();
                    break;
                case SubArea.InsertionSort:
                    InsertionSort();
                    break;
                case SubArea.CyclicSort:
                    CyclicSort();
                    break;
                default:
                    Console.WriteLine("Invalid `{0}` selected.", nameof(subArea));
                    break;
            };
        }

        #region LinearAndBinarySearch
        private static void LinearAndBinarySearch()
        {
            int[] numbers1 = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] numbers2 = { 3, 2, 5, 4, 7, 1, 9 };
            int[] numbers3 = { 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] numbers4 = { 0, 1, 2, 3, 4, 5 };
            Console.WriteLine($"numbers1: {string.Join(", ", numbers1)}");
            Console.WriteLine($"numbers2: {string.Join(", ", numbers2)}");
            Console.WriteLine($"numbers3: {string.Join(", ", numbers3)}");
            Console.WriteLine($"numbers4: {string.Join(", ", numbers4)}");
            Console.WriteLine("---");
            Console.WriteLine($"PerformLinearSearch(numbers1, 9): {PerformLinearSearch(numbers1, 9)}"); // 9
            Console.WriteLine($"PerformLinearSearch(numbers2, 5): {PerformLinearSearch(numbers2, 5)}"); // 2
            Console.WriteLine($"PerformLinearSearch(numbers2, 6): {PerformLinearSearch(numbers2, 6)}"); // -1
            Console.WriteLine("---");
            Console.WriteLine($"PerformBinarySearch(numbers1, 9): {PerformBinarySearch(numbers1, 9)}"); // 9
            Console.WriteLine($"PerformBinarySearch(numbers3, 4): {PerformBinarySearch(numbers3, 4)}"); // 1
            Console.WriteLine($"PerformBinarySearch(numbers3, 1): {PerformBinarySearch(numbers3, 1)}"); // -1
            Console.WriteLine($"PerformBinarySearch(numbers4, 5): {PerformBinarySearch(numbers4, 5)}"); // 5
        }

        private static int PerformLinearSearch(int[] numbers, int target)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == target)
                {
                    return i;
                }
            }
            return -1;
        }

        private static int PerformBinarySearch(int[] numbers, int target)
        {
            int start = 0;
            int end = numbers.Length - 1; // !!! - 1 (because start <= end)
            while (start <= end)
            {
                int middle = start + (end - start) / 2;
                if (numbers[middle] < target) { start = middle + 1; }
                else if (numbers[middle] > target) { end = middle - 1; }
                else return middle;
            }
            return -1;
        }
        #endregion

        #region BubbleSort
        private static void BubbleSort()
        {
            BubbleSortArray(new int[] { 1, 2, 3, 4, 5 });
            BubbleSortArray(new int[] { 5, 4, 3, 2, 1 });
            BubbleSortArray(new int[] { 5, 4, 3, -1, 9, 5, 2, 3, 2, -1, 8, 9, -1, 9, 7, 1 });
        }

        private static void BubbleSortArray(int[] arr)
        {
            int[] inputArr = new int[arr.Length];
            arr.CopyTo(inputArr, 0);

            // 1 6 9 8 7 2 5
            // 1 6 8 7 2 5 9
            // 1 6 7 2 5 8 9
            // 1 6 2 5 7 8 9
            // 1 2 5 6 7 8 9
            int countMain = 0;
            int countSub = 0;
            for (int i = 0; i < arr.Length - 1; i++) // if length is 5, iterate 4 times (i: 0, 1, 2, 3)
            {
                countMain++;
                bool swapped = false;
                for (int j = 1; j < arr.Length - i; j++) // start at 1 (to compare element at 1 and 0, and... go until length - i (i.e., depending on 'i' in the main loop - which pass))
                {
                    countSub++;
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
            Console.WriteLine($"Array ({string.Join(", ", inputArr)}) sorted in {countMain}-{countSub} passes to: {string.Join(", ", arr)}");
        }
        #endregion

        #region SelectionSort
        private static void SelectionSort()
        {
            SelectionSortArray(new int[] { 1, 2, 3, 4, 5 });
            SelectionSortArray(new int[] { 5, 1, 2, 3, 4 });
        }

        private static void SelectionSortArray(int[] nums)
        {
            int[] inputArr = new int[nums.Length];
            nums.CopyTo(inputArr, 0);


            // 5 3 1 2 4
            int passCount = 0;
            for (int i = 0; i < nums.Length - 1; i++) //  !!! -1 
            {
                passCount++;
                int maxIndex = SelectionSortGetMaxIndex(nums, 0, nums.Length - 1 - i); // find max element's index
                if (nums[maxIndex] > nums[nums.Length - 1 - i]) // if max element is bigger than "current pass's" last element, swap them
                {
                    int temp = nums[maxIndex];
                    nums[maxIndex] = nums[nums.Length - 1 - i];
                    nums[nums.Length - 1 - i] = temp;
                }
            }

            Console.WriteLine($"Array ({string.Join(", ", inputArr)}) sorted in {passCount} passes: {string.Join(", ", nums)}");
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
        #endregion

        #region InsertionSort
        private static void InsertionSort()
        {
            int[] arr1 = { 7, 3, 1, 2, 4, 6 };
            int[] arr1Copy1 = new int[arr1.Length];
            int[] arr1Copy2 = new int[arr1.Length];
            arr1.CopyTo(arr1Copy1, 0);
            arr1.CopyTo(arr1Copy2, 0);
            InsertionSortArray(arr1);
            InsertionSortArray2(arr1Copy1);
            InsertionSortArray3(arr1Copy2);

            int[] arr2 = { -7, 3, -1, 2, 4, -6 };
            int[] arr2Copy1 = new int[arr1.Length];
            int[] arr2Copy2 = new int[arr1.Length];
            arr2.CopyTo(arr2Copy1, 0);
            arr2.CopyTo(arr2Copy2, 0);
            InsertionSortArray(arr2);
            InsertionSortArray2(arr2Copy1);
            InsertionSortArray3(arr2Copy2);
        }

        private static void InsertionSortArray(int[] array)
        {
            int[] originalArr = new int[array.Length];
            array.CopyTo(originalArr, 0);

            // 7, 3, 1, 2, 4, 6
            // 3 7 1 2 4 6
            // 3 1 7 2 4 6
            // 1 3 
            Console.WriteLine($"Start : {string.Join(", ", originalArr)}");
            int passCount = 0;
            for (int i = 1; i < array.Length; i++)
            {
                int j = i - 1;
                while (j >= 0 && array[j] > array[j + 1])
                {
                    passCount++;
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    j--;
                    Console.WriteLine($"Pass {passCount}: {string.Join(", ", array)}");
                }
            }
            Console.WriteLine($"Array ({string.Join(", ", originalArr)}) sorted in {passCount} passes: {string.Join(", ", array)}");
        }

        private static void InsertionSortArray2(int[] nums)
        {
            int[] originalNums = new int[nums.Length];
            nums.CopyTo(originalNums, 0);

            int passCount = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                //int j = i + 1;
                //while (j > 0 && nums[j] < nums[j-1])
                //{
                //    passCount++;
                //    int temp = nums[j];
                //    nums[j] = nums[j - 1];
                //    nums[j - 1] = temp;
                //    j--;
                //}

                for (int j = i + 1; j > 0; j--)
                {
                    if (nums[j] < nums[j - 1])
                    {
                        passCount++;
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

            Console.WriteLine($"Array ({string.Join(", ", originalNums)}) sorted in {passCount} passes: {string.Join(", ", nums)}");
        }

        private static void InsertionSortArray3(int[] arr)
        {
            int[] arr1 = new int[arr.Length];
            arr.CopyTo(arr1, 0);
            int[] arr2 = new int[arr.Length];
            arr.CopyTo(arr2, 0);

            Console.WriteLine($"IS initial array: {string.Join(", ", arr)}");

            int passCount1 = 0;
            // 7 4 2 1 5 3
            for (int i = 0; i < arr1.Length - 1; i++)
            {
                int j = i;
                while (j >= 0 && arr1[j + 1] < arr1[j])
                {
                    passCount1++;
                    int temp = arr1[j];
                    arr1[j] = arr1[j + 1];
                    arr1[j + 1] = temp;
                    j--;
                }
            }
            Console.WriteLine($"01 sorted array in {passCount1} passes: {string.Join(", ", arr1)}");

            int passCount2 = 0;
            // 5 2 1 4 3
            for (int i = 0; i < arr2.Length - 1; i++)
            {
                for (int j = i; j >= 0; j--)
                {
                    if (arr2[j + 1] < arr2[j])
                    {
                        int temp = arr2[j + 1];
                        arr2[j + 1] = arr2[j];
                        arr2[j] = temp;
                        passCount2++;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Console.WriteLine($"02 sorted array in {passCount2} passes: {string.Join(", ", arr2)}");
        }
        #endregion

        #region CyclicSort
        private static void CyclicSort()
        {
            CyclicSortSmallestZero(new int[] { 3, 5, 0, 2, 4, 1, 6 });
            CyclicSortSmallestZero(new int[] { 3, 0, 1, 2, 4 });
            Console.WriteLine($"-- -- -- -- --");
            CyclicSortSmallestOne(new int[] { 3, 5, 7, 2, 4, 1, 6 });
            CyclicSortSmallestOne(new int[] { 3, 5, 1, 2, 4 });
            Console.WriteLine($"-- -- -- -- --");
            SmartCyclicSortArray(new int[] { 3, 5, 0, 2, 4, 1, 6 });
            SmartCyclicSortArray(new int[] { 3, 4, 1, -2, -1, 0, 2 });
            Console.WriteLine($"-- -- -- -- --");
            CyclicSortArrayWithFirst(new int[] { 1, 4, 3, 6, 2, 5 }, 1);
            CyclicSortArrayWithFirst(new int[] { 0, 3, 1, 2, 4 }, 0);
            CyclicSortArrayWithFirst(new int[] { 0, 3, 1, 2, -1 }, -1);
            CyclicSortArrayWithFirst(new int[] { 0, 3, 1, 2, -1, -2, -5, -3, -4, 9, 6, 8, 5, 7, 4 }, -5);
            Console.WriteLine($"-- -- -- -- --");
            Console.WriteLine(MissingNumber(new int[] { 0, 1, 5, 4, 2 }));
            Console.WriteLine(MissingNumber(new int[] { 0, 1, 8, 4, 2, 6, 3, 9, 5 }));
            Console.WriteLine(MissingNumber(new int[] { 5, 1, 0, 2, 4 }));
            Console.WriteLine(MissingNumber(new int[] { 4, 0, 2, 1 }));
            Console.WriteLine($"-- -- -- -- --");
            LC448(new int[] { 3, 2, 3, 4, 1, 2, 7, 8 });
            LC448(new int[] { 1, 5, 4, 2, 7, 9, 8, 9, 9 });
        }

        private static void CyclicSortSmallestZero(int[] numbers)
        {
            int[] oNumbers = new int[numbers.Length];
            numbers.CopyTo(oNumbers, 0);

            int i = 0;
            while (i < numbers.Length)
            {
                if (numbers[i] != i)
                {
                    //int keep = numbers[numbers[i]];
                    //numbers[numbers[i]] = numbers[i];
                    //numbers[i] = keep;

                    int keep = numbers[i];
                    numbers[i] = numbers[numbers[i]];
                    numbers[keep] = keep;
                    continue;
                }
                i++;
            }

            Console.WriteLine($"CyclicSortSmallestZero({string.Join(",", oNumbers)}): {string.Join(",", numbers)}");
        }

        private static void CyclicSortSmallestOne(int[] numbers)
        {
            int[] oNumbers = new int[numbers.Length];
            numbers.CopyTo(oNumbers, 0);

            // 3 4 1 2
            // 1 4 3 2
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

            Console.WriteLine($"CyclicSortSmallestOne ({string.Join(",", oNumbers)}): {string.Join(",", numbers)}");
        }

        private static void SmartCyclicSortArray(int[] arr)
        {
            int[] oArr = new int[arr.Length];
            arr.CopyTo(oArr, 0);

            int first = int.MaxValue;
            foreach (int n in arr)
            {
                if (n < first) { first = n; }
            }

            // 3, 4, 1, 6, 5, 7, 2
            int passCount = 0;
            int i = 0;
            while (i < arr.Length)
            {
                passCount++;
                if (arr[i] != i + first)
                {
                    //int temp = arr[i];
                    //arr[i] = arr[arr[i] - first];
                    //arr[temp - first] = temp;

                    int temp = arr[arr[i] - first];
                    arr[arr[i] - first] = arr[i];
                    arr[i] = temp;
                    continue;
                }
                i++;
            }
            Console.WriteLine($"SmartCyclicSortArray ({string.Join(", ", oArr)}) sorted in {passCount} passes: {string.Join(", ", arr)}");
        }

        private static void CyclicSortArrayWithFirst(int[] arr, int first)
        {
            int i = 0;
            while (i < arr.Length)
            {
                if (arr[i] != i + first)
                {
                    int temp = arr[arr[i] - first];
                    arr[arr[i] - first] = arr[i];
                    arr[i] = temp;
                    continue;
                }
                i++;
            }
            Console.WriteLine($"Sorted: {string.Join(",", arr)}");
        }

        private static int MissingNumber(int[] nums)
        {
            int i = 0;
            while (i < nums.Length)
            {
                // 1 3 0 2 4
                if (nums[i] < nums.Length && nums[i] != i)
                {
                    int keep = nums[nums[i]]; // 3
                    nums[nums[i]] = nums[i];
                    nums[i] = keep;
                    continue;
                }
                i++;
            }

            Console.WriteLine($"S: {string.Join(", ", nums)}");

            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j) { return j; }
            }

            return nums.Length;
            //int i = 0;
            //while (i < nums.Length)
            //{
            //    if (nums[i] < nums.Length && nums[i] != nums[nums[i]])
            //    {
            //        int temp = nums[nums[i]];
            //        nums[nums[i]] = nums[i];
            //        nums[i] = temp;
            //        continue;
            //    }
            //    i++;
            //}
            //Console.WriteLine($"S: {string.Join(", ", nums)}");

            //// 0 1 3 
            //for (int z = 0; z < nums.Length; z++)
            //{
            //    if (nums[z] != z) { return z; }
            //}
            //return nums.Length;
        }

        private static List<int> LC448(int[] nums)
        {
            List<int> result = new List<int>();
            int i = 0;
            while (i < nums.Length)
            {
                // 3 5 2 1 4

                // if (nums[i] != i + 1)
                // - checks if current element has value that might not exist
                // if (nums[i] != nums[nums[i] - 1])
                // - checks if current element is at the right position
                if (nums[i] != nums[nums[i] - 1])
                {
                    // 2 3 1 5 4
                    int keep = nums[nums[i] - 1]; // 3
                    nums[nums[i] - 1] = nums[i];
                    nums[i] = keep;
                    continue;
                }
                i++;
            }
            for (int j = 0; j < nums.Length; j++)
            {
                if (nums[j] != j + 1)
                {
                    result.Add(j + 1);
                }
            }
            Console.WriteLine($"LC448 Sort: {string.Join(", ", nums)}; and answer is: {string.Join(", ", result)}");
            return result;
        }
        #endregion
    }
}
