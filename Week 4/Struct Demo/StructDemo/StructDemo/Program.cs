using System;

namespace StructDemo
{
    class Program
    {
        private static void Main(string[] args)
        {
            // Initialize  
            Coords coords1 = new(), coords2 = new(10, 10);  // Shorthand for multiple declarations

            // Display results:
            /* 
             Output:
             Coords 1: X = 0, Y = 0
             Coords 2: X = 10, Y = 10
            */
            Console.Write($"Coords 1: {coords1}\n");
            Console.Write($"Coords 2: {coords2}\n");


            // Declare an object:
            Coords coords3;

            // If all instance fields of a structure type are accessible, you can also instantiate it without the new
            // operator. In that case you must initialize all instance fields before the first use of the instance.
            coords3.X = 10;
            coords3.Y = 20;

            // Display results:
            // Output: Coords 1: x = 10, y = 20
            Console.Write($"Coords 3: {coords3}\n");

            // Keep the console window open in debug mode.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
