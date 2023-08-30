using System;

namespace InheritanceDemo
{
    public abstract class Animal
    {
        protected string Name;

        // Method Overloading
        public Animal()
        {
            Setup("unknown");
        }

        public Animal(string name)
        {
            Setup(name);
        }

        public void Setup(string name)
        {
            Name = name;
        }

        /* 
         * By default, methods are non-virtual. You cannot override a non-virtual method.
         * When a virtual method is invoked, the run-time type of the object is checked 
         * for an overriding member. The overriding member in the most derived class is 
         * called, which might be the original member, if no derived class has overridden the member.
         */

        /* 
         * The virtual keyword is used to modify a method, property, indexer, or event 
         * declaration and allow for it to be overridden in a derived class.
         */

        /* 
        public virtual void Speak()
        {
            Console.WriteLine(Name + " says: Ummm");
        }

        public void Speak()
        {
            Console.WriteLine(Name + " says: Ummm");
        }
        */

        abstract public void Speak();

        public void Hide()
        {
            Console.WriteLine("inside Animal");
        }
    }
}
