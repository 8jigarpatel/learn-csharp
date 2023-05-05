using System;
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
            InsertionSort
        }

        private static SubArea subArea = SubArea.InsertionSort;

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

        }
        #endregion
    }
}
