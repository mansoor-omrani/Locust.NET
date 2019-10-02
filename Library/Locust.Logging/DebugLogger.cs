using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Extensions;
using System.Runtime.CompilerServices;

namespace Locust.Logging
{
    public class DebugLogger:BaseLogger
    {
        public DebugLogger()
        {
        }
        public DebugLogger(BaseLogger next) : base(next)
        {
        }
        protected override void LogCategoryInternal(string data)
        {
            System.Diagnostics.Debug.Write(data);
        }

        protected override void LogInternal(string data)
        {
            System.Diagnostics.Debug.Write(data);
        }
    }
}
