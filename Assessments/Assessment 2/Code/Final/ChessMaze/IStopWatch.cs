using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    public interface IStopwatch
    {
        void Start();
        void Stop();
        TimeSpan Elapsed { get; }
        bool IsRunning { get; }
    }

}
