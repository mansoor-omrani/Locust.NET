using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;

namespace Locust.Concurrency
{
    public enum WebJobSchedulerState
    {
        Sleeping, Running, Stopped
    }
    public static class WebJobScheduler
    {
        private static System.Timers.Timer timer;
        public static int SleepTime { get; private set; }
        public static int Count
        {
            get { return count; }
        }
        public static WebJobSchedulerState Status { get; set; }
        private static int count;
        private static int running;
        public static event EventHandler Running;
        static WebJobScheduler()
        {
            Status = WebJobSchedulerState.Stopped;
            count = 0;
            SleepTime = 5000;

            timer = new System.Timers.Timer();
            timer.Interval = SleepTime;
            timer.Elapsed += timer_Elapsed;
            
            running = 0;
        }
        private static void timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (Running != null)
            {
                if (Interlocked.CompareExchange(ref running, 1, 0) == 0)
                {
                    Status = WebJobSchedulerState.Running;
                    count++;

                    Running(null, null);

                    Status = WebJobSchedulerState.Sleeping;
                    Interlocked.Exchange(ref running, 0);
                }
                
            }
        }
        public static void Start()
        {
            timer.Start();
        }
        public static void Stop()
        {
            Status = WebJobSchedulerState.Stopped;
            timer.Stop();
        }
        public static bool SetSleepTime(int sleeptime)
        {
            var result = false;

            if (Status != WebJobSchedulerState.Running)
            {
                Stop();

                SleepTime = sleeptime;
                timer.Interval = sleeptime;

                Start();

                result = true;
            }

            return result;
        }
    }
}