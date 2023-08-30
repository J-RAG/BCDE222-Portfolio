using System;

namespace InheritanceDemo
{
    class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        //new public void Speak()

        /* 
         * override modifier is required to extend or modify the abstract or 
         * virtual implementation of an inherited method, property, indexer, or event.
         */
        sealed override public void Speak()
        {
            /*
            base.Speak();
            Console.WriteLine(Name + " says: Mecom");
            */

            Console.WriteLine(Name + " says: Mecom");
            base.Hide();
        }

        public new void Hide()
        {
            Console.WriteLine("inside Cat");
        }
    }
}
