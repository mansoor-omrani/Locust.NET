using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mailing
{
    public class FakeDebugMailConfig : FakeMailConfig
    {
    }
    public class FakeDebugMailManager : FakeMailManager<FakeDebugMailConfig>
    {
        protected override void LogInternal(string data)
        {
            Debug.WriteLine(data);
        }
    }
}
