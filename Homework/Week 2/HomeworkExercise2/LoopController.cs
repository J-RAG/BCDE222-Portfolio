using HomeworkExercise2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace HomeworkExercise2
{
    class LoopController
    {
        private readonly IView _view;
        private Loops _loop;

        public LoopController(IView view, Loops loop)
        {
            _view = view;
            _loop = loop;
        }

        public void Go()
        {
            _view.Start();
            _view.Display($"Week 2 Homework:\n");


            _view.Display($"Question 11");
            _view.Display($"The Product of integers from numbers 1-10 is {_loop.CalcProduct(1, 10)}");
            _view.Display($"The Product of integers from numbers 1-11 is {_loop.CalcProduct(1, 11)}");
            _view.Display($"The Product of integers from numbers 1-12 is {_loop.CalcProduct(1, 12)}");
            _view.Display($"The Product of integers from numbers 1-13 is {_loop.CalcProduct(1, 13)}");
            _view.Display($"The Product of integers from numbers 1-14 is {_loop.CalcProduct(1, 14)}");
            _view.Display($"The pattern shows that it multiplies the previous calculation by the next max number.\n");
            _view.Display($"{_loop.CalcProduct(1, 10)} * 11 = {_loop.CalcProduct(1, 10) * 11}");
            _view.Display($"{_loop.CalcProduct(1, 11)} * 12 = {_loop.CalcProduct(1, 11) * 12}");
            _view.Display($"{_loop.CalcProduct(1, 12)} * 13 = {_loop.CalcProduct(1, 12) * 13}");
            _view.Display($"{_loop.CalcProduct(1, 13)} * 14 = {_loop.CalcProduct(1, 13) * 14}");
            _view.Display("\n");

            _view.Display($"Question 12");
            _view.Display($"The The Sum of Harmonic(50000) from the left to right is {_loop.CalcHarmonicSeriesLeft(50000)}");
            _view.Display($"The The Sum of Harmonic(50000) from the right to left is {_loop.CalcHarmonicSeriesRight(50000)}");
            _view.Display($"The left approach is more accurate. When starting at the\n" +
                          $"right side, 1 /50000 is such a small number that the \n" +
                          $"computer itself cannot accurately record it. Hence why\nit stays at 0.");
            _view.Display("\n");

            _view.Display($"Question 13");
            _view.Display($"My Pi Function calculates Pi to: {_loop.PiCalculator(10000000):F15}");
            _view.Display($"The Built in Math.Pi value is  : {Math.PI}");
            _view.Display($"\nThe Termination of the computation stops at the millionth iteration." +
                          $"\nThe Following series is a suitable calculation of PI but the" +
                          $"\naccuracy is reduced based on the the limit of iterations are made.");
            _view.Display("\n");

            _view.Display($"Question 14");
            _view.Display($"The first 20 Fibonacci numbers are: ");
            _view.Display($"{string.Join(", ",_loop.FibonacciSeries(20))}");
            _view.Display($"The average is {_loop.SeriesAverage(_loop.FibonacciSeries(20))}");
            _view.Display("\n");

            _view.Display($"Question 15");
            _view.Display($"The first 20 Tribonacci numbers are: ");
            _view.Display($"{string.Join(", ", _loop.TribonacciSeries(20))}");
            _view.Display($"The average is {_loop.SeriesAverage(_loop.TribonacciSeries(20))}");
            _view.Display("\n");

            _view.Stop();


        }
    }
}
