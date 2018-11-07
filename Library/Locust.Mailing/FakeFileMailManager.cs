using Locust.AppPath;
using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Mailing
{
    public class FakeFileMailConfig : FakeMailConfig
    {
        public string Path { get; set; }
    }
    public class FakeFileMailManager : FakeMailManager<FakeFileMailConfig>
    {
        public FakeFileMailManager()
        {
            StrongConfig.Path = ApplicationPath.Root + @"\fakemail.txt";
        }
        protected override void LogInternal(string data)
        {
            File.AppendAllText(StrongConfig.Path, data);
        }
    }
}
