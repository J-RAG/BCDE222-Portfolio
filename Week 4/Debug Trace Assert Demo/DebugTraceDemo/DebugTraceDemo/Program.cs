using System;
using System.Diagnostics;

namespace DebugTraceDemo
{
    class Program
    {
        static void Main()
        {
            // An assertion, or Assert statement, tests a condition, which you specify as an argument to the Assert statement.
            // If the condition evaluates to true, no action occurs. If the condition evaluates to false, the assertion fails.
            // If you are running with a debug build, your program enters break mode.

            // When you run this code in Debug build, the assertion statement is evaluated,
            // but in the Release build, the comparison is not made, so there is no additional overhead.
            // The reason is that Debug class methods are not included in a Release version of your program,
            // so they do not increase the size or reduce the speed of your release code.
            Debug.Assert(2 == 5);
            Debug.Assert(2 != 5);
            Debug.Assert(2 == 5, "2 is 5?");
            Debug.Assert(2 == 5, "2 is 5?", "2 is really should be 5?");
            Debug.Assert(2 == 5, "2 is 5?", "{0} tested has msg {0} and detailed {0}", "2 is really should be 5?");

            // do not call method in Debug.Assert to avoid side effects
            /*
            bool expected = true;
            bool actual = CounterSampleCalculator();
            Debug.Assert(expected == actual);
            */

            // Use the Trace.Assert method if you want to do assertions in release builds. 
            //Trace.Assert(3 == 5, "3 is 5?");

            // Keep the console window open in debug mode.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
