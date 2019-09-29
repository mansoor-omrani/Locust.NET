using Locust.Date;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public class MemoryLogEntry
    {
        public DateTime LogDate { get; set; }
        public object Data { get; set; }
        public string Member { get; set; }
        public string File { get; set; }
        public int Line { get; set; }
        private INow now;
        public INow Now
        {
            get
            {
                if (now == null)
                {
                    now = new DateTimeNow();
                }

                return now;
            }
            set { now = value; }
        }
        public MemoryLogEntry()
        {
            LogDate = Now.Value;
        }
        public MemoryLogEntry(object data, string member, string file, int line):this()
        {
            Data = data;
            Member = member;
            File = file;
            Line = line;
        }
    }
    public class DefaultMemoryLogger: IMemoryLogger
    {
        private static object _sync = new object();
        private static int count = 0;
        public ConcurrentDictionary<int, MemoryLogEntry> Logs
        {
            get
            {
                lock (_sync)
                {
                    var result = AppDomain.CurrentDomain.GetData("locust.memorylogger.logs") as ConcurrentDictionary<int, MemoryLogEntry>;

                    if (result == null)
                    {
                        result = new ConcurrentDictionary<int, MemoryLogEntry>();
                        AppDomain.CurrentDomain.SetData("locust.memorylogger.logs", result);
                    }

                    return result;
                }
            }
        }
        public void Log(object data,
                        [CallerMemberName] string memberName = "",
                        [CallerFilePath] string sourceFilePath = "",
                        [CallerLineNumber] int sourceLineNumber = 0)
        {
            var logs = Logs;

            var c = Interlocked.Increment(ref count);

            logs.TryAdd(c, new MemoryLogEntry(data, memberName, sourceFilePath, sourceLineNumber));
        }

        public void Clear()
        {
            var logs = Logs;

            lock (_sync)
            {
                Interlocked.Exchange(ref count, 0);

                logs.Clear();
            }
        }
    }
}
