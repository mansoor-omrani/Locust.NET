using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Console
{
    public class ConsoleArg
    {
        public string Command { get; set; }
        public string CommandShortName { get; set; }
        public string Arg { get; set; }
        public char Separator { get; set; }
    }
}
