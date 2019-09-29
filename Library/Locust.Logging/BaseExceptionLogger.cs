using Locust.Date;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public class ExceptionLoggerException : Exception
    {
        public ExceptionLoggerException() : base()
        {
        }
        public ExceptionLoggerException(string message) : base(message)
        {
        }
        public ExceptionLoggerException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public abstract class BaseExceptionLogger : IExceptionLogger
    {
        public BaseExceptionLogger Next { get; private set; }
        public BaseExceptionLogger Prev { get; private set; }
        public bool ThrowIfNoNext { get; set; }
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
        public BaseExceptionLogger()
        {
        }
        public BaseExceptionLogger(BaseExceptionLogger next)
        {
            if (next == null)
                throw new ArgumentNullException("next");

            Next = next;
            next.Prev = this;
        }
        protected void Throw(string message, Exception inner = null)
        {
            if (inner != null)
            {
                throw new ExceptionLoggerException(message, inner);
            }
            else
            {
                throw new ExceptionLoggerException(message);
            }
        }
        public void LogException(Exception ex, string info = "",
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (ex == null)
                return;

            try
            {
                var canLog = LogExceptionInternal(ex, info, memberName, sourceFilePath, sourceLineNumber);

                if (!canLog)
                {
                    if (Next != null)
                    {
                        Next.LogException(ex, info, memberName, sourceFilePath, sourceLineNumber);
                    }
                    else
                    {
                        if (ThrowIfNoNext)
                        {
                            throw ex;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                if (Next != null)
                {
                    Next.LogException(e);
                    Next.LogException(ex, info, memberName, sourceFilePath, sourceLineNumber);
                }
                else
                {
                    throw;
                }
            }
        }
        protected abstract bool LogExceptionInternal(Exception ex, string info = "",
                string memberName = "",
                string sourceFilePath = "",
                int sourceLineNumber = 0);
    }
}
