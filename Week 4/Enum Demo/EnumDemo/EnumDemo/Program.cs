using System;

// The enum keyword is used to declare an enumeration, a distinct type that consists of a set of
// named constants called the enumerator list
namespace EnumDemo
{
    // internal is the default access modifier for class declaration
    class Program
    {
        // It is really just mapping a name to a value (an int, unless specified otherwise).
        /* 
         * By default, the associated constant values of enum members are of type int; 
         * they start with zero and increase by one following the definition text order.
         */
        enum Day { Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday };

        // can explicitly specify any other integral numeric type as an underlying type of an enumeration type.
        // Integral numeric types (C# reference)
        // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types
        // The types for an enum are byte, sbyte, short, ushort, int, uint, long, or ulong.
        enum Month : byte { Jan, Feb, Mar, Apr, May, Jun, Jul, Aug, Sep, Oct, Nov, Dec };

        // can also explicitly specify the associated constant values
        // Enumerators can use initializers to override the default values
        enum Vertical { Up = 1, Stay = 0, Down = -1 };

        // An enum can't contain the same value twice.
        public enum BikeBrand
        {
            Aist,
            Bmc,
            Electra = 42,
            Gitane // 43
        }
        // We defined this type inside the Program class, so it is a nested type
        // Code outside of this class should reference this type as Program.BikeBrand

        /*
        Enumeration types as bit flags
        https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/enum
        If you want an enumeration type to represent a combination of choices, define enum members for those 
        choices such that an individual choice is a bit field. That is, the associated values of those enum 
        members should be the powers of two. Then, you can use the bitwise logical operators | or & to combine 
        choices or intersect combinations of choices, respectively. To indicate that an enumeration type 
        declares bit fields, apply the Flags attribute to it.
        */
        // Decorate an enum with the FlagsAttribute to indicate that multiple values can be switched on
        // Any class derived from Attribute can be used to decorate types, methods, parameters etc

        // FlagsAttribute in System namespace
        // Note that [Flags] by itself doesn't change this at all - all it does is enable a nice
        // representation by the .ToString() method
        // https://stackoverflow.com/questions/8447/what-does-the-flags-enum-attribute-mean-in-c
        [Flags]
        // The prefix 0x or 0X to denote a hexadecimal literal        
        enum State { Movable = 0x01, Target = 0x02 };

        // Binary OR Operator copies a bit if it exists in either operand.
        static State Options = State.Movable | State.Target;

        static void Adjust(Vertical where)
        {
            Console.WriteLine(where);
        }

        /* 
         * The Main method is the entry point of an executable program; it is where the program control starts
         * and ends. Main is declared inside a class or struct. Main must be static and it need not be public.
         * The Main method can be declared with or without a string[] parameter that contains command-line arguments.
         * https://docs.microsoft.com/en-us/dotnet/csharp/fundamentals/program-structure/main-command-line
         */
        // private is the default access modifier for class members
        static void Main()
        {
            Day today = Day.Monday;
            int dayNumber = (int)today;
            Console.WriteLine($"{today} is day number #{dayNumber}.");

            Month thisMonth = Month.Dec;
            byte monthNumber = (byte)thisMonth;
            Console.WriteLine($"{thisMonth} is month number #{monthNumber}.");

            // Output:
            // Monday is day number #1.
            // Dec is month number #11.

            int x = 0;
            Console.WriteLine(Vertical.Up);     // Up
            Adjust(Vertical.Stay);              // Stay

            // The underlying type specifies how much storage is allocated for each enumerator. 
            // However, an explicit cast is necessary to convert from enum type to an integral type.
            x += (int)Vertical.Up;
            // x += (int)Vertical.Down;
            Console.WriteLine(x);               // 1

            // Because the Flags attribute is specified, Console.WriteLine displays
            // the name of each enum element that corresponds to a flag that has
            // the value 1 in variable Options.
            Console.WriteLine(Options);         // Movable, Target
            Console.WriteLine((int)Options);    // 3

            // Keep the console window open in debug mode.
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }
    }
}
