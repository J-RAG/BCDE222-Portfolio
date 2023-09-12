using System.ComponentModel;
using System.Runtime.InteropServices;

namespace ChessMaze
{
    public class Level : ILevel
    {
        // Feature 17: Must display level name
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


        // Set Peices on Board
        public void AddEmpty(int gridX, int gridY)
        {
            Board[gridX, gridY] = (char)Part.Empty;
        }

        public void AddKing(int gridX, int gridY)
        {
            throw new NotImplementedException();

        }

        public void AddRook(int gridX, int gridY)
        {
            throw new NotImplementedException();

        }

        public void AddBishop(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        public void AddKnight(int gridX, int gridY)
        {
            throw new NotImplementedException();
        }

        // Set Player 
        public void AddPlayerOnEmpty(int gridX, int gridY)
        {
            throw new NotImplementedException();

        }

        public void AddPlayerOnKing(int gridX, int gridY)
        {
            throw new NotImplementedException();

        }

        public void AddPlayerOnRook(int gridX, int gridY)
        {
            throw new NotImplementedException();

        }

        public void AddPlayerOnBishop(int gridX, int gridY)
        {
            throw new NotImplementedException();

        }

        public void AddPlayerOnKnight(int gridX, int gridY)
        {
            throw new NotImplementedException();

        }

        // FEATURE 11: Must highlight current selected piece
        // Return Part on Selected Square
        public Part GetPartAtIndex(int gridX, int gridY)
        {
            return (Part)Board[gridX, gridY];

        }

        public bool CheckValid()
        {
            throw new NotImplementedException();
        }

        public int GetLevelWidth()
        {
            return Width;
        }

        public int GetLevelHeight()
        {
            return Height;
        }

        public void SaveMe()
        {
            throw new NotImplementedException();
        }
    }
}