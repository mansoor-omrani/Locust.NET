using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ConsoleHelper
{
    public class ConsoleArgParser
    {
        public ConsoleArgParserConfig Config { get; set; }

        public ConsoleArgParser()
        {
            this.Config = new ConsoleArgParserConfig();
        }
        public ConsoleArgParser(ConsoleArgParserConfig config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }

            this.Config = config;
        }

        public ConsoleArgParser(string commands, string commandShortNames = "")
        {
            this.Config = new ConsoleArgParserConfig();
            this.Config.Commands = commands;
            this.Config.CommandShortNames = commandShortNames;

            if (!string.IsNullOrEmpty(commands) && !string.IsNullOrEmpty(commandShortNames))
            {
                var arr1 = commands.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                var arr2 = commandShortNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                if (arr1.Length != arr2.Length)
                {
                    throw new ArgumentException("Commands and their shortnames do not match");
                }
            }
        }
        private string[] Commands { get; set; }
        private string[] CommandShortNames { get; set; }
        private char[] CommandChars { get; set; }
        private char[] CommandAndArgSeparator { get; set; }
        private ConsoleArg Parse(string arg)
        {
            var _arg = arg.Trim();

            if (string.IsNullOrEmpty(_arg))
            {
                return null;
            }

            var cmd = "";
            var cmdShortName = "";
            var value = "";
            var valueStarted = false;
            var valid = true;
            var state = 1;
            var i = 0;
            char ch;

            while (i < _arg.Length)
            {
                ch = _arg[i];

                switch (state)
                {
                    case 1:
                        if (Array.IndexOf(CommandChars, ch) >= 0)
                        {
                            state = 2;
                        }
                        else
                        {
                            return null;
                        }
                        break;
                    case 2:
                        if (Array.IndexOf(CommandAndArgSeparator, ch) >= 0)
                        {
                            state = 3;
                        }
                        else
                        {
                            cmd += ch;
                        }
                        break;
                    case 3:
                        if (Array.IndexOf(CommandAndArgSeparator, ch) >= 0)
                        {
                            if (valueStarted)
                            {
                                value += ch;
                            }
                        }
                        else
                        {
                            valueStarted = true;
                            value += ch;
                        }

                        break;
                }

                i++;
            }

            cmd = cmd.Trim();

            if (Commands.Length > 0)
            {
                var cmdFound = false;
                var cmdIndex = 0;

                foreach (var _cmd in Commands)
                {
                    if (string.Compare(_cmd, cmd, (Config.CaseSensitive ? StringComparison.InvariantCulture: StringComparison.InvariantCultureIgnoreCase)) == 0)
                    {
                        cmdFound = true;
                        cmd = _cmd;
                        break;
                    }

                    cmdIndex++;
                }

                if (cmdFound)
                {
                    if (CommandShortNames.Length > 0 && cmdIndex >= 0 && cmdIndex < CommandShortNames.Length)
                    {
                        cmdShortName = CommandShortNames[cmdIndex];
                    }
                }
                else
                {
                    cmdIndex = 0;

                    foreach (var _cmd in CommandShortNames)
                    {
                        if (string.Compare(_cmd, cmd, (Config.CaseSensitive ? StringComparison.InvariantCulture : StringComparison.InvariantCultureIgnoreCase)) == 0)
                        {
                            cmdFound = true;
                            cmdShortName = cmd;
                            break;
                        }

                        cmdIndex++;
                    }

                    if (cmdFound)
                    {
                        if (Commands.Length > 0 && cmdIndex >= 0 && cmdIndex < Commands.Length)
                        {
                            cmd = Commands[cmdIndex];
                        }
                    }

                    if (!cmdFound)
                    {
                        valid = !Config.IgnoreInvalidCommands;
                        cmd = valid ? cmdShortName: "";
                    }
                }
            }

            if (valid)
            {
                return new ConsoleArg { Command = cmd, CommandShortName = cmdShortName, Arg = value };
            }
            else
            {
                return null;
            }
        }
        public List<ConsoleArg> Parse(string[] args)
        {
            if (!string.IsNullOrEmpty(Config.Commands))
            {
                Commands = Config.Commands.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                Commands = new string[] { };
            }

            if (!string.IsNullOrEmpty(Config.Commands))
            {
                CommandShortNames = Config.CommandShortNames.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            else
            {
                CommandShortNames = new string[] { };
            }

            CommandChars = Config.CommandChars.ToCharArray();
            CommandAndArgSeparator = Config.CommandAndArgSeparator.ToCharArray();

            var result = new List<ConsoleArg>();

            if (args != null)
            {
                foreach (var arg in args)
                {
                    var x = Parse(arg);

                    if (x != null)
                    {
                        var add = true;
                        ConsoleArg existing = null;

                        if (Config.CaseSensitive)
                        {
                            existing =
                                result.FirstOrDefault(
                                    ca => string.Compare(ca.Command, x.Command, StringComparison.InvariantCulture) == 0);
                        }
                        else
                        {
                            existing = result.FirstOrDefault(ca => ca.Command == x.Command);
                        }

                        if (existing == null)
                        {
                            if (Config.CaseSensitive)
                            {
                                existing =
                                    result.FirstOrDefault(
                                        ca =>
                                            string.Compare(ca.Command, x.CommandShortName,
                                                StringComparison.InvariantCulture) == 0);
                            }
                            else
                            {
                                existing = result.FirstOrDefault(ca => ca.Command == x.CommandShortName);
                            }
                        }

                        if (existing != null)
                        {
                            if (Config.IgnoreDuplicateCommands)
                            {
                                if (!Config.TakeFirstCommandOccurance)
                                {
                                    existing.Arg = x.Arg;
                                }
                                add = false;
                            }
                        }

                        if (add)
                        {
                            result.Add(x);
                        }
                    }
                    else
                    {
                        if (!string.IsNullOrEmpty(arg) && result.Count > 0 && CommandAndArgSeparator.Contains(' '))
                        {
                            var last = result[result.Count - 1];

                            if (string.IsNullOrEmpty(last.Arg))
                            {
                                last.Arg = arg.Trim();
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
