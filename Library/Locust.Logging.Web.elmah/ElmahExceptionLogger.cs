using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.Logging.Web.elmah
{
    public class ElmahExceptionLogger : BaseExceptionLogger, IWebExceptionLogger
    {
        public ElmahExceptionLogger()
        {
        }
        public ElmahExceptionLogger(BaseExceptionLogger next) : base(next)
        {

        }
        private bool LogExceptionInternal(HttpContextBase context, Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            var err = new Elmah.Error(ex);
            err.Detail = $"memberName: {memberName}\nsourceFilePath: {sourceFilePath}\nsourceLineNumber: {sourceLineNumber}\ninfo: {info}";

            if (context.ApplicationInstance != null)
            {
                Elmah.ErrorLog.GetDefault(context.ApplicationInstance.Context).Log(err);

                return true;
            }

            return false;
        }
        public void LogException(HttpContextBase context, Exception ex, string info = "", [CallerMemberName] string memberName = "", [CallerFilePath] string sourceFilePath = "", [CallerLineNumber] int sourceLineNumber = 0)
        {
            if (context != null)
            {
                LogExceptionInternal(context, ex, info, memberName, sourceFilePath, sourceLineNumber);
            }
        }

        protected override bool LogExceptionInternal(Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            if (HttpContext.Current != null)
            {
                var context = new HttpContextWrapper(HttpContext.Current);

                return LogExceptionInternal(context, ex, info, memberName, sourceFilePath, sourceLineNumber);
            }
            else
            {
                return false;
            }
        }
    }
}
