using System;

namespace ToyBoxDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            Box theBox = new();
            Console.WriteLine("empty box");
            Console.WriteLine(theBox);

            Console.WriteLine("\nbox with 1 toy");
            theBox.AddToy("Teddy", "brown", 12.34M);
            Console.WriteLine(theBox);

            Console.WriteLine("\nbox with 2 toys");
            theBox.AddToy("Doll", "pink", 34.56M);
            Console.WriteLine(theBox);

            Console.WriteLine("\nbox with 3 toys");
            theBox.AddToy("Aardvark", "black", 56.78M);
            Console.WriteLine(theBox);

            Console.WriteLine("\nsorted box with 3 toys");
            theBox.SortByName();
            Console.WriteLine(theBox);

            // Keep the console window open in debug mode.
            Console.Write("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}