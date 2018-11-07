using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging.Win
{
    public class DefaultWinExceptionLogger: IExceptionLogger
    {
        public void LogException(Exception ex, string info = "")
        {
            throw new NotImplementedException();
        }
    }
}
