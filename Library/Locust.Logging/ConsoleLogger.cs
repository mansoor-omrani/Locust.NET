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
        public ConsoleLogger()
        {
        }
        public ConsoleLogger(BaseLogger next): base(next)
        {
        }
        protected override void LogCategoryInternal(string data)
        {
            System.Console.Write(data);
        }

        protected override void LogInternal(string data)
        {
            System.Console.Write(data);
        }
        protected void Log(object log, ConsoleColor color)
        {
            var oldColor = Console.ForegroundColor;

            Console.ForegroundColor = color;

            Log(log);

            Console.ForegroundColor = oldColor;
        }
        public override void Success(object log)
        {
            Log(log, ConsoleColor.Green);
        }
        public override void Danger(object log)
        {
            Log(log, ConsoleColor.Red);
        }
        public override void Warning(object log)
        {
            Log(log, ConsoleColor.Yellow);
        }
        public override void Primary(object log)
        {
            Log(log, ConsoleColor.Blue);
        }
        public override void Secondary(object log)
        {
            Log(log, ConsoleColor.Magenta);
        }
    }
}
