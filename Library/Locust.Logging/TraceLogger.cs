using Locust.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public class TraceLogger : BaseLogger
    {
        public TraceLogger()
        {
        }
        public TraceLogger(BaseLogger next) : base(next)
        {
        }
        protected override void LogCategoryInternal(string data)
        {
            Trace.Write(data);
        }

        protected override void LogInternal(string data)
        {
            Trace.Write(data);
        }
    }
}
