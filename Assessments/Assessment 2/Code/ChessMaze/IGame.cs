using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    interface IGame
    {
        void Move();

        void Restart();

        void Undo();

        bool IsFinished();

        void Load(Level newLevel);

        void StartTimer();

        string StopTimer();

        void DisplayTimer();

        string Action(string prompt);

        void RunAction(string action);

        void End();

    }
}
