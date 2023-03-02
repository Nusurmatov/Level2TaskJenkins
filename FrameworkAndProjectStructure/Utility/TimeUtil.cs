using System.Diagnostics;

namespace FrameworkAndProjectStructure.Utility
{
    public static class TimeUtil
    {
        private static Stopwatch watch= new Stopwatch();

        public static string GetTimeStamp(DateTime dateTime) => dateTime.ToString("yyyy-MM-dd_HH-mm-ss");

        public static void StartWatch() => watch.Start();
    
        public static void StopWatch() => watch.Stop();

        public static long GetElapsedTime(bool InMinutes = false, bool InSeconds = false)
        {
            var timeSpan = watch.Elapsed;

            if (InMinutes)
            { 
                return timeSpan.Minutes;
            }
            else if (InSeconds)
            {
                return timeSpan.Seconds;
            }
            else
            { 
                return timeSpan.Milliseconds;
            }
        }
    }
}
