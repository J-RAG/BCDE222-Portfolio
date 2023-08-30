using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkExercise1
{
    class ConditionalController
    {
        private readonly IView _view;
        private Conditonals _conditonals;

        public ConditionalController(IView view, Conditonals conditonals)
        {
            _view = view;
            _conditonals = conditonals;
        }

        public void Go()
        {
            _view.Start();
            _view.Display("Question 1:");
            _view.Display($"Your grade is 50 you are given a {_conditonals.CheckMark(50)} grade.");
            _view.Display($"Your grade is 49 you are given a {_conditonals.CheckMark(49)} grade.");
            _view.Display("");

            _view.Display("Question 2:");
            _view.Display($"The number 23454231 is a {_conditonals.IsOddNumber(2345321)}");
            _view.Display($"The number 0 is an {_conditonals.IsOddNumber(0)}");
            _view.Display("");

            _view.Display("Question 3:");
            for (int i = 0; i < 10; i++) 
            {
                _view.Display($"{i} is {Conditonals.NumberName(i)} in word form");
            }
            _view.Display($"10 is outside the range for this program. It will be classified as: \"{Conditonals.NumberName(10)}\".");
            _view.Display($"100 is outside the range for this program. It will be classified as: \"{Conditonals.NumberName(100)}\".");
            _view.Stop();

        }
    }
}
