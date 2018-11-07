using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Extensions;
using System.Runtime.CompilerServices;

namespace Locust.Logging
{
    public class ConsoleLogger: BaseLogger
    {
        protected override void LogCategoryInternal(string data)
        {
            System.Console.Write(data);
        }

        protected override void LogInternal(string data)
        {
            System.Console.Write(data);
        }
    }
}
