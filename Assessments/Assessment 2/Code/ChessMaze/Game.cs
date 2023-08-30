using System.Diagnostics;

namespace ChessMaze
{
    class Game : IGame
    {
        // is game finished 
        private bool gameState = false;

        // FEATURE 10: Must count total Number of Moves
        private int MoveCount { get; set; } = 0; // Number of Moves Made

        // FEATURE 14: Must have timer
        private Stopwatch gameTimer = new();

        // Game Board Which is initialised upon execution
        public Level TheLevel { get; set; }


        // needed for Undo() method
        // Dynamic Array which stores all moves made by player
        private List<object> PlayerHistory = new();
        private MoveLog CurrMove; //(a, b)
        private MoveLog PrevMove;



        // Constructor
        public Game(Level theLevel, List<object> playerHistory)
        {
            TheLevel = theLevel;

            // Initialise Player History
            PlayerHistory = playerHistory;
            CurrMove = new(theLevel, new(0, 0)); // always last item in list
            PrevMove = new(theLevel, new(0, 0)); // second last
            PlayerHistory.Add(PrevMove);
            PlayerHistory.Add(CurrMove);

        }

        public void Move()
        {
            throw new NotImplementedException();
        }


        // FEATURE 12: Must have a reset button
        public void Restart()
        {
            // Reset Timer
            StopTimer();
            gameTimer = new();

            Console.WriteLine("\n>>>RESTARTING LEVEL>>>");

            // Reset Move Count
            MoveCount = 0;

            // Reset Move History
            PlayerHistory = new();
            CurrMove = new(TheLevel, new(0, 0));
            PrevMove = new(TheLevel, new(0, 0));
            PlayerHistory.Add(PrevMove);
            PlayerHistory.Add(CurrMove);

            // Print Level Name
            Console.WriteLine(TheLevel.Name);

            // Turn Back to an Empty Board
            TheLevel.CreateLevel(TheLevel.Width, TheLevel.Height);
            Console.WriteLine();

            // Reload Level 
            Load(TheLevel);
        }

        // FEATURE 13: Must have undo button
        public void Undo()
        {
            // Cannot Undo as you are at the beginning
            if (MoveCount == 0)
            {
                Console.WriteLine("\nCannot Undo: You are at the start");
                DisplayNumMoves();
            }
            else
            {
                MoveCount--; // decrement Num Moves
                // Update Board to return to previous state
                // // Board = PrevMove.Board
                //

                CurrMove = PrevMove;
                // Delete Latest Action from player history
                PlayerHistory.RemoveAt(PlayerHistory.Count - 1);
                PrevMove = (MoveLog)PlayerHistory[PlayerHistory.Count - 2];
                throw new NotImplementedException();

            }
        }

        // Check if game has reached the goal
        public bool IsFinished()
        {
            // If we reached the goal the game should end
            if (TheLevel.GetPartAtIndex(CurrMove.Pos.Row, CurrMove.Pos.Col) == Part.PlayerOnKing)
            {
                gameState = true;
            }


            return gameState;
        }

        // FEATURE 1: Must have a game board with correct co-ordinates
        // This Will Generate the hard coded Level
        public void Load(Level newLevel)
        {
            // Iniitalise Timer
            StartTimer();

            char[,] myBoard = newLevel.Board;

            // Console.WriteLine("Initial Preview of Empty Board");
            // Level.PrintBoard(myBoard);

            // Set Player as Bishop at starting point
            // Console.WriteLine("Setting Player-Bishop at (0,0)");
            newLevel.AddPlayerOnBishop(0, 0);

            // Add Bishop(s)
            newLevel.AddBishop(3, 0);
            newLevel.AddBishop(2, 2);
            // Level.PrintBoard(myBoard);

            // Add Rook(s) 
            // Console.WriteLine("Adding Rooks...");
            newLevel.AddRook(0, 3);
            newLevel.AddRook(2, 1);
            // Level.PrintBoard(myBoard);

            // Add Knight(s)
            newLevel.AddKnight(1, 1);

            // Add King (end Point)
            newLevel.AddKing(3, 3);
           
        Level.PrintBoard(myBoard);

        }

        // FEATURE 14: Must have timer
        public void StartTimer()
        {
            gameTimer.Start();
        }

        // FEATURE 15: Must show time taken to beat level 
        // Stops the Game timer and returns the time in
        // 00:00:00.000 format.
        public string StopTimer()
        {
            gameTimer.Stop();
            TimeSpan ts = gameTimer.Elapsed;
            string time = String.Format
                (
                "{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10
                );
            return time;
        }

        public void DisplayTimer()
        {
            Console.WriteLine($"\nGame Time: {StopTimer()}");
            StartTimer(); // Continue Timer
        }

        // Returns User Input
        public string Action(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine() ?? "";
        }

        // Takes User input and runs the request
        public void RunAction(string action)
        {
            switch (action.ToLower())
            {
                // Get Options
                case "h":
                    DisplayOptions();
                    break;

                // Empty Input
                case "":
                    Console.WriteLine("\nNo input made.");
                    Console.WriteLine();
                    break;

                // Restart Game
                case "r":
                    Restart();
                    break;

                // Get Timer
                case "t":
                    DisplayTimer();
                    break;


                // FEATURE 10: Must count total Number of Moves
                // Get Move Count
                case "m":
                    DisplayNumMoves();
                    break;

                // Display Board
                case "b":
                    Console.WriteLine();
                    Console.WriteLine(TheLevel.Name);
                    Level.PrintBoard(TheLevel.Board);
                    break;

                // Display Player Position and their "Part" Type
                case "p":
                    GetCurrPos();
                    break;

                // Undo Player's Last Move
                case "u":
                    Undo();
                    break;

                // Exit out of Game 
                case "q":
                    break;

                // needs fixing as if we put anything here not
                // mentioned above it will always go here 
                default:
                    Console.WriteLine("\nInvalid Input.\n");
                    break;
            }

        }

        // Display User Options 
        private static void DisplayOptions()
        {
            Console.WriteLine();
            Console.WriteLine("Options: ");
            Console.WriteLine("r - Restart Level.");
            Console.WriteLine("t - Get game time.");
            Console.WriteLine("m - Get move count.");
            Console.WriteLine("p - Player Position");
            Console.WriteLine("b - Display Board.");
            Console.WriteLine("u - Undo last Move.");
            Console.WriteLine("q - Exit Game.");
            Console.WriteLine();
        }

        // End Game Sequence
        public void End()
        {
            // User has Quit the Game
            if (!gameState)
            {
                Console.WriteLine("Gameover you Lose...");

            }
            else
            {
                // FEATURE 15: Must show time taken to beat level 
                // Game was Completed
                Console.WriteLine("Congrats!");
                Console.WriteLine($"Game Finished at {StopTimer()}");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to Exit");
            Console.ReadKey();
        }

        // FEATURE 10: Must count total Number of Moves
        // Display Move Count
        private void DisplayNumMoves()
        {
            if (MoveCount != 1)
            {
                Console.WriteLine($"\nYou have made {MoveCount} moves.");
            }
            else
            {
                Console.WriteLine($"\nYou have made {MoveCount} move");

            }
        }

        // FEATURE 11: Must highlight current selected piece
        // Diplay Coordinates of Player and What Chess Piece they are
        private void GetCurrPos()
        {
            Console.WriteLine($"\nPlayer Positioned at ({CurrMove.Pos.Row}, {CurrMove.Pos.Col})");
            Console.WriteLine($"Player is a {TheLevel.GetPartAtIndex(CurrMove.Pos.Row, CurrMove.Pos.Col)}");
        }
    }
}
