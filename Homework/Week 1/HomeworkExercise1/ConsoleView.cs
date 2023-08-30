using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkExercise1
{
    class ConsoleView : IView
    {
        public void Display<T>(string message, T value)
        {
            Console.WriteLine(message, value);  
        }

        public void Display<T>(T message)
        {
            Console.WriteLine(message);
        }

        public string GetString(string prompt)
        {
            Console.WriteLine(prompt);
            return Console.ReadLine() ?? string.Empty;
        }

        public void Start()
        {
            Console.Clear();
        }

        public void Stop()
        {
            Console.WriteLine("Press any key to Exit.");
            Console.ReadKey();  
        }
    }
}
