using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mailing
{
    public class FakeConsoleMailConfig : FakeMailConfig
    {
        public bool ColoredOutput { get; set; }
    }
    public class FakeConsoleMailManager : FakeMailManager<FakeConsoleMailConfig>
    {
        protected override void LogInternal(string data)
        {
            System.Console.WriteLine(data);
        }
    }
}
