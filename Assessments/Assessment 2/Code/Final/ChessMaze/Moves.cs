using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ChessMaze
{
    public class Moves
    {
        // FEATURE 2: Must have movement for Rook
        public static Direction[] GetRookMoves()
        {
            Direction[] moves =
            {
                Direction.Up,
                Direction.Right,
                Direction.Down,
                Direction.Left
            };

            return moves;
        }

        // FEATURE 3: Must have movement for King
        public static Direction[] GetKingMoves()
        {
            return GetQueenMoves();
        }

        // FEATURE 4: Must have movement for Queen
        public static Direction[] GetQueenMoves()
        {
            Direction[] moves =
            {
                Direction.Up,
                Direction.Right,
                Direction.Down,
                Direction.Left,
                Direction.UpRight,
                Direction.DownRight,
                Direction.DownLeft,
                Direction.UpLeft
            };

            return moves;
        }

        // FEATURE 5: Must have movement for Knight
        public static Direction[] GetKnightMoves()
        {
            Direction[] moves =
            {
                Direction.UURight,
                Direction.RRUp,
                Direction.RRDown,
                Direction.DDRight,
                Direction.DDLeft,
                Direction.LLDown,
                Direction.LLUp,
                Direction.UULeft
            };
            return moves;
        }

        // FEATURE 6: Must have movement for Bishop
        public static Direction[] GetBishopMoves()
        {
            Direction[] moves =
            {
                Direction.UpRight,
                Direction.DownRight,
                Direction.DownLeft,
                Direction.UpLeft
            };
            return moves;
        }


        // FEATURE 8: Must have the ability to select pieces to move
        public static Direction[] GetMoves(Part part)
        {
            Direction[] moves = Array.Empty<Direction>();
            switch (part)
            {
                case Part.PlayerOnBishop:
                    moves = Moves.GetBishopMoves();
                    break;

                case Part.PlayerOnRook:
                    moves = Moves.GetRookMoves();
                    break;

                case Part.PlayerOnQueen:
                    moves = Moves.GetQueenMoves();
                    break;

                case Part.PlayerOnKing:
                    moves = Moves.GetKingMoves();
                    break;

                case Part.PlayerOnKnight:
                    moves = Moves.GetKnightMoves();
                    break;
            }
            return moves;
        }

        // FEATURE 	7: Must be able to detect incorrect movement
        // Move Validity
        // Directional Checks
        public static bool UpCheck(int rowPos)
        {
            return rowPos - 1 >= 0;
        }
        public static bool DownCheck(int rowPos, int rowLimit)
        {
            return rowPos + 1 < rowLimit;
        }
        public static bool LeftCheck(int colPos)
        {
            return colPos - 1 >= 0;
        }
        public static bool RightCheck(int colPos, int colLimit)
        {
            return colPos - 1 < colLimit;
        }

        // Diagonal checks
        public static bool UpRightCheck(Coord pos, int colLimit)
        {
            return pos.Row - 1 >= 0 && pos.Col + 1 < colLimit;
        }
        public static bool UpLeftCheck(Coord pos)
        {
            return pos.Row - 1 >= 0 && pos.Col - 1 >= 0;
        }
        public static bool DownRightCheck(Coord pos, int rowLimit, int colLimit)
        {
            return pos.Row + 1 < rowLimit && pos.Col + 1 < colLimit;
        }
        public static bool DownLeftCheck(Coord pos, int rowLimit)
        {
            return pos.Row + 1 < rowLimit && pos.Col - 1 >= 0;
        }

        // Knight Move Checks
        public static bool UURightCheck(Coord pos, int colLimit)
        {
            return pos.Row - 2 >= 0 && pos.Col + 1 < colLimit;
        }
        public static bool RRUpCheck(Coord pos, int colLimit)
        {
            return pos.Row - 1 >= 0 && pos.Col + 2 < colLimit;
        }
        public static bool RRDownCheck(Coord pos, int rowLimit, int colLimit)
        {
            return pos.Row + 1 < rowLimit && pos.Col + 2 < colLimit;
        }
        public static bool DDRightCheck(Coord pos, int rowLimit, int colLimit)
        {
            return pos.Row + 2 < rowLimit && pos.Col + 1 < colLimit;
        }
        public static bool DDLeftCheck(Coord pos, int rowLimit)
        {
            return pos.Row + 2 < rowLimit && pos.Col - 1 >= 0;

        }
        public static bool LLDownCheck(Coord pos, int rowLimit)
        {
            return pos.Row + 1 < rowLimit && pos.Col - 2 >= 0;
        }
        public static bool LLUpCheck(Coord pos)
        {
            return pos.Row - 1 >= 0 && pos.Col - 2 >= 0;
        }
        public static bool UULeftCheck(Coord pos)
        {
            return pos.Row - 2 >= 0 && pos.Col - 1 >= 0;
        }

        // FEATURE 9: Must not accept movement to empty squares
        public static bool IsPlayerOnEmpty(Direction move, Coord playerPos, Level level)
        {

            /*          
                Declared as new Object to 
                avoid Object referencing
                
                var checkPos = playerPos; // X NO this will mess everything up
            */

            var pos = playerPos;
            Coord checkPos = new(playerPos.Row, playerPos.Col);

            // Postion to check is based on MoveDirection
            switch (move)
            {
                case Direction.Up:
                    checkPos.Row -= 1;
                    break;
                case Direction.Right:
                    checkPos.Col += 1;
                    break;
                case Direction.Left:
                    checkPos.Col -= 1;
                    break;
                case Direction.Down:
                    checkPos.Row += 1;
                    break;
                case Direction.UpRight:
                    checkPos.Row -= 1;
                    checkPos.Col += 1;
                    break;
                case Direction.DownRight:
                    checkPos.Row += 1;
                    checkPos.Col += 1;
                    break;
                case Direction.DownLeft:
                    checkPos.Row += 1;
                    checkPos.Col -= 1;
                    break;
                case Direction.UpLeft:
                    checkPos.Row -= 1;
                    checkPos.Col -= 1;
                    break;

                // Knight Checks
                case Direction.UURight:
                    checkPos.Row -= 2;
                    checkPos.Col += 1;
                    break;
                case Direction.RRUp:
                    checkPos.Row -= 1;
                    checkPos.Col += 2;
                    break;
                case Direction.RRDown:
                    checkPos.Row += 1;
                    checkPos.Col += 2;
                    break;
                case Direction.DDRight:
                    checkPos.Row += 2;
                    checkPos.Col += 1;
                    break;
                case Direction.DDLeft:
                    checkPos.Row += 2;
                    checkPos.Col -= 1;
                    break;
                case Direction.LLDown:
                    checkPos.Row += 1;
                    checkPos.Col -= 2;
                    break;
                case Direction.LLUp:
                    checkPos.Row -= 1;
                    checkPos.Col -= 2;
                    break;
                case Direction.UULeft:
                    checkPos.Row -= 2;
                    checkPos.Col -= 1;
                    break;
            }
            return level.GetPartAtIndex(checkPos.Row, checkPos.Col) == Part.Empty;
        }

        public static Coord MovePlayer(Direction move, Coord playerPos)
        {
            /*          
                Declared as new Object to 
                avoid Object referencing
            */
            Coord newPos = new(playerPos.Row, playerPos.Col);

            switch (move)
            {
                case Direction.Up:
                    newPos.Row -= 1;
                    break;
                case Direction.Right:
                    newPos.Col += 1;
                    break;
                case Direction.Left:
                    newPos.Col -= 1;
                    break;
                case Direction.Down:
                    newPos.Row += 1;
                    break;
                case Direction.UpRight:
                    newPos.Row -= 1;
                    newPos.Col += 1;
                    break;
                case Direction.DownRight:
                    newPos.Row += 1;
                    newPos.Col += 1;
                    break;
                case Direction.DownLeft:
                    newPos.Row += 1;
                    newPos.Col -= 1;
                    break;
                case Direction.UpLeft:
                    newPos.Row -= 1;
                    newPos.Col -= 1;
                    break;

                // Knight Moves
                case Direction.UURight:
                    newPos.Row -= 2;
                    newPos.Col += 1;
                    break;
                case Direction.RRUp:
                    newPos.Row -= 1;
                    newPos.Col += 2;
                    break;
                case Direction.RRDown:
                    newPos.Row += 1;
                    newPos.Col += 2;
                    break;
                case Direction.DDRight:
                    newPos.Row += 2;
                    newPos.Col += 1;
                    break;
                case Direction.DDLeft:
                    newPos.Row += 2;
                    newPos.Col -= 1;
                    break;
                case Direction.LLDown:
                    newPos.Row += 1;
                    newPos.Col -= 2;
                    break;
                case Direction.LLUp:
                    newPos.Row -= 1;
                    newPos.Col -= 2;
                    break;
                case Direction.UULeft:
                    newPos.Row -= 2;
                    newPos.Col -= 1;
                    break;
            }

            return newPos;

        }
    }
}
