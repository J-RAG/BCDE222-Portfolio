using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkExercise2
{
    internal interface IView
    {
        void Start();

        void Stop();

        string GetString(string prompt);

        void Display<T>(string message, T value);

        void Display<T>(T message);

    }
}
