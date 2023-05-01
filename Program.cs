using learn_csharp;
using System;

internal class Program
{
    enum Area
    {
        Undefined,
        Basics,
        DataTypes,
        OOP,
        Algorithms
    }

    private static Area area = Area.Basics;

    private static void Main(string[] args)
    {
        Console.WriteLine("Area: {0}", area);
        switch (area)
        {
            case Area.Basics:
                Basics.Start();
                break;
            case Area.DataTypes:
                DataTypes.Start();
                break;
            case Area.OOP:
                OOP.Start();
                break;
            case Area.Algorithms:
                OOP.Start();
                break;
            default:
                Console.WriteLine("Please update `area` parameter.");
                break;
        };
    }
}
