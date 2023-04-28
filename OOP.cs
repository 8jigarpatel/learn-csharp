using System;

namespace learn_csharp
{
    internal class OOP
    {
        enum SubArea
        {
            Undefined,
            ClassesAndObjects
        }

        private static SubArea subArea = SubArea.ClassesAndObjects;

        public static void Start()
        {
            Console.WriteLine("Running: {0}\n", subArea);
            switch (subArea)
            {
                case SubArea.ClassesAndObjects:
                    ClassesAndObjects();
                    break;
                default:
                    Console.WriteLine("Invalid `{0}` selected.", nameof(subArea));
                    break;
            };
        }

        private static void ClassesAndObjects()
        {

        }
    }
}
