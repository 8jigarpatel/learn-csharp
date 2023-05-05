using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

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
            Console.WriteLine($"numbers1: {string.Join(", ", numbers1)}");
            Console.WriteLine($"numbers2: {string.Join(", ", numbers2)}");
            Console.WriteLine($"numbers3: {string.Join(", ", numbers3)}");
            Console.WriteLine("---");
            Console.WriteLine($"PerformLinearSearch(numbers1, 9): {PerformLinearSearch(numbers1, 9)}"); // 9
            Console.WriteLine($"PerformLinearSearch(numbers2, 5): {PerformLinearSearch(numbers2, 5)}"); // 2
            Console.WriteLine($"PerformLinearSearch(numbers2, 6): {PerformLinearSearch(numbers2, 6)}"); // -1
            Console.WriteLine("---");
            Console.WriteLine($"PerformBinarySearch(numbers1, 9): {PerformBinarySearch(numbers1, 9)}"); // 9
            Console.WriteLine("---");
            Console.WriteLine($"PerformBinarySearch(numbers3, 4): {PerformBinarySearch(numbers3, 4)}"); // 1
            Console.WriteLine("---");
            Console.WriteLine($"PerformBinarySearch(numbers3, 1): {PerformBinarySearch(numbers3, 1)}"); // -1
            Console.WriteLine("---");
            int[] num05 = { 0, 1, 2, 3, 4, 5 };
            Console.WriteLine($"num05: {string.Join(", ", num05)}");
            Console.WriteLine($"PerformBinarySearch(num05, 5): {PerformBinarySearch(num05, 5)}"); // -1
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
            int end = numbers.Length - 1;

            while (start <= end)
            {
                int middle = (start + end) / 2;
                Console.WriteLine($"Scanning range {start} to {end} > by checking middle of {middle}");
                int middleNumber = numbers[middle];
                if (middleNumber == target)
                {
                    return middle;
                }
                else if (middleNumber > target)
                {
                    end = middle - 1;
                }
                else
                {
                    start = middle + 1;
                }
            }
            return -1;
        }
        #endregion

        #region Bubble Sort
        private static void BubbleSort()
        {
            int[] arr1 = { 1, 2, 3, 4, 5 };
            BubbleSortArray(arr1);

            int[] arr2 = { 5, 4, 3, 2, 1 };
            BubbleSortArray(arr2);
        }

        private static void BubbleSortArray(int[] arr)
        {
            int[] inputArr = new int[arr.Length];
            arr.CopyTo(inputArr, 0);

            // 5 4 3 2 1
            int countMain = 0;
            int countSub = 0;
            for (int i = 0; i < arr.Length - 1; i++) // if length is 5, iterate 4 times (i: 0, 1, 2, 3)
            {
                countMain++;
                bool swapped = false;
                for (int j = 1; j < arr.Length - i; j++) // start at 1 (to compare element at 1 and 0, and go until length - i (depending on which pass)
                {
                    countSub++;
                    if (arr[j] < arr[j - 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = temp;
                        swapped = true;
                    }
                }
                if (!swapped) // array is already sorted
                {
                    break;
                }
            }
            Console.WriteLine($"Array ({string.Join(", ", inputArr)}) sorted in {countMain}-{countSub} passes to: {string.Join(", ", arr)}");
        }
        #endregion

        #region Selection sort
        private static void SelectionSort()
        {
            int[] arr1 = { 1, 2, 3, 4, 5 };
            SelectionSortArray(arr1);

            int[] arr5 = { 5, 1, 2, 3, 4 };
            SelectionSortArray(arr5);
        }

        private static void SelectionSortArray(int[] nums)
        {
            int[] inputArr = new int[nums.Length];
            nums.CopyTo(inputArr, 0);

            int passCount = 0;
            for (int i = 0; i < nums.Length - 1; i++)
            {
                passCount++;
                int maxIndex = SelectionSortGetMaxIndex(nums, 0, nums.Length - 1 - i);
                if (nums[maxIndex] > nums[nums.Length - 1 - i])
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
            int[] arr1Copy = new int[arr1.Length];
            arr1.CopyTo(arr1Copy, 0);
            InsertionSortArray(arr1);
            InsertionSortArray2(arr1Copy);

            int[] arr2 = { -7, 3, -1, 2, 4, -6 };
            int[] arr2Copy = new int[arr1.Length];
            arr2.CopyTo(arr2Copy, 0);
            InsertionSortArray(arr2);
            InsertionSortArray2(arr2Copy);
        }

        private static void InsertionSortArray(int[] array)
        {
            int[] originalArr = new int[array.Length];
            array.CopyTo(originalArr, 0);

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
