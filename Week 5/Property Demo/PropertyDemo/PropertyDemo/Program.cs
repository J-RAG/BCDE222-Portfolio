using System;

namespace PropertyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Sumer s = new();
            // s.SetN(12.34);
            // s.N = 12.34;

            // Console.WriteLine(s.GetN());
            Console.WriteLine(s.N);
            Console.WriteLine(s.Name);
            s.Name = "Ara";
            Console.WriteLine(s.Name);
            Console.WriteLine();
            /* expected output:
            0
            Microsoft Visual Studio
            Ara
            */

            Console.WriteLine(s.Damage);
            Console.WriteLine(s.Label);
            Console.WriteLine(s.GenieName);
            s.PrintDamageValue();
            Console.WriteLine();


            // SaleItem objects are now initialized with a call to the default parameterless constructor
            // and an object initializer
            var item = new SaleItem { Name = "Shoes", Price = 19.95m, Quantity = 2 };

            // https://docs.microsoft.com/en-us/dotnet/standard/base-types/standard-numeric-format-strings#standard-format-specifiers
            // A standard numeric format string takes the form [format specifier][precision specifier]
            // The Currency ("C") Format Specifier.
            // Precision specifier is 2
            Console.WriteLine($"{item.Name}: sells for {item.Price:C2}");
            Console.WriteLine();
            /* expected output:
            Shoes: sells for $19.95
            */

            item.Name = "Books";
            /*
             * error: Init-only property or indexer 'ISomething.Property' can only be assigned in an object initializer, 
             * or on 'this' or 'base' in an instance constructor or an 'init' accessor.
             */
            // item.Quantity = 4;


            // Keep the console window open in debug mode.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}