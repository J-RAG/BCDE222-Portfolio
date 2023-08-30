using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkExercise1
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
            _view.Display($"Week 1 Homework:\n");


            _view.Display($"Question 4");
            _view.Display($"The sum of numbers 1, 2... 100 is {_loop.CalcSum()}");
            _view.Display("\n");

            _view.Display($"Question 5");
            _view.Display($"The sum of numbers 1, 2... 100 is {_loop.CalcSumWhileDo()}");
            _view.Display("\n");

            _view.Display($"Question 6");
            _view.Display($"The sum of numbers 1, 2... 100 is {_loop.CalcSumDoWhile()}");
            _view.Display("\n");

            _view.Display($"Question 7");
            _view.Display($"The Average of numbers 111-8989 is {_loop.CalcSumAverage(111, 8989)}");
            _view.Display("\n");

            _view.Display($"Question 8");
            _view.Display($"The Average of numbers 1-100 excluding even numbers is {_loop.CalcSumAverageOddsOnly(1, 100)}");
            _view.Display("\n");

            _view.Display($"Question 9");
            _view.Display($"The Average of numbers 1-100 that are Divisble by 7 is {_loop.CalcSumAverageDivSeven(1, 100)}");
            _view.Display("\n");

            _view.Display($"Question 10");
            _view.Display($"The Sum of Squares from numbers 1-100 is {_loop.CalcSumOfSquares(1, 100)}");
            _view.Display("\n");


            _view.Stop();   

        
        }
    }
}
