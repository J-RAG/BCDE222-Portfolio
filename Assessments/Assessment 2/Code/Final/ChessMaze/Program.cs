using ChessMaze;
using System.Runtime.InteropServices;
using System.Xml.Linq;
using System.Timers;
using System.Threading;


class Program
{
    
    static void Main(string[] args)
    {  
        // Here is a Hard Coded demo 
        // To Demonstrate How it Works
        Game _game = new();
        Demo_UndoFunctionality(_game);
        Demo_CompleteTheGame(_game);
        Demo_CompleteTheGame_KnightPath(_game);
        Demo_LoopThreeTimes(_game);
        Demo_InvalidMovements(_game);

        Console.WriteLine("Press any key to Exit.");
        Console.ReadKey();

    }

    private static void Demo_UndoFunctionality(Game _game)
    {
        // Undo Fucntionality
        Console.WriteLine("Demo: Undo Functionality");
        _game.Load();
        Console.WriteLine(_game.GameLevel.Name);
        _game.PrintBoard();

        _game.Move(Direction.DownRight);
        _game.Move(Direction.Down);
        _game.Move(Direction.DownRight);
        Console.WriteLine("The Following 3 actions are Undo(): ");
        _game.Undo(); // Move Count 2
        _game.Undo(); // Move Count 1
        _game.Undo(); // Move Count 0

        Console.WriteLine("We should be at the start");
        Console.WriteLine("The next undo should give us a cannot undo message");
        Console.WriteLine("Press any key to continue.");


        Console.ReadKey();
        _game.Undo(); // Should not Undo

        Console.WriteLine($"Move Count is: {_game.GetMoveCount()}");
        Console.WriteLine();

        Console.WriteLine("Press any key to Continue.");
        Console.ReadKey();
        Console.Clear();
    }

    private static void Demo_CompleteTheGame(Game _game)
    {
        // Completeing the Game
        _game.Restart();
        Console.WriteLine("Demo: Completing the Game");
        Console.WriteLine(_game.GameLevel.Name);
        _game.PrintBoard();

        _game.Move(Direction.DownRight);
        _game.Move(Direction.DownRight);
        _game.Move(Direction.Down);
        _game.Move(Direction.Right);

        if (_game.IsFinished())
        {
            Console.WriteLine("You Win!");
            Console.WriteLine($"Game Time: {_game.StopTimer()}");
            Console.WriteLine($"Number of Moves: {_game.GetMoveCount()}");

        }

        Console.WriteLine("Press any key to Continue.");
        Console.ReadKey();
        Console.Clear();
    }

    private static void Demo_CompleteTheGame_KnightPath(Game _game)
    {
        // Complete Game >> Knight Path
        Console.WriteLine("Demo: Completeing the Game: Knight Path");
        _game.Restart();
        Console.WriteLine(_game.GameLevel.Name);
        _game.PrintBoard();

        _game.Move(Direction.DownRight);
        _game.Move(Direction.Right);
        _game.Move(Direction.DDRight);

        if (_game.IsFinished())
        {
            Console.WriteLine("You Win!");
            Console.WriteLine($"Game Time: {_game.StopTimer()}");
            Console.WriteLine($"Number of Moves: {_game.GetMoveCount()}");
        }

        // Next Phase
        Console.WriteLine("Press any key to Continue.");
        Console.ReadKey();
        Console.Clear();
    }

    private static void Demo_LoopThreeTimes(Game _game)
    {
        // Complete Game >> Loop 3 Times then finish
        // Tests other Kight Moves
        Console.WriteLine("Demo: Looping 3 times");
        _game.Restart();
        Console.WriteLine(_game.GameLevel.Name);
        _game.PrintBoard();

        // Loop 3 times
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"Loop: {i + 1}");
            _game.Move(Direction.DownRight);
            _game.Move(Direction.Right);
            _game.Move(Direction.LLUp);
        }

        // Reach Goal
        _game.Move(Direction.DownRight);
        _game.Move(Direction.Right);
        _game.Move(Direction.DDRight);

        // Expect moveCount to be 12
        if (_game.IsFinished())
        {
            Console.WriteLine("You Win!");
            Console.WriteLine($"Game Time: {_game.StopTimer()}");
            Console.WriteLine($"Number of Moves: {_game.GetMoveCount()}");

        }

        Console.WriteLine("Press any key to Continue.");
        Console.ReadKey();
        Console.Clear();
    }
    private static void Demo_InvalidMovements(Game _game)
    {
        // Invalid Movements Scenerio
        Console.WriteLine("Demo: Invalid Movements");

        _game.Restart();
        Console.WriteLine(_game.GameLevel.Name);
        _game.PrintBoard();

        _game.Move(Direction.DownRight);
        _game.Move(Direction.Right);

        Console.WriteLine("The next Move is an Out of Bounds Error");
        Console.WriteLine("Press any Key to Continue");
        Console.ReadKey();
        _game.Move(Direction.RRUp); // OutofBounds X

        Console.WriteLine("The next 2 Moves is an Empty Square error");
        Console.WriteLine("Press any Key to Continue");
        Console.ReadKey();
        _game.Move(Direction.DDLeft); // Empty Square X
        _game.Move(Direction.LLDown); // Empty Square X

        Console.WriteLine("Well go back to the start and intentionally move the\nbishop down which it cannot do.");
        Console.WriteLine("Press any Key to Continue");
        Console.ReadKey();
        _game.Move(Direction.LLUp);
        _game.Move(Direction.Down); // Bishop Cannot Move like that X

        Console.WriteLine("Okay Lets finsh the Level.");
        Console.WriteLine("Press any Key to Continue");
        Console.ReadKey();

        // Finish the Game
        _game.Move(Direction.DownRight);
        _game.Move(Direction.Down);
        _game.Move(Direction.DownLeft); // Dead End!
        Console.WriteLine("Whoops Dead end! Lets Go back and finish the game.");
        Console.WriteLine("Press any Key to Continue");
        Console.ReadKey();

        _game.Move(Direction.UpRight);
        _game.Move(Direction.DownRight);
        _game.Move(Direction.Right);
        if (_game.IsFinished())
        {
            Console.WriteLine("You Win!");
            Console.WriteLine($"Game Time: {_game.StopTimer()}");
            Console.WriteLine($"Number of Moves: {_game.GetMoveCount()}");
        }
    }



}