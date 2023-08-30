using System.Text.RegularExpressions;

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

/*            _view.Display($"Question 16");
            _stringy.setString(_view.GetString("Enter a String: "));
            _view.Display($"The Reverse String of {_stringy._input} is {_stringy.ReverseString()}");
            _view.Display("\n");*/

            _view.Display($"Question 16");
            while (_stringy._input == null || _stringy._input == "0") 
            {
                _stringy.setString(_view.GetString
                    (
                        "Enter your Name to convert to digits\n" +
                        "or Enter 0 to display the StringToDigits Map: "
                    ));

                // Display Map
                if (_stringy._input == "0") 
                {
                    _view.Display(string.Join(", ", _stringy.GetCharToDigitMap()));
                }

                // Display String to Digits
                else 
                {
                    _view.Display(_stringy.StringToDigits());
                    _view.Display("\n");
                }

                _view.Display("\n");
            }

            _view.Stop();


        }
    }
}
