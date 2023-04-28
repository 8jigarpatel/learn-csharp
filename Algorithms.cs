using System;

namespace learn_csharp
{
    internal class Algorithms
    {
        enum SubArea
        {
            Undefined,
            LinearSearch
        }

        private static SubArea subArea = SubArea.LinearSearch;

        public static void Start()
        {
            Console.WriteLine("Running: {0}\n", subArea);
            switch (subArea)
            {
                case SubArea.LinearSearch:
                    LinearSearch();
                    break;
                default:
                    Console.WriteLine("Invalid `{0}` selected.", nameof(subArea));
                    break;
            };
        }

        public static void LinearSearch()
        {

        }
    }
}
