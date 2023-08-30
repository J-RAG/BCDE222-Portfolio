using System;

namespace ExceptionDemo
{
    class Program
    {
        static int SafeDivision(int x, int y)
        {
            /*
            if (y == 0)
                throw new System.DivideByZeroException();
            */

            // throw new CustomException("Custom exception in SafeDivision method call");

            return x / y;
        }

        static void Main(string[] args)
        {
            // Input for test purposes. Change the values to see
            // exception handling behavior.
            int a = 98, b = 0;

            //Console.WriteLine(a / b);

            try
            {
                int result = SafeDivision(a, b);

                // String interpolation
                Console.WriteLine($"{a} divided by {b} = {result}");
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Attempted divide by zero.");
                Console.WriteLine($"Error!!!! {e}");
            }
            /*
             * Exception filters can be added a boolean expression to a catch clause. 
             * Exception filters indicate that a specific catch clause matches only 
             * when that condition is true.
             */
            catch (CustomException e) when (a > 100)
            {
                // Code to handle the exception goes here.
                // Only catch exceptions that you know how to handle.
                Console.WriteLine("The value of a cannot be greater than 100!");
                Console.WriteLine($"Error!!!! {e}");
            }
            //  If you catch System.Exception, rethrow it using the throw keyword at the end of the catch block.
            catch
            {
                // log it
                // then re-throw the error.
                throw;
            }
            finally
            {
                // Code to execute after the try (and possibly catch) blocks goes here.
            }

            // Keep the console window open in debug mode.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}

/* Notes that
 * https://stackoverflow.com/questions/881473/why-catch-and-rethrow-an-exception-in-c
Don't do this,

try 
{
    ...
}
catch(Exception ex)
{
   throw ex;
}
You'll lose the stack trace information...

Either do,

try 
{ 
    ... 
}
catch 
{ 
    throw; 
}

OR

try
{
    ...
}
catch (Exception ex)
{
    throw new Exception("My Custom Error Message", ex);
}
 */