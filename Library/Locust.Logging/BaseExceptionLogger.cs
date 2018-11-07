using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public abstract class BaseExceptionLogger : IExceptionLogger
    {
        public BaseExceptionLogger Next { get; private set; }
        public BaseExceptionLogger Prev { get; private set; }
        public bool ThrowIfNoNext { get; set; }
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
        protected void Throw(string message)
        {
            throw new Exception(message);
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
