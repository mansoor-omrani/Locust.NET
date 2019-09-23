using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ConsoleHelper
{
    public class ConsoleArgParserConfig
    {
        public string CommandChars { get; set; }
        public string CommandAndArgSeparator { get; set; }
        public string Commands { get; set; }
        public string CommandShortNames { get; set; }
        public bool CaseSensitive { get; set; }
        public bool IgnoreInvalidCommands { get; set; }
        public bool IgnoreDuplicateCommands { get; set; }
        public bool TakeFirstCommandOccurance { get; set; }
        public ConsoleArgParserConfig()
        {
            CommandChars = "-/";
            CommandAndArgSeparator = ": ";
            CaseSensitive = false;
            IgnoreInvalidCommands = true;
            IgnoreDuplicateCommands = true;
            TakeFirstCommandOccurance = true;
        }
    }
}
