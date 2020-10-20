using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Kata.Main.Tools
{
    public static class StopWatcherHelper
    {
        public static StopWatcherModel<TResult> CountSeconds<TIn, TResult>(Func<TIn, TResult> method, TIn param, int laps)
        {
            var watcherResult = new StopWatcherModel<TResult> { Results = new List<TResult>(), LapsSeconds = new List<double>()};
            var watcher = new Stopwatch();            
            long ms = 0;
            for (int i = 1; i <= laps; i++)
            {
                watcher.Restart();
                watcherResult.Results.Add(method(param));
                watcher.Stop();
                ms += watcher.ElapsedMilliseconds;
                watcherResult.LapsSeconds.Add(TimeSpan.FromMilliseconds(watcher.ElapsedMilliseconds).TotalSeconds);
                Console.WriteLine($"Lap {i}: Time taken in seconds: {watcherResult.LapsSeconds.Last()}");
            }
            watcherResult.ElapsedSecondsAverage = TimeSpan.FromMilliseconds(ms / laps).TotalSeconds;
            Console.WriteLine("Average time taken in seconds: " + watcherResult.ElapsedSecondsAverage);
            return watcherResult;
        }
    }

    public class StopWatcherModel<T>
    {
        public List<T> Results { get; set; }
        public List<double> LapsSeconds { get; set; }
        public double ElapsedSecondsAverage { get; set; }
    }
}
