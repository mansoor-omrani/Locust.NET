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
        private void LogExceptionInternal(HttpContextBase context, Exception ex, string info = "", string memberName = "", string sourceFilePath = "", int sourceLineNumber = 0)
        {
            var err = new Elmah.Error(ex);
            err.Detail = info;
            Elmah.ErrorLog.GetDefault(context.ApplicationInstance.Context).Log(err);
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

                LogExceptionInternal(context, ex, info, memberName, sourceFilePath, sourceLineNumber);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
