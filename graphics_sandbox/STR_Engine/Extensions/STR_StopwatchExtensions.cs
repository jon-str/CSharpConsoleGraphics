using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STR_GraphicsLib.STR_Engine
{
    public static class STR_StopwatcExtensions
    {
        public static long ElapsedNanoSeconds ( this Stopwatch oStopwatch ) => oStopwatch.ElapsedTicks * 1000000000L / Stopwatch.Frequency;
    }
}
