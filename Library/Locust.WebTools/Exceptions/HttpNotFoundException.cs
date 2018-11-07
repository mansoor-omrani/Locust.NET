using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.WebTools
{
    public class HttpNotFoundException: Exception
    {
        public HttpNotFoundException()
        {
        }
        public HttpNotFoundException(string message) :base(message)
        {
        }
        public HttpNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
