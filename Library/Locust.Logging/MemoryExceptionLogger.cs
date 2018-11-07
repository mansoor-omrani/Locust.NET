using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public class MemoryExceptionLogger : BaseExceptionLogger
    {
        public IMemoryLogger MemoryLogger { get; set; }
        public MemoryExceptionLogger(IMemoryLogger memoryLogger)
        {
            MemoryLogger = memoryLogger;
        }
        public MemoryExceptionLogger(IMemoryLogger memoryLogger, BaseExceptionLogger next):base(next)
        {
            MemoryLogger = memoryLogger;
        }
        protected override bool LogExceptionInternal(Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            MemoryLogger.Log(new { Exception = ex, Info = info }, memberName, sourceFilePath, sourceLineNumber);

            return true;
        }
    }
}
