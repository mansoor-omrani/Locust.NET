using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.SMS
{
    public class FakeConsoleSmsConfig : FakeSmsConfig
    {
    }
    public class FakeConsoleSmsService : FakeSmsService<FakeConsoleSmsConfig>
    {
        protected override string LogInternal(string data)
        {
            System.Console.WriteLine(data);

            return "";
        }
    }
}
