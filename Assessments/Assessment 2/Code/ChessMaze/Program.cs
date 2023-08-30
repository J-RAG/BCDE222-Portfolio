using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChessMaze
{
    class Program
    {
        static readonly Level _myLevel = new("Test Level", 4, 4);
        // List<object> is The MoveHistory (a,b)
        // a = Board b = PLay Position 
        static readonly Game _game = new(_myLevel, new List<object>()); 

        static void Main(string[] args)
        {
            // Display Level Name
            Console.WriteLine(_myLevel.Name);

            // Load Level
            _game.Load(_myLevel);

            // Start the Game
            while (!_game.IsFinished())
            {
                var action = _game.Action("Please input your next move ('h' for options): ");
                _game.RunAction(action);
                if (action.ToLower() == "q")
                { 
                    break; // Quit Game Option
                }
                else
                {
                    // if action == a number OR something else
                    // run code that does move(); stuff
                    //
                    //

                    // use IsFinished() as the last line
                }

            }
            _game.End();
        }
    }

}