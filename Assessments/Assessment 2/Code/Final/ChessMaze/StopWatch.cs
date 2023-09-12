using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessMaze
{
    public class StopWatch
    {
        public readonly IStopwatch _stopwatch;

        public StopWatch(IStopwatch stopwatch)
        {
            _stopwatch = stopwatch;
        }

        public TimeSpan MeasureTime()
        {
            _stopwatch.Start();
            // Code to measure elapsed time.
            _stopwatch.Stop();

            return _stopwatch.Elapsed;
        }
    }

}
