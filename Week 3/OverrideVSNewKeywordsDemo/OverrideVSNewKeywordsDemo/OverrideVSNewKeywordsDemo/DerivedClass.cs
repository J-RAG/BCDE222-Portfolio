using System;

namespace DemoOverrideVSNewKeywords
{
    class DerivedClass : BaseClass
    {
        public sealed override void Method1()
        {
            Console.WriteLine("Derived - override Method1");
        }

        public new void Method2()
        {
            Console.WriteLine("Derived - new Method2");
        }
    }
}
