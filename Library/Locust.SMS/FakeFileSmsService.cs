using Locust.AppPath;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.SMS
{
    public class FakeFileSmsConfig: FakeSmsConfig
    {
        public string Path { get; set; }
    }
    public class FakeFileSmsService: FakeSmsService<FakeFileSmsConfig>
    {
        public FakeFileSmsService()
        {
            StrongConfig.Path = ApplicationPath.Root + @"\fakesms.txt";
        }
        protected override string LogInternal(string data)
        {
            File.AppendAllText(StrongConfig.Path, data);

            return "";
        }
    }
}
