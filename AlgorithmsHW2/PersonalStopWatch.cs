using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;

namespace AlgorithmsHW2
{
    public class PersonalStopWatch
    {
        Stopwatch stopwatch;
        public PersonalStopWatch()
        {
        stopwatch = new Stopwatch();

        }

        public void StartStopWatch()
        {
        stopwatch.Start();
        }

        public void StopStopWatch()
        {
            stopwatch.Stop();
        }

        public void ResetStopWatch()
        {
            stopwatch.Reset();
        }

        public void GetTimeElapsed(string sortType)
        {
            TimeSpan ts = stopwatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds / 10);
            Console.WriteLine("Run Time For " + sortType + ": " + elapsedTime);
        }


    }
}
