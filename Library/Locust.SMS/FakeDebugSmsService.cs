using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.SMS
{
    public class FakeDebugSmsConfig : FakeSmsConfig
    {
    }
    public class FakeDebugSmsService : FakeSmsService<FakeDebugSmsConfig>
    {
        protected override string LogInternal(string data)
        {
            Debug.WriteLine(data);

            return "";
        }
    }
}
