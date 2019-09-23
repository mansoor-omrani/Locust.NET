using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Locust.AppPath;
using Locust.ConsoleHelper;
using Locust.Conversion;
using Locust.Extensions;
using Locust.Logging;
using Locust.Service;
using Newtonsoft.Json;
using RazorEngine;
using RazorEngine.Templating;

namespace Locust.Service.Moon.CodeGenerator
{
    public class GeneratorConcreteItem
    {
        public string Suffix { get; set; }
        public string ActionSuffix { get; set; }
    }
    public class GeneratorTemplates
    {
        public string ConfigTemplate { get; set; }
        public string InterfaceTemplate { get; set; }
        public string BaseServiceTemplate { get; set; }
        public string ServiceTemplate { get; set; }
        public string TestServiceTemplate { get; set; }
        public string BaseActionTemplate { get; set; }
        public string ActionTemplate { get; set; }
        public string TestActionTemplate { get; set; }
        public string RequestTemplate { get; set; }
        public string ResponseTemplate { get; set; }
    }
    public class GeneratorOptions
    {
        public GeneratorConfig Config { get; set; }
        public string Template { get; set; }
        public GeneratorTemplates Templates { get; set; }
        public string OutputDir { get; set; }
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
            Templates = new GeneratorTemplates();
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
    public class GeneratorConfigItemActionItem
    {
        public string Name { get; set; }
        public string DataType { get; set; }
        public string[] Concretes { get; set; }
        public bool? NoRunAsync { get; set; }
    }
    public class GeneratorConfigItem
    {
        public string Folder { get; set; }
        public string Namespace { get; set; }
        public string Service { get; set; }
        public List<GeneratorConcreteItem> Concretes { get; set; }
        public bool? NoRunAsync { get; set; }
        public List<GeneratorConfigItemActionItem> Actions { get; set; }
        public string[] Usings { get; set; }
    }
    public class GeneratorConfig
    {
        public string Version { get; set; }
        public string Namespace { get; set; }
        public bool NoRunAsync { get; set; }
        public List<GeneratorConfigItem> Services { get; set; }
    }
    class Program
    {
        static string ConfigVersion => "1.0";
        static ILogger logger;
        static IExceptionLogger exceptionLogger;
        static ServiceResponse<GeneratorConfig> GetConfig(string configFilename)
        {
            var result = new ServiceResponse<GeneratorConfig>();

            try
            {
                var content = File.ReadAllText(configFilename);

                result.Data = JsonConvert.DeserializeObject<GeneratorConfig>(content);

                if (string.Compare(result.Data.Version, ConfigVersion, true) == 0)
                {
                    foreach (var service in result.Data.Services)
                    {
                        if (service.Concretes == null || service.Concretes.Count == 0)
                        {
                            service.Concretes = new List<GeneratorConcreteItem> { new GeneratorConcreteItem { Suffix = "Default", ActionSuffix = "Default" } };
                        }
                        if (service.Usings == null)
                        {
                            service.Usings = new string[0];
                        }
                        if (service.Actions == null)
                        {
                            service.Actions = new List<GeneratorConfigItemActionItem>();
                        }
                        foreach (var action in service.Actions)
                        {
                            if (action.Concretes == null || action.Concretes.Length == 0)
                            {
                                action.Concretes = new string[] { "Default" };
                            }
                        }
                    }
                    result.Succeeded();
                }
                else
                {
                    result.SetStatus("IncorrectConfigVersion");
                }
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
                    Commands = "templates,config,output,folderized,overwrite,rows,skips,generatetemplates,generateconfig",
                    CommandShortNames = "t,c,o,f,w,r,s,gt,gc"
                });

            try
            {
                if (args == null || args.Length == 0)
                {
                    System.Console.WriteLine(@"Syntax: lsmcg [[options]...]
    options:
        -templates          or -t: specify templates folder (default = internal templates)
        -config             or -c: specify config file (default = config.json)
        -outputdir          or -o: specify output dir (default = /output)
        -overwrite          or -w: overwrite output (default = false)
        -rows               or -r: specify config rows, generate only for specified rows (default = 'all')
        -skip               or -s: skip rows e.g. 1, 5, 11, 15 (default = '')
        -generatetemplate   or -gt: generate sample templates in '/templates' folder
        -generateconfig     or -gc: generate sample config e.g. /gc:myconfig.json (does not overwrite if exists)
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

                        if (string.IsNullOrWhiteSpace(outputDir))
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
                            logger.Log("Reading config file was not successful");
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
        static string CreateOutputDir(string outputDir)
        {
            var result = "";

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

                    result = "CreateOutputDirFailed";
                }
            }

            return result;
        }
        static string CreateServiceDir(string service, string serviceDir)
        {
            var result = "";

            if (!Directory.Exists(serviceDir))
            {
                try
                {
                    Directory.CreateDirectory(serviceDir);
                }
                catch (Exception e)
                {
                    logger.Log($"Cannot create directory for service '{service}'. Code generation skipped.");
                    exceptionLogger.LogException(e);

                    result = "CreateServiceDirFailed";
                }
            }

            return result;
        }
        static string CreateActionDir(string service, string action, string actionDir)
        {
            var result = "";

            if (!Directory.Exists(actionDir))
            {
                try
                {
                    Directory.CreateDirectory(actionDir);
                }
                catch (Exception e)
                {
                    logger.Log($"Cannot create directory for action '{action}' of service '{service}'. Code generation skipped.");
                    exceptionLogger.LogException(e);

                    result = "CreateActionDirFailed";
                }
            }

            return result;
        }
        static string GenerateCode(string logPrefix, string service, string name, string template, object model, string outputPath, bool overwrite)
        {
            var result = "";
            var output = "";

            try
            {
                output = Engine.Razor.RunCompile(template, $"template{service}{name}", null, model);
            }
            catch (Exception e)
            {
                logger.Log($"{logPrefix}: {name} code generation failed.");

                exceptionLogger.LogException(e, $"{logPrefix}: {name} CodeGenerationFailed");

                return result;
            }

            if (File.Exists(outputPath) && !overwrite)
            {
                logger.Log($"{logPrefix}: file {name}.cs exists. writing skipped.");

                return result;
            }

            try
            {
                File.WriteAllText(outputPath, output);
            }
            catch (Exception e)
            {
                logger.Log($"{logPrefix}: writing output failed");

                exceptionLogger.LogException(e, $"{logPrefix}: {name} WriteError");
            }

            return result;
        }
        static ServiceResponse Generate(GeneratorOptions options)
        {
            var result = new ServiceResponse();
            var outputDir = Path.IsPathRooted(options.OutputDir) ? options.OutputDir: ApplicationPath.Root + "\\" + options.OutputDir;
            var cor = CreateOutputDir(outputDir);

            if (!string.IsNullOrEmpty(cor))
            {
                result.SetStatus(cor);

                return result;
            }

            InitTemplates(options);

            var row = 0;
            var success = 0;
            var failed = 0;
            var warning = 0;
            var prevWarning = 0;

            foreach (var config in options.Config.Services)
            {
                var logPrefix = $"row = {row}, service = {config.Service}";
                var serviceDir = outputDir + "\\" + config.Folder;

                #region Validating Service Config

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

                if (string.IsNullOrEmpty(config.Folder))
                {
                    logger.Log($"{logPrefix}: No folder specified");
                    continue;
                }

                if (string.IsNullOrEmpty(config.Namespace))
                {
                    config.Namespace = options.Config.Namespace + "." + config.Folder;
                }
                else
                {
                    if (config.Namespace == ".")
                    {
                        logger.Log($"{logPrefix}: invalid namespace '{config.Namespace}'");
                        continue;
                    }

                    if (config.Namespace[0] == '.')
                    {
                        config.Namespace = (options.Config.Namespace?.Trim() + config.Namespace?.Trim());
                    }
                }

                if (string.IsNullOrEmpty(config.Namespace) || config.Namespace == ".")
                {
                    logger.Log($"{logPrefix}: Namespace is empty and no default namespace is specified.");
                    continue;
                }

                if (!config.NoRunAsync.HasValue)
                {
                    config.NoRunAsync = options.Config.NoRunAsync;
                }

                var csr = CreateServiceDir(config.Service, serviceDir);

                if (!string.IsNullOrEmpty(csr))
                {
                    result.SetStatus(csr);

                    continue;
                }

                #endregion

                var gcr = GenerateCode(logPrefix,
                                        config.Service,
                                        "Config",
                                        options.Templates.ConfigTemplate,
                                        new { config.Namespace, config.Service },
                                        serviceDir + "\\Config.cs",
                                        options.Overwrite);
                if (!string.IsNullOrEmpty(gcr))
                {
                    prevWarning++;
                }

                var gir = GenerateCode(logPrefix,
                                        config.Service,
                                        "Interface",
                                        options.Templates.InterfaceTemplate,
                                        config,
                                        serviceDir + "\\Interface.cs",
                                        options.Overwrite);
                if (!string.IsNullOrEmpty(gir))
                {
                    prevWarning++;
                }

                var gbsr = GenerateCode(logPrefix,
                                        config.Service,
                                        "BaseService",
                                        options.Templates.BaseServiceTemplate,
                                        config,
                                        serviceDir + "\\BaseService.cs",
                                        options.Overwrite);
                if (!string.IsNullOrEmpty(gbsr))
                {
                    prevWarning++;
                }

                var i = 0;

                foreach (var concrete in config.Concretes)
                {
                    if (string.IsNullOrWhiteSpace(concrete.Suffix))
                    {
                        logger.Log($"{logPrefix}: concrete {i} has no suffix. skipped.");
                        continue;
                    }

                    if (string.IsNullOrWhiteSpace(concrete.ActionSuffix))
                    {
                        concrete.ActionSuffix = "Default";
                    }

                    var gcsr = GenerateCode(logPrefix,
                                        config.Service,
                                        $"{concrete.Suffix}Service",
                                        options.Templates.ServiceTemplate,
                                        new { config.Usings, config.Namespace, config.Service, config.Actions, concrete.Suffix, concrete.ActionSuffix },
                                        serviceDir + $"\\{concrete.Suffix}Service.cs",
                                        options.Overwrite);
                    if (!string.IsNullOrEmpty(gcsr))
                    {
                        prevWarning++;
                    }

                    i++;
                }

                i = 0;

                foreach (var action in config.Actions)
                {
                    if (string.IsNullOrEmpty(action.Name))
                    {
                        logger.Log($"{logPrefix}: action {i} is empty. skipped.");
                        continue;
                    }

                    var actionDir = serviceDir + "\\" + action.Name;
                    var car = CreateActionDir(config.Service, action.Name, actionDir);

                    if (string.IsNullOrEmpty(car))
                    {
                        var grqr = GenerateCode(logPrefix,
                                            config.Service,
                                            "Request",
                                            options.Templates.RequestTemplate,
                                            new { config.Namespace, config.Service, Action = action.Name },
                                            actionDir + "\\Request.cs",
                                            options.Overwrite);
                        if (!string.IsNullOrEmpty(grqr))
                        {
                            prevWarning++;
                        }

                        var grsr = GenerateCode(logPrefix,
                                            config.Service,
                                            "Response",
                                            options.Templates.ResponseTemplate,
                                            new { config.Namespace, config.Service, Action = action.Name, action.DataType },
                                            actionDir + "\\Response.cs",
                                            options.Overwrite);
                        if (!string.IsNullOrEmpty(grsr))
                        {
                            prevWarning++;
                        }

                        var gbar = GenerateCode(logPrefix,
                                            config.Service,
                                            "BaseAction",
                                            options.Templates.BaseActionTemplate,
                                            new { config.Namespace, config.Service, Action = action.Name, config.Usings },
                                            actionDir + "\\BaseAction.cs",
                                            options.Overwrite);
                        if (!string.IsNullOrEmpty(gbar))
                        {
                            prevWarning++;
                        }

                        var j = 0;

                        foreach (var concrete in action.Concretes)
                        {
                            if (string.IsNullOrWhiteSpace(concrete))
                            {
                                logger.Log($"{logPrefix}: concrete {j} in action {action.Name} is empty. skipped.");
                                continue;
                            }

                            var gar = GenerateCode(logPrefix,
                                                config.Service,
                                                $"{concrete}Action",
                                                options.Templates.BaseActionTemplate,
                                                new { config.Namespace, config.Service, Action = action.Name, config.Usings, Suffix = concrete },
                                                actionDir + $"\\{concrete}Action.cs",
                                                options.Overwrite);
                            if (!string.IsNullOrEmpty(gar))
                            {
                                prevWarning++;
                            }
                        }
                    }
                    else
                    {
                        prevWarning++;
                    }

                    i++;
                }

                row++;
            }

            logger.Log("Code generation finished.\n");
            logger.Log($"Succeeded: {success}");
            logger.Log($"Failed: {failed}");
            logger.Log($"Warnings: {warning}");
            logger.Log($"Skipped: {options.Config.Services.Count - (success + failed + warning)}");

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
        static string ReadTemplate(string name)
        {
            var result = "";
            var a = Assembly.GetExecutingAssembly();

            try
            {
                result = a.GetResourceString($"Templates.{name}");
            }
            catch (Exception e)
            {
                logger.Log($"Error reading template resource {name}");
                exceptionLogger.LogException(e, $"template resource error: {name}");
            }
            return result;
        }
        static string ReadTemplateFileOrResource(string name)
        {
            var result = "";
            var path = ApplicationPath.Root + "\\templates\\" + name;

            if (File.Exists(path))
            {
                try
                {
                    result = File.ReadAllText(path);
                }
                catch (Exception e)
                {
                    logger.Log($"Error reading template file {name}");
                    exceptionLogger.LogException(e, $"template file error: {name}");
                    logger.Log("Revert to internal template ...");

                    result = ReadTemplate(name);
                }
            }
            else
            {
                result = ReadTemplate(name);
            }

            return result;
        }
        static void InitTemplates(GeneratorOptions options)
        {
            if (Directory.Exists(ApplicationPath.Root + "\\" + "templates"))
            {
                options.Templates.ActionTemplate = ReadTemplateFileOrResource("Action.txt");
                options.Templates.BaseActionTemplate = ReadTemplateFileOrResource("BaseAction.txt");
                options.Templates.BaseServiceTemplate = ReadTemplateFileOrResource("BaseService.txt");
                options.Templates.ConfigTemplate = ReadTemplateFileOrResource("Config.txt");
                options.Templates.InterfaceTemplate = ReadTemplateFileOrResource("Interface.txt");
                options.Templates.RequestTemplate = ReadTemplateFileOrResource("Request.txt");
                options.Templates.ResponseTemplate = ReadTemplateFileOrResource("Response.txt");
                options.Templates.ServiceTemplate = ReadTemplateFileOrResource("Service.txt");
                options.Templates.TestActionTemplate = ReadTemplateFileOrResource("TestAction.txt");
                options.Templates.TestServiceTemplate = ReadTemplateFileOrResource("TestService.txt");
            }
            else
            {
                options.Templates.ActionTemplate = ReadTemplate("Action.txt");
                options.Templates.BaseActionTemplate = ReadTemplate("BaseAction.txt");
                options.Templates.BaseServiceTemplate = ReadTemplate("BaseService.txt");
                options.Templates.ConfigTemplate = ReadTemplate("Config.txt");
                options.Templates.InterfaceTemplate = ReadTemplate("Interface.txt");
                options.Templates.RequestTemplate = ReadTemplate("Request.txt");
                options.Templates.ResponseTemplate = ReadTemplate("Response.txt");
                options.Templates.ServiceTemplate = ReadTemplate("Service.txt");
                options.Templates.TestActionTemplate = ReadTemplate("TestAction.txt");
                options.Templates.TestServiceTemplate = ReadTemplate("TestService.txt");
            }
        }
        static void Start(string[] args)
        {
            var gor = GetOptions(args);

            //logger.Log(JsonConvert.SerializeObject(gor, Formatting.Indented));

            if (gor.IsSucceeded())
            {
                var gr = Generate(gor.Data);
            }
        }
        static void Main(string[] args)
        {
            Start(args);
#if DEBUG
            System.Console.ReadKey();
#endif
        }
    }
}
