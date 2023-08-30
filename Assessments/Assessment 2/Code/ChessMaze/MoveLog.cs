using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    // Creates a Log the records the Current State
    // of the Board and the Player's Position
    // (board, (row, col))
    class MoveLog
    {
        public char[,] Board;
        public Coord Pos;

        public MoveLog(Level theLevel,Coord pos ) 
        {
            Board = theLevel.Board;
            Pos = pos;
        }
    }
}
