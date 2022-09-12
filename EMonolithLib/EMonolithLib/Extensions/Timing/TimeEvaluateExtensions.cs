using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMonolithLib.Extensions.Timing
{
    public static class TimeEvaluateExtensions
    {
        private static Stopwatch stopwatch = new Stopwatch();

        public static T EvaluateTime<T>(this object context, Func<T> function, out double EvaluatedTimeMS)
        {
            _ = context;

            stopwatch.Restart();

            T result = function();

            stopwatch.Stop();

            EvaluatedTimeMS = stopwatch.Elapsed.TotalMilliseconds;

            return result;
        }

        public static void EvaluateTime(this object context, Action function, out double EvaluatedTimeMS)
        {
            _ = context;

            stopwatch.Restart();

            function();

            stopwatch.Stop();

            EvaluatedTimeMS = stopwatch.Elapsed.TotalMilliseconds;
        }
    }
}
