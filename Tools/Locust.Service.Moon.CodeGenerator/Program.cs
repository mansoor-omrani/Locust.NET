using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.AppPath;
using Locust.Console;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Logging;
using Locust.Service;
using Newtonsoft.Json;

namespace Locust.Service.Moon.CodeGenerator
{
    public class GeneratorOptions
    {
        public List<GeneratorConfigItem> Config { get; set; }
        public bool Overwrite { get; set; }
        public List<int> Rows { get; set; }
        public List<string> InvalidRows { get; set; }
        public List<int> Skips { get; set; }
        public List<string> InvalidSkips { get; set; }
        public bool All { get; set; }
        public GeneratorOptions()
        {
            Rows = new List<int>();
            InvalidRows = new List<string>();
            Skips = new List<int>();
            InvalidSkips = new List<string>();
        }
        public void SetRows(string rows)
        {
            var _rows = rows?.Split(',', MyStringSplitOptions.TrimAndRemoveEmptyEntries) ?? new string[0];

            foreach (var row in _rows)
            {
                var r = 0;

                if (Int32.TryParse(row, out r) && r >= 0 && r < Config.Count)
                {
                    Rows.Add(r);
                }
                else
                {
                    InvalidRows.Add(row);
                }
            }
        }
        public void SetSkips(string rows)
        {
            var _rows = rows?.Split(',', MyStringSplitOptions.TrimAndRemoveEmptyEntries) ?? new string[0];

            foreach (var row in _rows)
            {
                var r = 0;

                if (Int32.TryParse(row, out r) && r >= 0 && r < Config.Count)
                {
                    Skips.Add(r);
                }
                else
                {
                    InvalidSkips.Add(row);
                }
            }
        }
    }
    public class GeneratorConfigItem
    {
        public string Namespace { get; set; }
        public string Service { get; set; }
        public bool NoRunAsync { get; set; }
        public string[] Actions { get; set; }
        public string[] Usings { get; set; }
    }
    public class GeneratorConfig
    {
        public string Namespace { get; set; }
        public bool NoRunAsync { get; set; }
        public List<GeneratorConfigItem> Services { get; set; }
    }
    class Program
    {
        static GeneratorOptions options;
        static ILogger logger;
        static IExceptionLogger exceptionLogger;
        static ServiceResponse<List<GeneratorConfigItem>> GetConfig(string configFilename)
        {
            var result = new ServiceResponse<List<GeneratorConfigItem>>();

            try
            {
                var content = File.ReadAllText(configFilename);

                result.Data = JsonConvert.DeserializeObject<List<GeneratorConfigItem>>(content);
                result.Succeeded();
            }
            catch (Exception e)
            {
                result.Failed();

                exceptionLogger.LogException(e);
            }

            return result;
        }
        static Program()
        {
            logger = new DynamicLogger();
            exceptionLogger = new DynamicExceptionLogger();
        }
        static ServiceResponse<GeneratorOptions> GetOptions(string[] args)
        {
            var result = new ServiceResponse<GeneratorOptions>();

            result.Data = new GeneratorOptions();

            var cap = new ConsoleArgParser(
                new ConsoleArgParserConfig
                {
                    Commands = "config,overwrite,rows,skips",
                    CommandShortNames = "c,w,r,s"
                });

            try
            {
                if (args == null || args.Length == 0)
                {
                    System.Console.WriteLine(@"Syntax: lsmcg [options]
    options:
        -config     or -c: specify config file (default = config.json)
        -overwrite  or -w: overwrite output (default = false)
        -rows       or -r: specify config rows, generate only for specified rows (default = all)
        -skip       or -s: skip rows e.g. 1, 5, 11, 15 (default = '')
");
                    result.SetStatus("ShowHelp");
                }
                else
                {
                    var _args = cap.Parse(args);

                    do
                    {
                        var config = _args.FirstOrDefault(ca => ca.Command == "config")?.Arg;

                        if (string.IsNullOrEmpty(config))
                        {
                            config = "config.json";
                        }

                        if (string.IsNullOrEmpty(config))
                        {
                            logger.Log("config file not specified");
                            result.SetStatus("NoConfig");

                            break;
                        }

                        var configPath = ApplicationPath.Root + "\\" + config;

                        if (!File.Exists(configPath))
                        {
                            logger.Log($"config file {configPath} not found");
                            result.SetStatus("ConfigNotFound");
                            break;
                        }

                        var gcr = GetConfig(configPath);

                        if (!gcr.IsSucceeded())
                        {
                            logger.Log("Reading and parsing config file failed");
                            result.SetStatus("ConfigError");
                            break;
                        }

                        if (gcr.Data == null || gcr.Data.Count == 0)
                        {
                            logger.Log("config file has no entry");
                            result.SetStatus("ConfigEmpty");
                            break;
                        }

                        result.Data.Config = gcr.Data;
                        result.Data.Overwrite = SafeClrConvert.ToBoolean(_args.FirstOrDefault(ca => ca.Command == "overwrite").Arg);
                        result.Data.All = SafeClrConvert.ToBoolean(_args.FirstOrDefault(ca => ca.Command == "all").Arg);
                        result.Data.SetRows(_args.FirstOrDefault(ca => ca.Command == "rows").Arg);
                        result.Data.SetSkips(_args.FirstOrDefault(ca => ca.Command == "skips").Arg);

                        result.Succeeded();
                    }
                    while (false);
                }
            }
            catch (Exception e)
            {
                logger.Log("Generator encountered errors. See its logs");

                exceptionLogger.LogException(e);
            }
            
            return result;
        }
        static void Main(string[] args)
        {
            var gor = GetOptions(args);

            options = gor.Data;

            System.Console.WriteLine(JsonConvert.SerializeObject(gor, Formatting.Indented));
#if DEBUG
            System.Console.ReadKey();
#endif
        }
    }
}
