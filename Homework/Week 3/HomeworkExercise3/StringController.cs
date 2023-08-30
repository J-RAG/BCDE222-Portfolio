using System.Text.RegularExpressions;
using System.Linq;
using System;
namespace HomeworkExercise3
{
    class StringController
    {
        private readonly IView _view;
        private Stringy _stringy;

        public StringController(IView view, Stringy stringy)
        {
            _view = view;
            _stringy = stringy;
        }

        public void Go()
        {
            _view.Start();
            _view.Display($"Week 3 Homework:\n");

            // Question 16
            _view.Display($"Question 16");
            _stringy.SetString(_view.GetString("Enter a String: "));
            _view.Display($"The Reverse String of {_stringy._input} is {_stringy.ReverseString()}");
            _view.Display("\n");


            // Question 17
            _view.Display($"Question 17");
            _stringy._input = ""; // reset input

            // loop until valid input is entered
            while 
                (
                string.IsNullOrEmpty(_stringy._input) ||
                _stringy._input == "0" ||
                _stringy._input == "1"
                )
            {
                _stringy.SetString(_view.GetString
                    (
                        "Enter your Name to convert to digits\n" +
                        "To display the StringToDigits Map... \n" +
                        "Enter 1: Array Format or Enter 0: List Format\n"
                    ));

                // Display Map
                if (_stringy._input == "0" || _stringy._input == "1")
                {
                    _view.Display("\n");
                    _view.Display($"{_stringy.GetCharToDigitMap()}");
                    _view.Display("\n");

                }

                // Display String to Digits
                else
                {
                    _view.Display(_stringy.StringToDigits());
                    _view.Display("\n");
                }

            }

            // Question 18

            _view.Display($"Question 18");
            while (_stringy._input != "0")
            {
                _stringy.SetString(_view.GetString("Enter a String (Enter 0 to exit): "));
                if (_stringy._input != "0")
                {
                    _view.Display($"{_stringy._input} {_stringy.IsPalindrome()} a Palindrome.");
                    _view.Display("\n");
                }
            }
            _view.Display("\n");

            // Question 19
            _view.Display($"Question 19");
            _stringy.SetString(_view.GetString("Enter the number of students: "));

            while (!_stringy._input.All(char.IsDigit)) // Not numeric
            {
                _view.Display("Invalid Input. Try Again");
                _stringy.SetString(_view.GetString("Enter the number of students: "));

            }
            _view.Display($"The average is {Stringy.GetAverageGrades(Convert.ToInt32(_stringy._input)):F1}");
            _view.Display("\n");

            _view.Stop();


        }
    }
}
