using System;

namespace DemoOverrideVSNewKeywords
{
    class BaseClass
    {
        public virtual void Method1()
        {
            Console.WriteLine("Base - virtual Method1");
        }

        public void Method2()
        {
            Console.WriteLine("Base - non-virtual Method2");
        }
    }
}
