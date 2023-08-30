using System;

namespace InheritanceDemo
{
    class Dog : Animal
    {
        public override void Speak()
        {
            Console.WriteLine(Name + " says: Bark");
            base.Hide();
        }
    }
}
