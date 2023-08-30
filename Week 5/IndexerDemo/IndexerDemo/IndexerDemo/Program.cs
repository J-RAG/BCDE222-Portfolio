using System;

namespace IndexerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Local variables can be declared without giving an explicit type. 
             * The var keyword instructs the compiler to infer the type of the 
             * variable from the expression on the right side of the 
             * initialization statement. The inferred type may be a built-in type, 
             * an anonymous type, a user-defined type, or a type defined in the
             * .NET Framework class library.
             */
            var stringCollection = new SampleCollection<string>();

            stringCollection[0] = "Hello, World";
            Console.WriteLine(stringCollection[0]);

            stringCollection.Add("Hello, BCDE222");
            Console.WriteLine(stringCollection[1]);
            /* Expected output:
            Hello, World
            Hello, BCDE222
            */

            // Keep the console window open in debug mode.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
