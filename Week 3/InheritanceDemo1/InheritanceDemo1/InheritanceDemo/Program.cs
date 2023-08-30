using System;

namespace InheritanceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            /* <example>

            Animal a1 = new Animal();
            a1.Speak();
    
            Animal a2 = new Animal("Daisy");
            a2.Speak();
            */

            Animal a3 = new Cat("Fluffy");
            a3.Speak();

            a3.Hide();

            Cat a4 = new("Inky");
            a4.Speak();

            a4.Hide();

            a3 = a4;
            a3.Hide();

            Animal d1 = new Dog();
            d1.Speak();
            d1.Hide();
            Dog d2 = (Dog)d1;
            d2.Hide();

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

/*
    Output:

    Fluffy says: Mecom
    inside Animal
    inside Animal
    Inky says: Mecom
    inside Animal
    inside Cat
    inside Animal
    unknown says: Bark
    inside Animal
    inside Animal
    inside Animal

    Press any key to exit.
 */
