using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.Logging.Web
{
    public interface IWebExceptionLogger: IExceptionLogger
    {
        void LogException(HttpContextBase context, Exception ex, string info = "",
                        [CallerMemberName] string memberName = "",
                        [CallerFilePath] string sourceFilePath = "",
                        [CallerLineNumber] int sourceLineNumber = 0);
    }
}
