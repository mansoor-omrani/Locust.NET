using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mailing
{
    public class FakeTraceMailConfig : FakeMailConfig
    {
    }
    public class FakeTraceMailManager : FakeMailManager<FakeTraceMailConfig>
    {
        protected override void LogInternal(string data)
        {
            Trace.WriteLine(data);
        }
    }
}
