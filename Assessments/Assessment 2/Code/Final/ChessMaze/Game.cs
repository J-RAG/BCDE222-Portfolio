using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ChessMaze
{
    public class Game : IGame
    {
        // is game finished 
        private bool GameState = false;

        // FEATURE 10: Must count total Number of Moves
        private int MoveCount { get; set; } = 0; // Number of Moves Made


        // FEATURE 14: Must have timer
        public Stopwatch GameTimer = new();

        public Level GameLevel { get; set; }
        public char[,] Board { get; set; }

        // needed for Undo() and Move() method
        // Dynamic Array which stores Current and Previous
        // moves made by player
        public List<Coord> PlayerHistory;

        // Constructor
        public Game()
        {
            PlayerHistory = new()
            {
                new(0, 0),
                new(0, 0)
            };

            // initialised board
            // replaced once Load() is executed
            GameLevel = new("Init", 0, 0);
            Board = GameLevel.Board;
        }

        // Funcitons >>>>

        // FEATURE 10: Must count total Number of Moves
        public int GetMoveCount()
        {
            return MoveCount;
        }

        // FEATURE 16 : Must acknowledge level completion
        public bool IsFinished()
        {
            var playerPos = GetCurrPos();
            if ((Part)Board[playerPos.Row, playerPos.Col] == Part.PlayerOnKing)
            {
                GameState = true;
            }
            return GameState;
        }

        // HardCoded Board based on string input
        public void Load(string newLevel = "b___\n_QN_\n_BR_\nB_RK")
        {
            StartTimer();
            string[] rows = newLevel.Split('\n');
            var rowLen = rows.Length;
            var colLen = rows[0].Length;
            GameLevel = new("Test Level", rowLen, colLen);
            GameLevel.CreateLevel(rowLen, colLen);
            Board = GameLevel.Board;
            SetupBoard(Board, rows);
        }

        // FEATURE 12: Must have a reset button
        public void Restart()
        {
            // Reset Timer
            StopTimer();
            GameTimer = new();

            // Console.Clear() is disabled as catches an exception error during unit Testing
            // Console.Clear();
            Console.WriteLine("\n>>>RESTARTING LEVEL>>>");

            // Reset Move Count
            MoveCount = 0;

            // Reset PlayerHistory
            PlayerHistory = new()
            {
                new(0, 0),
                new(0, 0)
            };

            // initialised board
            // replaced once Load() is executed
            GameLevel = new("Init", 0, 0);
            Board = GameLevel.Board;

            // NOTE: will load the Default Level (Hardcoded)
            Load();
        }

        // Grabs each char from inputted string and adds it to the Board.
        private static void SetupBoard(char[,] board, string[] rows)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                // each col
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    board[row, col] = (char)(rows[row][col]);
                }
            }
        }

        // Console Display Board  <<OUTSIDE OF SCOPE>>
        public void PrintBoard()
        {
            Console.WriteLine($"Player At: \n({GetCurrPos().Row},{GetCurrPos().Col})");
            Console.WriteLine();
            for (int i = 0; i < Board.GetLength(0); i++)
            {
                // Set Row Coordinates on Board
                if (i != 0)
                {
                    // Coordinate 0 is skipped as it does not align with the format 
                    Console.Write(i + " ");

                }

                for (int j = 0; j < Board.GetLength(1); j++)
                {

                    // Set Column Coordinates on Board
                    if (j == 0 && i == 0)
                    {
                        Console.Write("   ");

                        for (int k = 0; k < Board.GetLength(1); k++)
                        {
                            Console.Write(k + " "); // Add Column Coordinate values
                        }
                        Console.Write("\n" + i + " "); // Display Coordinate value: 0 in line with the grid

                    }

                    Console.Write("|" + Board[i, j]);

                    // If Last Item on Row Add end Strip
                    if (j == Board.GetLength(1) - 1)
                    {
                        Console.Write('|');

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(); // Add a Space for next print
        }

        // FEATURE 14: Must have timer
        public void StartTimer()
        {
            GameTimer.Start();
        }

        // FEATURE 15: Must show time taken to beat level 
        // Stops the Game timer and returns the time in
        // 00:00:00.000 format.
        public string StopTimer()
        {
            GameTimer.Stop();
            TimeSpan ts = GameTimer.Elapsed;
            string time = String.Format
                (
                "{0:00}:{1:00}:{2:00}.{3:00}",
                ts.Hours, ts.Minutes, ts.Seconds,
                ts.Milliseconds / 10
                );
            return time;
        }

        // FEATURE 11: Must highlight current selected piece
        public Coord GetCurrPos()
        {
            return PlayerHistory[^1];
        }

        public void Move(Direction moveDirection)
        {
            var playerPos = GetCurrPos();
            var playerPart = GameLevel.GetPartAtIndex(playerPos.Row, playerPos.Col);

            // FEATURE 	8: Must have the ability to select pieces to move
            Direction[] playerMoves = Moves.GetMoves(playerPart);

            if (playerMoves.Contains(moveDirection))
            {
                // FEATURE 	7: Must be able to detect incorrect movement
                // Check if Move goes out of Bounds
                if (!MoveIsValid(moveDirection, playerPos))
                {
                    Console.WriteLine($"Cannot Move {moveDirection}.\nOut of Bounds\n");
                }
                // FEATURE 9: Must not accept movement to empty squares
                // Check the location of the move is not an Empty Space
                else if (Moves.IsPlayerOnEmpty(moveDirection, playerPos, GameLevel))
                {
                    Console.WriteLine($"Cannot Move {moveDirection}\nCell is Empty\n");
                }
                // Move the player to Direction
                else
                {
                    // Base Case Assignment: 
                    var prevPos = MoveCount == 1 ? PlayerHistory[^1] : PlayerHistory[^2];
                    if (PlayerHistory.Count > 2)
                    {
                        prevPos = PlayerHistory[^1];
                    }


                    playerPos = Moves.MovePlayer(moveDirection, playerPos);
                    UpdateBoard(playerPos, prevPos, playerPart);
                    UpdateHistory(playerPos);
                    PrintBoard();
                }
            }
            else
            {
                Console.WriteLine($"Invalid Move.\nPart does not move {moveDirection}\n");
            }
        }

        // FEATURE 	7: Must be able to detect incorrect movement
        // Return if move is Valid 
        public bool MoveIsValid(Direction move, Coord pos)
        {
            bool valid = false;
            var colLimit = Board.GetLength(1);
            var rowLimit = Board.GetLength(0);

            // Check what move is being Validated
            switch (move)
            {
                case Direction.Up:
                    valid = Moves.UpCheck(pos.Row);
                    break;
                case Direction.Right:
                    valid = Moves.RightCheck(pos.Col, colLimit);
                    break;
                case Direction.Left:
                    valid = Moves.LeftCheck(pos.Col);
                    break;
                case Direction.Down:
                    valid = Moves.DownCheck(pos.Row, rowLimit);
                    break;
                case Direction.UpRight:
                    valid = Moves.UpRightCheck(pos, colLimit);
                    break;
                case Direction.DownRight:
                    valid = Moves.DownRightCheck(pos, rowLimit, colLimit);
                    break;
                case Direction.DownLeft:
                    valid = Moves.DownLeftCheck(pos, rowLimit);
                    break;

                // Knight Checks
                case Direction.UURight:
                    valid = Moves.UURightCheck(pos, colLimit);
                    break;
                case Direction.RRUp:
                    valid = Moves.RRUpCheck(pos, colLimit);
                    break;
                case Direction.RRDown:
                    valid = Moves.RRDownCheck(pos, rowLimit, colLimit);
                    break;
                case Direction.DDRight:
                    valid = Moves.DDRightCheck(pos, rowLimit, colLimit);
                    break;
                case Direction.DDLeft:
                    valid = Moves.DDLeftCheck(pos, rowLimit);
                    break;
                case Direction.LLDown:
                    valid = Moves.LLDownCheck(pos, rowLimit);
                    break;
                case Direction.LLUp:
                    valid = Moves.LLUpCheck(pos);
                    break;
                case Direction.UULeft:
                    valid = Moves.UULeftCheck(pos);
                    break;
            }

            return valid;
        }

        // NEEDED FOR UNDO
        private void UpdateHistory(Coord playerPos)
        {
            MoveCount++;
            // Base Case
            if (MoveCount == 1)
            {
                PlayerHistory[^1] = playerPos;
            }
            else
            {
                PlayerHistory.Add(new(playerPos.Row, playerPos.Col));
            }
        }

        // <<OUT SIDE OF SCOPE>>
        private void UpdateBoard(Coord newPos, Coord prevPos, Part prevPart)
        {
            var partToConvert = GameLevel.GetPartAtIndex(newPos.Row, newPos.Col);
            // Convert That Part into a 'PlayerOn' Part
            switch (partToConvert)
            {
                case Part.King:
                    Board[newPos.Row, newPos.Col] = (char)Part.PlayerOnKing;
                    break;
                case Part.Rook:
                    Board[newPos.Row, newPos.Col] = (char)Part.PlayerOnRook;
                    break;
                case Part.Bishop:
                    Board[newPos.Row, newPos.Col] = (char)Part.PlayerOnBishop;
                    break;
                case Part.Knight:
                    Board[newPos.Row, newPos.Col] = (char)Part.PlayerOnKnight;
                    break;
                case Part.Queen:
                    Board[newPos.Row, newPos.Col] = (char)Part.PlayerOnQueen;
                    break;

            }

            // Convert Previous Part to a Normal Part
            switch (prevPart)
            {
                case Part.PlayerOnKing:
                    Board[prevPos.Row, prevPos.Col] = (char)Part.King;
                    break;
                case Part.PlayerOnRook:
                    Board[prevPos.Row, prevPos.Col] = (char)Part.Rook;
                    break;
                case Part.PlayerOnBishop:
                    Board[prevPos.Row, prevPos.Col] = (char)Part.Bishop;
                    break;
                case Part.PlayerOnKnight:
                    Board[prevPos.Row, prevPos.Col] = (char)Part.Knight;
                    break;
                case Part.PlayerOnQueen:
                    Board[prevPos.Row, prevPos.Col] = (char)Part.Queen;
                    break;
            }
        }

        // FEATURE 	13: Must have a undo button
        public void Undo()
        {
            // Base Case
            if (MoveCount == 0)
            {
                Console.WriteLine("\nCannot Undo: You are at the start");
            }
            else
            {
                MoveCount--; // Decrement Move Count


                var playerPos = PlayerHistory[^1];
                var playerPart = GameLevel.GetPartAtIndex(playerPos.Row, playerPos.Col);
                var prevPos = PlayerHistory[^2];

                // Switching the positions around will Revert the Board to
                // its Previous State << OUSTSIDE SCOPE >>
                UpdateBoard(prevPos, playerPos, playerPart);

                // Remove Last Log in PlayerHistory List
                // Base Case
                if (PlayerHistory.Count > 2)
                {
                    PlayerHistory.RemoveAt(PlayerHistory.Count - 1);
                }
                else
                {
                    PlayerHistory[^1] = PlayerHistory[^2];
                }
                PrintBoard();

            }
        }
    }
}
