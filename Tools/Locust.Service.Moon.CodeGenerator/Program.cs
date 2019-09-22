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
using RazorEngine;
using RazorEngine.Templating;

namespace Locust.Service.Moon.CodeGenerator
{
    public class GeneratorOptions
    {
        public GeneratorConfig Config { get; set; }
        public string Template { get; set; }
        public string OutputDir { get; set; }
        public bool Folderized { get; set; }
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

                if (Int32.TryParse(row, out r) && r >= 0 && r < Config.Services.Count)
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

                if (Int32.TryParse(row, out r) && r >= 0 && r < Config.Services.Count)
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
        public bool? NoRunAsync { get; set; }
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
        static ILogger logger;
        static IExceptionLogger exceptionLogger;
        static ServiceResponse<GeneratorConfig> GetConfig(string configFilename)
        {
            var result = new ServiceResponse<GeneratorConfig>();

            try
            {
                var content = File.ReadAllText(configFilename);

                result.Data = JsonConvert.DeserializeObject<GeneratorConfig>(content);
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
                    Commands = "template,config,output,folderized,overwrite,rows,skips",
                    CommandShortNames = "t,c,o,f,w,r,s"
                });

            try
            {
                if (args == null || args.Length == 0)
                {
                    System.Console.WriteLine(@"Syntax: lsmcg [options]
    options:
        -template   or -t: specify template file (default = template.txt)
        -config     or -c: specify config file (default = config.json)
        -outputdir  or -o: specify output dir (default = /output)
        -folderized or -f: generate files in separated folders (default = false)
        -overwrite  or -w: overwrite output (default = false)
        -rows       or -r: specify config rows, generate only for specified rows (default = 'all')
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
                        var template = _args.FirstOrDefault(ca => ca.Command == "template")?.Arg;
                        var outputDir = _args.FirstOrDefault(ca => ca.Command == "output")?.Arg;

                        if (string.IsNullOrWhiteSpace(config))
                        {
                            config = "config.json";
                        }

                        if (string.IsNullOrWhiteSpace(template))
                        {
                            template = "template.txt";
                        }

                        if (string.IsNullOrWhiteSpace(config))
                        {
                            outputDir = "output";
                        }

                        var configPath = ApplicationPath.Root + "\\" + config;
                        var templatePath = ApplicationPath.Root + "\\" + template;

                        if (!File.Exists(configPath))
                        {
                            logger.Log($"config file {configPath} not found");
                            result.SetStatus("ConfigNotFound");
                            break;
                        }

                        if (!File.Exists(templatePath))
                        {
                            logger.Log($"template file {templatePath} not found");
                            result.SetStatus("TemplateNotFound");
                            break;
                        }

                        try
                        {
                            result.Data.Template = File.ReadAllText(templatePath);
                        }
                        catch (Exception e)
                        {
                            logger.Log("Reading template file failed");

                            exceptionLogger.LogException(e);

                            result.SetStatus("TemplateError");

                            break;
                        }
                        var gcr = GetConfig(configPath);

                        if (!gcr.IsSucceeded())
                        {
                            logger.Log("Reading and parsing config file failed");
                            result.SetStatus("ConfigError");
                            break;
                        }

                        if (gcr.Data == null || gcr.Data.Services == null || gcr.Data.Services.Count == 0)
                        {
                            logger.Log("config file has no entry");
                            result.SetStatus("ConfigEmpty");
                            break;
                        }

                        result.Data.OutputDir = outputDir;
                        result.Data.Config = gcr.Data;
                        result.Data.Folderized = SafeClrConvert.ToBoolean(_args.FirstOrDefault(ca => ca.Command == "folderized")?.Arg);
                        result.Data.Overwrite = SafeClrConvert.ToBoolean(_args.FirstOrDefault(ca => ca.Command == "overwrite")?.Arg);
                        result.Data.All = string.Compare(_args.FirstOrDefault(ca => ca.Command == "rows")?.Arg, "all") == 0;
                        if (!result.Data.All)
                        {
                            result.Data.SetRows(_args.FirstOrDefault(ca => ca.Command == "rows")?.Arg);
                        }
                        result.Data.SetSkips(_args.FirstOrDefault(ca => ca.Command == "skips")?.Arg);

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
        static ServiceResponse Generate(GeneratorOptions options)
        {
            var result = new ServiceResponse();
            var outputDir = Path.IsPathRooted(options.OutputDir) ? options.OutputDir: ApplicationPath.Root + "\\" + options.OutputDir;

            if (!Directory.Exists(outputDir))
            {
                try
                {
                    Directory.CreateDirectory(outputDir);
                }
                catch (Exception e)
                {
                    logger.Log("Cannot create output directory. Code generation aborted.");
                    exceptionLogger.LogException(e);

                    result.SetStatus("CreateOutputDirFailed");

                    return result;
                }
            }

            var row = 0;
            var success = 0;
            var failed = 0;

            foreach (var config in options.Config.Services)
            {
                var logPrefix = $"row = {row}, service = {config.Service}";

                if (!(options.Rows.Contains(row) || options.All) || options.Skips.Contains(row))
                {
                    logger.Log($"{logPrefix}: skipped.");
                    continue;
                }

                if (string.IsNullOrEmpty(config.Service))
                {
                    logger.Log($"{logPrefix}: No service specified");
                    continue;
                }

                if (string.IsNullOrEmpty(config.Namespace))
                {
                    config.Namespace = options.Config.Namespace;
                }

                if (string.IsNullOrEmpty(config.Namespace))
                {
                    logger.Log($"{logPrefix}: Namespace is empty and no default namespace is specified.");
                    continue;
                }

                if (!config.NoRunAsync.HasValue)
                {
                    config.NoRunAsync = options.Config.NoRunAsync;
                }

                if (config.Actions == null)
                {
                    config.Actions = new string[0];
                }

                if (config.Usings == null)
                {
                    config.Usings = new string[0];
                }

                var output = "";

                try
                {
                    output = Engine.Razor.RunCompile(options.Template, "templateKey", null, config);
                }
                catch (Exception e)
                {
                    failed++;

                    logger.Log($"{logPrefix}: code generation failed.");

                    exceptionLogger.LogException(e, $"{logPrefix}: CodeGenerationFailed");

                    continue;
                }

                var outputPath = "";

                if (options.Folderized)
                {
                    outputPath = outputDir + "\\" + config.Service + "\\" + config.Service + ".cs";

                    if (!Directory.Exists(outputDir + "\\" + config.Service))
                    {
                        try
                        {
                            Directory.CreateDirectory(outputDir + "\\" + config.Service);
                        }
                        catch (Exception e)
                        {
                            failed++;

                            logger.Log($"{logPrefix}: create directory failed");

                            exceptionLogger.LogException(e, $"{logPrefix}: CreateDirectoryError");

                            continue;
                        }
                    }
                }
                else
                {
                    outputPath = outputDir + "\\" + config.Service + ".cs";
                }

                if (File.Exists(outputPath) && !options.Overwrite)
                {
                    logger.Log($"{logPrefix}: file {config.Service}.cs exists. writing skipped.");

                    continue;
                }

                try
                {
                    File.WriteAllText(outputPath, output);

                    success++;
                }
                catch (Exception e)
                {
                    failed++;

                    logger.Log($"{logPrefix}: writing output failed");

                    exceptionLogger.LogException(e, $"{logPrefix}: WriteError");
                }
            }

            logger.Log("Code generation finished.\n");
            logger.Log($"Succeeded: {success}");
            logger.Log($"Failed: {failed}");
            logger.Log($"Skipped: {options.Config.Services.Count - (success + failed)}");

            if (options.InvalidRows.Count > 0)
            {
                logger.Log("Invalid rows specified: " + options.InvalidRows.Join(','));
            }
            if (options.InvalidSkips.Count > 0)
            {
                logger.Log("Invalid skips specified: " + options.InvalidRows.Join(','));
            }

            result.Succeeded();

            return result;
        }
        static void Main(string[] args)
        {
            var gor = GetOptions(args);

            //logger.Log(JsonConvert.SerializeObject(gor, Formatting.Indented));

            if (gor.IsSucceeded())
            {
                var gr = Generate(gor.Data);
            }
#if DEBUG
            System.Console.ReadKey();
#endif
        }
    }
}
