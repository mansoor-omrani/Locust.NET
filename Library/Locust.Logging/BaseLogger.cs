using Locust.Date;
using Locust.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public class LoggerException: Exception
    {
        public LoggerException():base()
        {
        }
        public LoggerException(string message) : base(message)
        {
        }
        public LoggerException(string message, Exception inner) : base(message, inner)
        {
        }
    }
    public abstract class BaseLogger : ILogger
    {
        public LogMode Mode { get; set; }
        public BaseLogger Next { get; private set; }
        public BaseLogger Prev { get; private set; }
        public bool ThrowExceptions { get; set; }
        protected void Throw(string message, Exception inner = null)
        {
            if (ThrowExceptions)
            {
                if (inner != null)
                {
                    throw new LoggerException(message, inner);
                }
                else
                {
                    throw new LoggerException(message);
                }
            }
        }
        public string LogFormat { get; set; }
        public string LogCategoryFormat { get; set; }
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
        public BaseLogger()
        {
            LogFormat = "{0:yyyy/MM/dd HH:mm:ss.fffffff}       {1}\n";
            LogCategoryFormat = "{0:yyyy/MM/dd HH:mm:ss.fffffff} {1}       {2}\n";
        }
        public BaseLogger(BaseLogger next)
        {
            LogFormat = "{0:yyyy/MM/dd HH:mm:ss.fffffff}       {1}\n";
            LogCategoryFormat = "{0:yyyy/MM/dd HH:mm:ss.fffffff} {1}       {2}\n";

            this.Next = next ?? throw new ArgumentNullException("next");
            next.Prev = this;
        }
        protected virtual string SerializeLog(object log)
        {
            string result = null;

            if (log != null)
            {
                if (log.GetType().IsNullableOrBasicType())
                {
                    result = log.ToString();
                }
                else
                {
                    try
                    {
                        result = JsonConvert.SerializeObject(log, Formatting.Indented);
                    }
                    catch
                    {
                        result = log.ToString() + " (json serialization failed!)";
                    }
                }
            }

            return result;
        }
        protected virtual string SerializeLogCategory(object category)
        {
            return category?.ToString();
        }
        public virtual void Log(object log)
        {
            if (log != null)
            {
                try
                {
                    LogInternal(log);
                }
                catch (Exception e)
                {
                    Throw("Logging Failed!", e);
                }

                if (Next != null)
                {
                    Next.Log(log);
                }
            }
        }
        public virtual void Log(object category, object log)
        {
            if (log != null)
            {
                try
                {
                    LogInternal(category, log);
                }
                catch (Exception e)
                {
                    Throw("Logging Failed!", e);
                }

                if (Next != null)
                {
                    Next.Log(category, log);
                }
            }
        }
        protected abstract void LogCategoryInternal(string data);
        public virtual void LogCategory(object category = null,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (category != null)
            {
                try
                {
                    var d = Now.Value;
                    var data = string.Format("\n{0:yyyy/MM/dd HH:mm:ss.fffffff}   {1}\n", d, ((category != null) ? category + ":" : "")) +
                                $"  Member: {memberName}\n  File: {sourceFilePath}\n  Line: {sourceLineNumber}\n";

                    LogCategoryInternal(data);
                }
                catch (Exception e)
                {
                    Throw("Logging Failed!", e);
                }

                if (Next != null)
                {
                    Next.LogCategory(category, memberName, sourceFilePath, sourceLineNumber);
                }
            }
        }
        protected abstract void LogInternal(string data);
        protected virtual void LogInternal(object log)
        {
            var x = SerializeLog(log);

            var data = string.Format(LogFormat, Now.Value, x);

            LogInternal(data);
        }
        protected virtual void LogInternal(object category, object log)
        {
            var x = SerializeLogCategory(category);
            var y = SerializeLog(log);

            var data = string.Format(LogCategoryFormat, Now.Value, x, y);

            LogInternal(data);
        }
        #region Helper Methods
        public virtual void Success(object log)
        {
            Log(log);
        }
        public virtual void Danger(object log)
        {
            Log(log);
        }
        public virtual void Warning(object log)
        {
            Log(log);
        }
        public virtual void Primary(object log)
        {
            Log(log);
        }
        public virtual void Secondary(object log)
        {
            Log(log);
        }
        #endregion
        private void Log(object log, LogMode mode)
        {
            if ((Mode & mode) == mode)
            {
                Log(log);
            }
        }
        private void Log(object category, object log, LogMode mode)
        {
            if ((Mode & mode) == mode)
            {
                Log(category, log);
            }
        }
        public void Debug(object log)
        {
            Log(log, LogMode.Debug);
        }
        public void Trace(object log)
        {
            Log(log, LogMode.Trace);
        }
        public void Sys(object log)
        {
            Log(log, LogMode.Sys);
        }
        public void App(object log)
        {
            Log(log, LogMode.App);
        }
        public void Debug(object category, object log)
        {
            Log(category, log, LogMode.Debug);
        }
        public void Trace(object category, object log)
        {
            Log(category, log, LogMode.Trace);
        }
        public void Sys(object category, object log)
        {
            Log(category, log, LogMode.Sys);
        }
        public void App(object category, object log)
        {
            Log(category, log, LogMode.App);
        }
    }
}
