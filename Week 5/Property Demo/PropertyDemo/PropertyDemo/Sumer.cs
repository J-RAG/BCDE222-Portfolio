// https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/properties

using System;

namespace PropertyDemo
{
    class Sumer
    {
        /* 
        // This is the conventional way to implement a property
        private double _n;
        
        public void SetN(double n)
        {
            this._n = n;
        }

        public double GetN()
        {
            return _n;
        }
        */

        /*
         * One basic pattern for implementing a property involves using a private 
         * backing field for setting and retrieving the property value. 
         */
        private int _n;

        public double N
        {
            get /* ready-only?? */ { return _n; }

            // https://stackoverflow.com/questions/247621/what-are-the-correct-version-numbers-for-c/247623#247623
            set
            {
                /* 
                 * magic word value?? 
                 * The value keyword is used to define the value being assigned by the set accessor.
                 */
                _n = (int)value;
            }
        }

        private string _name = "Microsoft Visual Studio";

        // the read-only Name property as an expression-bodied member since C# 6
        // public string Name => _name;

        /*
         * Starting with C# 7.0, both the get and the set accessor can be implemented as 
         * expression-bodied members. In this case, the get and set keywords must be present. 
         * Note that the return keyword is not used with the get accessor.
         */
        public string Name
        {
            // the use of expression body definitions for both accessors
            get => _name;
            set => _name = value;
        }

        // Autoproperty initializers
        public int Damage { get; private set; } = 10;

        // Autoproperty initializers on getter-only properties
        public string Label { get; } = "Glass ball";

        // Getter-only autoproperty that is initialized in constructor
        public string? GenieName { get; }

        public void PrintDamageValue()
        {
            Console.WriteLine(Damage);
        }
    }
}