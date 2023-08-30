using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    interface ILevel
    {
        void CreateLevel(int width, int height);
        void AddEmpty(int gridX, int gridY);
        void AddKing(int gridX, int gridY);
        void AddRook(int gridX, int gridY);
        void AddBishop(int gridX, int gridY);
        void AddKnight(int gridX, int gridY);
        void AddPlayerOnEmpty(int gridX, int gridY);
        void AddPlayerOnKing(int gridX, int gridY);
        void AddPlayerOnRook(int gridX, int gridY);
        void AddPlayerOnBishop(int gridX, int gridY);
        void AddPlayerOnKnight(int gridX, int gridY);
        Part GetPartAtIndex(int gridX, int gridY);
        bool CheckValid();
    }
}
