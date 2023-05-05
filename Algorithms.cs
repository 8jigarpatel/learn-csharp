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
            SelectionSort
        }

        private static SubArea subArea = SubArea.BubbleSort;

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
                default:
                    Console.WriteLine("Invalid `{0}` selected.", nameof(subArea));
                    break;
            };
        }

        #region 
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
            string strArr = string.Join(", ", arr);
            Console.WriteLine($"START BubbleSort: {strArr}");
            int iPassCount = 0;
            int jPassCount = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                bool swapped = false;
                iPassCount++;
                for (int j = 1; j < arr.Length - i; j++)
                {
                    jPassCount++;
                    if (arr[j] < arr[j - 1])
                    {
                        swapped = true;
                        int temp = arr[j - 1];
                        arr[j - 1] = arr[j];
                        arr[j] = temp;
                    }
                }

                if (!swapped)
                {
                    break;
                }
            }
            Console.WriteLine($"END BubbleSort, it used {iPassCount}-{jPassCount} passes, sorted array: {string.Join(", ", arr)}.");
        }
        #endregion
    }
}
