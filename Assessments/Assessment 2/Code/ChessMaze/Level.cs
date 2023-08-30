using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ChessMaze
{
    public class Level : ILevel
    {
        // Feature 17: Name for the Level
        public string Name { get; set; }

        // Dimensions of the "board"
        public int Width { get; set; }
        public int Height { get; set; }

        public char[,] Board { get; set; }

        // Constructor
        public Level(string name, int width, int height)
        {
            Name = name;
            Width = width;
            Height = height;
            Board = new char[width, height];
            CreateLevel(width, height);
        }

        // FEATURE 1: Must have a game board with correct co-ordinates
        // Creates The Chess Board, All squares will be declared "Empty"
        public void CreateLevel(int rowSize, int columnSize)
        {
            for (int row = 0; row < rowSize; row++)
            {
                for (int col = 0; col < columnSize; col++)
                {
                    // Create an "Empty" square
                    AddEmpty(row, col);
                }
            }
        }

        // Console Display Board 
        public static void PrintBoard(char[,] board)
        {

            for (int i = 0; i < board.GetLength(0); i++)
            {
                // Set Row Coordinates on Board
                if (i != 0)
                {
                    // Coordinate 0 is skiped as it does not align with the format 
                    Console.Write(i + " "); 
                }

                for (int j = 0; j < board.GetLength(1); j++)
                {

                    // Set Column Coordinates on Board
                    if (j == 0 && i == 0)
                    {
                        Console.Write("   ");
                        for (int k = 0; k < board.GetLength(1); k++)
                        {
                        Console.Write(k + " "); // Add Column Coordinate values
                        }
                        Console.Write("\n" + i + " "); // Display Coordinate value: 0 in line with the grid
                    }
               
                    
                       Console.Write("|" + board[i, j]);
                    

                    // If Last Item on Row Add end Strip
                    if (j == board.GetLength(1) - 1)
                    {
                        Console.Write('|');
                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine(); // Add a Space for next print
        }

        // Set Peices on Board
        public void AddEmpty(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.Empty;
        }

        public void AddKing(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.King;
        }

        public void AddRook(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.Rook;
        }

        public void AddBishop(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.Bishop;
        }

        public void AddKnight(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.Knight;
        }

        // Set Player 
        public void AddPlayerOnEmpty(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.PlayerOnEmpty;
        }

        public void AddPlayerOnKing(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.PlayerOnKing;
        }

        public void AddPlayerOnRook(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.PlayerOnRook;
        }

        public void AddPlayerOnBishop(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.PlayerOnBishop;
        }

        public void AddPlayerOnKnight(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.PlayerOnKnight;
        }

        // Return Part on Selected Square
        public Part GetPartAtIndex(int gridX, int gridY)
        {
            return (Part)Board[gridX, gridY];
        }

        // Valid Square? idk well have to use it somewhere I think.
        public bool CheckValid()
        {
            return true;
        }

    }
}