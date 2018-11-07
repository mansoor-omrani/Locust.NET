using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.Logging.Web
{
    public interface IRequestLogger
    {
        void Log(HttpRequest request, string info = "", long executionTime = 0);
        void Log(HttpRequestBase request, string info = "", long executionTime = 0);
        void Log(HttpContext context, string info = "", long executionTime = 0);
    }
}
