using System;

namespace DemoOverrideVSNewKeywords
{
    class Program
    {
        static void Main(string[] args)
        {
            BaseClass bc = new();
            DerivedClass dc = new();
            BaseClass bcdc = new DerivedClass();        // upcasting
            //BaseClass bcdc = new DerivedDerivedClass();        // upcasting

            // The following two calls do what you would expect. They call  
            // the methods that are defined in BaseClass.  
            bc.Method1();
            bc.Method2();
            // Output:  
            // Base - virtual Method1
            // Base - non-virtual Method2

            // The following two calls do what you would expect. They call  
            // the methods that are defined in DerivedClass.  
            dc.Method1();
            dc.Method2();
            // Output:  
            // Derived - override Method1
            // Derived - new Method2

            // The following two calls produce different results, depending   
            // on whether override (Method1) or new (Method2) is used.  
            bcdc.Method1();
            bcdc.Method2();
            // Output:  
            // Derived - override Method1
            // Base - non-virtual Method2

            DerivedClass adc = (DerivedClass)bcdc;    // downcasting
            adc.Method1();
            adc.Method2();
            // Output:
            // Derived - override Method1
            // Derived - new Method2

            HoldResultConsoleWindow();
        }

        private static void HoldResultConsoleWindow()
        {
            // Keep the console window open in debug mode.
            /* 
               local constant still uses PascalCase
               https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/const
             */
            const string Value = "\n" + "Press any key to exit.";
            Console.WriteLine(Value);
            Console.ReadKey();
        }
    }
}
