using System.Text.RegularExpressions;
using System.Linq;
using System;
namespace HomeworkExercise4
{
    class MethodsController
    {
        private readonly IView _view;
        private Methods _methods;

        public MethodsController(IView view, Methods methods)
        {
            _view = view;
            _methods = methods;
        }

        public void Go()
        {
            _view.Start();
            _view.Display($"Week 4 Homework:\n");
            /*
                        // Question 20
                        _view.Display($"Question 20");

                        _methods.SetString(_view.GetString("Enter the number of students: "));

                        while (!_methods._input.All(char.IsDigit)) // Not numeric
                        {
                            _view.Display("Invalid Input. Try Again");
                            _methods.SetString(_view.GetString("Enter the number of students: "));

                        }
                        // Display stats
                        _view.Display($"{Methods.GetGradeStats(int.Parse(_methods._input))}");
                        _view.Display("\n");
            */

            // Question 21
            _view.Display($"Question 21");

            _view.Display($"MyArray  :{string.Join(", ", (new int[] { 12, 56, 34, 79, 26, 22 }))}");
            _view.Display($"Reversed :{string.Join(", ", Methods.ReverseMyArray(new int[] { 12, 56, 34, 79, 26, 22 }))}");
            _view.Display("\n");

            /*          
                       // Question 22
                       _view.Display($"Question 22");
                       _view.Display($"{Methods.NumberGuess()}");
                       _view.Display("\n");

                       
            */
            // Question 23
            /*            _view.Display($"Question 23");
                        _view.Display($"{Methods.WordGuess("Testing")}");
                        _view.Display("\n");*/
            _view.Stop();

        }
    }
}
