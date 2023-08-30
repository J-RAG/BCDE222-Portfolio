using System;

namespace StringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Char - A single 16-bit Unicode character
            char fooChar = 'A';
            Console.WriteLine(fooChar);

            // Strings are not value types
            // Instead it is a string is a reference type.
            string fooString = "\"escape\" quotes and add \n (new lines) and \t (tabs)";
            Console.WriteLine(fooString);


            // Initialize with a regular string literal
            string s1 = "h:\notes.txt";
            // Initialize with a regular string literal embeding the Backslash escape characters
            string s2 = "h:\\notes.txt";
            // Initialize with a verbatim string literal
            // You can use the @ symbol before a string literal to escape all characters in the string
            string s3 = @"h:\notes.txt";

            Console.WriteLine(s1);
            Console.WriteLine(s2);
            Console.WriteLine(s3);
            Console.WriteLine(s1.Length);
            Console.WriteLine(s2.Length);
            Console.WriteLine(s3.Length);

            /* expected output:
            h:
            otes.txt
            h:\notes.txt
            h:\notes.txt
            11
            12
            12
            */

            string s4 = "A string is more ";

            // You can access each character of the string with an indexer:
            _ = fooString[1]; // => 'e'

            // String objects are immutable: they cannot be changed after they have been created. 
            // s4[0] = "T";

            // Compare strings with current culture, ignoring case
            string.Compare(fooString, "x", StringComparison.CurrentCultureIgnoreCase);

            // Using stringBuilder for fast string creation
            System.Text.StringBuilder sb = new(s4);
            sb[0] = 'C';
            System.Console.WriteLine(sb);

            string s5 = "than the sum of its chars.";

            // Concatenate s1 and s2. This actually creates a new string object and stores it in s4,
            // releasing the reference to the original object.
            s4 += s5;

            System.Console.WriteLine(s4);
            // Output: A string is more than the sum of its chars.

            // Keep the console window open in debug mode.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
