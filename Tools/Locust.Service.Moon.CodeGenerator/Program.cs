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
        public bool Partial { get; set; }
    }
    public class GeneratorTemplates
    {
        public string ConfigTemplate { get; set; }
        public string InterfaceTemplate { get; set; }
        public string BaseServiceTemplate { get; set; }
        public string BaseServicePartialTemplate { get; set; }
        public string ServiceTemplate { get; set; }
        public string ServicePartialTemplate { get; set; }
        public string TestServiceTemplate { get; set; }
        public string BaseActionTemplate { get; set; }
        public string BaseActionPartialTemplate { get; set; }
        public string ActionTemplate { get; set; }
        public string ActionPartialTemplate { get; set; }
        public string TestActionTemplate { get; set; }
        public string RequestTemplate { get; set; }
        public string ResponseTemplate { get; set; }
    }
    public class GeneratorOptions
    {
        public GeneratorConfig Config { get; set; }
        public string TemplateFolder { get; set; }
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
        public string Request { get; set; }
        public string Response { get; set; }
        public bool? NoDefaultAsync { get; set; }
        public bool PartialBase { get; set; }
        public bool PartialRequest { get; set; }
        public bool PartialResponse { get; set; }
        public string[] Concretes { get; set; }
    }
    public class GeneratorConfigItem
    {
        public string Folder { get; set; }
        public string Namespace { get; set; }
        public bool PartialConfig { get; set; }
        public bool PartialInterface { get; set; }
        public bool PartialService { get; set; }
        public bool PartialServiceBase { get; set; }
        public string Service { get; set; }
        public List<GeneratorConcreteItem> Concretes { get; set; }
        public List<GeneratorConfigItemActionItem> Actions { get; set; }
        public string[] Usings { get; set; }
    }
    public class GeneratorConfig
    {
        public string Version { get; set; }
        public string Namespace { get; set; }
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
        static void GenerateTemplates(string folder = "templates")
        {
            Action<string> generateTemplate = name =>
            {
                var template = ReadTemplate($"{name}.txt");

                try
                {
                    var filepath = $"{ApplicationPath.Root}\\templates\\{name}.txt";

                    if (!File.Exists(filepath))
                    {
                        File.WriteAllText(filepath, template);
                        logger.Log($"Template {name} generated.");
                    }
                    else
                    {
                        logger.Log($"Template {name} already exists in templates folder");
                    }
                }
                catch (Exception e)
                {
                    logger.Log($"Creating template {name} failed");
                    exceptionLogger.LogException(e, $"name: {name}");
                }
            };

            var dir = Path.IsPathRooted(folder) ? folder : ApplicationPath.Root + "\\" + folder;

            logger.Log($"Creating directory {folder} ...");

            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                    logger.Log($"created.");
                }
                catch (Exception e)
                {
                    logger.Log($"Creating template folder {folder} failed");
                    exceptionLogger.LogException(e, dir);

                    return;
                }
            }
            else
            {
                logger.Log($"Directory {folder} already exists.");
            }

            logger.Log($"Generating templates ...");

            generateTemplate("Config");
            generateTemplate("Interface");
            generateTemplate("BaseService");
            generateTemplate("BaseService.Partial");
            generateTemplate("Service");
            generateTemplate("Service.Partial");
            generateTemplate("Request");
            generateTemplate("Response");
            generateTemplate("BaseAction");
            generateTemplate("BaseAction.Partial");
            generateTemplate("Action");
            generateTemplate("Action.Partial");
            generateTemplate("TestAction");
            generateTemplate("TestService");

            logger.Log($"Finished");
        }
        static void GenerateSampleConfig(string name = "config.sample.json")
        {
            var a = Assembly.GetExecutingAssembly();

            try
            {
                var result = a.GetResourceString("Locust.Service.Moon.CodeGenerator", $"config.sample.json");

                try
                {
                    var filepath = ApplicationPath.Root + $"\\{name}";

                    if (!File.Exists(filepath))
                    {
                        File.WriteAllText(filepath, result);
                        logger.Log($"sample config file created as {name}");
                    }
                    else
                    {
                        logger.Log($"config.sample.json already exists.");
                    }
                }
                catch (Exception e)
                {
                    logger.Log($"generating sample config failed. see error logs.");
                    exceptionLogger.LogException(e, $"Writing config.sample.json failed");
                }
            }
            catch (Exception e)
            {
                logger.Log($"reading sample config resource failed. see logs.");
                exceptionLogger.LogException(e, $"resource error: config.sample.json");
            }
        }
        static Program()
        {
            logger = new ConsoleLogger(); //new DynamicLogger();
            exceptionLogger = new FileExceptionLogger("exceptions.log"); // new DynamicExceptionLogger();
        }
        static ServiceResponse<GeneratorOptions> GetOptions(string[] args)
        {
            var result = new ServiceResponse<GeneratorOptions>();

            result.Data = new GeneratorOptions();

            var cap = new ConsoleArgParser(
                new ConsoleArgParserConfig
                {
                    Commands = "version,ver,templates,config,output,overwrite,rows,skips,generatetemplates,generateconfig",
                    CommandShortNames = "v,ver,t,c,o,w,r,s,gt,gc"
                });

            try
            {
                if (args == null || args.Length == 0)
                {
                    System.Console.WriteLine(@"Syntax: lsmcg [[options]...]
    options:
        - version           or -v : show version
        -templates          or -t : specify external templates folder
                                    (default = don't use external templates, use internal templates)
        -config             or -c : specify config file (relative or absolute path with filename)
                                    (default = config.json)
        -outputdir          or -o : specify output dir (default = /output)
        -overwrite          or -w : overwrite output (default = false)
        -rows               or -r : specify config rows, generate only for specified rows
                                    (default = 'all': generate all services)
        -skips              or -s : skip rows e.g. 1, 5, 11, 15 (default = '')
        -generatetemplates  or -gt: {folder} generate sample templates in {folder} (relative or absolute path).
                                    default folder = /templates
        -generateconfig     or -gc: generate sample config e.g. /gc:myconfig.json (does not overwrite if exists)
");
                    result.SetStatus("ShowHelp");
                }
                else
                {
                    var _args = cap.Parse(args);

                    //logger.Log(JsonConvert.SerializeObject(_args, Formatting.Indented));

                    do
                    {
                        if (_args.FirstOrDefault(ca => ca.Command[0] == 'v' || ca.Command[0] == 'V') != null)
                        {
                            logger.Log($"Locust Service Moon Code Generator version {Assembly.GetExecutingAssembly().GetVersion()}");
                            break;
                        }
                        var gc = _args.FirstOrDefault(ca => string.Compare(ca.Command, "generateconfig", true) == 0);
                        if (gc != null)
                        {
                            if (!string.IsNullOrEmpty(gc.Arg))
                            {
                                GenerateSampleConfig(gc.Arg);
                            }
                            else
                            {
                                GenerateSampleConfig();
                            }
                            break;
                        }

                        var gt = _args.FirstOrDefault(ca => string.Compare(ca.Command, "generatetemplates", true) == 0);
                        if (gt != null)
                        {
                            if (!string.IsNullOrEmpty(gt.Arg))
                            {
                                GenerateTemplates(gt.Arg);
                            }
                            else
                            {
                                GenerateTemplates();
                            }
                            break;
                        }

                        gt = _args.FirstOrDefault(ca => string.Compare(ca.Command, "templates", true) == 0);
                        if (gt != null)
                        {
                            result.Data.TemplateFolder = gt.Arg;
                        }
                        else
                        {
                            result.Data.TemplateFolder = "templates";
                        }

                        var config = _args.FirstOrDefault(ca => ca.Command == "config")?.Arg;
                        var outputDir = _args.FirstOrDefault(ca => ca.Command == "output")?.Arg;

                        if (string.IsNullOrWhiteSpace(config))
                        {
                            config = "config.json";
                        }

                        if (string.IsNullOrWhiteSpace(outputDir))
                        {
                            outputDir = "output";
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
        static string GenerateCode(string logPrefix, string service, string name, string template, object model, string outputPath, bool overwrite, ref int warning)
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

                warning++;

                return result;
            }

            if (File.Exists(outputPath) && !overwrite)
            {
                logger.Log($"{logPrefix}: file {name}.cs exists. writing skipped.");

                warning++;

                return result;
            }

            try
            {
                File.WriteAllText(outputPath, output);
            }
            catch (Exception e)
            {
                logger.Log($"{logPrefix}: writing output failed");

                warning++;

                exceptionLogger.LogException(e, $"{logPrefix}: {name} WriteError");
            }

            return result;
        }
        static ServiceResponse Generate(GeneratorOptions options)
        {
            var result = new ServiceResponse();
            var outputDir = Path.IsPathRooted(options.OutputDir) ? options.OutputDir : ApplicationPath.Root + "\\" + options.OutputDir;
            var cor = CreateOutputDir(outputDir);

            if (!string.IsNullOrEmpty(cor))
            {
                result.SetStatus(cor);

                return result;
            }

            InitTemplates(options);

            var row = 0;
            var success = 0;
            var partialSuccess = 0;
            var failures = 0;
            var skips = 0;
            var warnings = new int[options.Config.Services.Count];

            foreach (var config in options.Config.Services)
            {
                var logPrefix = $"row = {row}, service = {config.Service}";
                var serviceDir = outputDir + "\\" + config.Folder;
                warnings[row] = 0;

                #region Validating Service Config

                if (!(options.Rows.Contains(row) || options.All) || options.Skips.Contains(row))
                {
                    logger.Log($"{logPrefix}: skipped.");
                    skips++;
                    continue;
                }

                if (string.IsNullOrEmpty(config.Service))
                {
                    logger.Log($"{logPrefix}: No service specified");
                    failures++;
                    continue;
                }

                if (string.IsNullOrEmpty(config.Folder))
                {
                    logger.Log($"{logPrefix}: No folder specified");
                    failures++;
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
                    failures++;
                    continue;
                }

                var csr = CreateServiceDir(config.Service, serviceDir);

                if (!string.IsNullOrEmpty(csr))
                {
                    result.SetStatus(csr);
                    failures++;
                    continue;
                }

                #endregion

                var temp = 0;

                GenerateCode(logPrefix,
                             config.Service,
                             "Config",
                             options.Templates.ConfigTemplate,
                             new { config.Namespace, config.Service },
                             serviceDir + "\\Config.cs",
                             options.Overwrite,
                             ref warnings[row]);

                if (config.PartialConfig)
                {
                    GenerateCode(logPrefix,
                             config.Service,
                             "Config.Partial",
                             options.Templates.ConfigTemplate,
                             new { config.Namespace, config.Service },
                             serviceDir + "\\Config.Partial.cs",
                             false,
                             ref temp);
                }

                GenerateCode(logPrefix,
                             config.Service,
                             "Interface",
                             options.Templates.InterfaceTemplate,
                             config,
                             serviceDir + "\\Interface.cs",
                             options.Overwrite,
                             ref warnings[row]);

                if (config.PartialInterface)
                {
                    GenerateCode(logPrefix,
                             config.Service,
                             "Interface.Partial",
                             options.Templates.InterfaceTemplate,
                             config,
                             serviceDir + "\\Interface.Partial.cs",
                             false,
                             ref temp);
                }

                GenerateCode(logPrefix,
                             config.Service,
                             "BaseService",
                             options.Templates.BaseServiceTemplate,
                             config,
                             serviceDir + "\\BaseService.cs",
                             options.Overwrite,
                             ref warnings[row]);

                if (config.PartialServiceBase)
                {
                    GenerateCode(logPrefix,
                             config.Service,
                             "BaseService.Partial",
                             options.Templates.BaseServicePartialTemplate,
                             config,
                             serviceDir + "\\BaseService.Partial.cs",
                             false,
                             ref temp);
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

                    GenerateCode(logPrefix,
                                 config.Service,
                                 $"{concrete.Suffix}Service",
                                 options.Templates.ServiceTemplate,
                                 new { config.Usings, config.Namespace, config.Service, config.Actions, concrete.Suffix, concrete.ActionSuffix },
                                 serviceDir + $"\\{concrete.Suffix}Service.cs",
                                 options.Overwrite,
                                 ref warnings[row]);

                    if (concrete.Partial)
                    {
                        GenerateCode(logPrefix,
                                 config.Service,
                                 $"{concrete.Suffix}Service.Partial",
                                 options.Templates.ServicePartialTemplate,
                                 new { config.Usings, config.Namespace, config.Service, concrete.Suffix },
                                 serviceDir + $"\\{concrete.Suffix}Service.Partial.cs",
                                 false,
                                 ref temp);
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
                        GenerateCode(logPrefix,
                                     config.Service,
                                     "Request",
                                     options.Templates.RequestTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.Request, config.Usings },
                                     actionDir + "\\Request.cs",
                                     options.Overwrite,
                                     ref warnings[row]);

                        if (action.PartialRequest)
                        {
                            GenerateCode(logPrefix,
                                     config.Service,
                                     "Request.Partial",
                                     options.Templates.RequestTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.Request, config.Usings },
                                     actionDir + "\\Request.Partial.cs",
                                     false,
                                     ref temp);
                        }

                        GenerateCode(logPrefix,
                                     config.Service,
                                     "Response",
                                     options.Templates.ResponseTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.Response, config.Usings },
                                     actionDir + "\\Response.cs",
                                     options.Overwrite,
                                     ref warnings[row]);

                        if (action.PartialResponse)
                        {
                            GenerateCode(logPrefix,
                                     config.Service,
                                     "Response.Partial",
                                     options.Templates.ResponseTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.Response, config.Usings },
                                     actionDir + "\\Response.Partial.cs",
                                     false,
                                     ref warnings[row]);
                        }

                        GenerateCode(logPrefix,
                                     config.Service,
                                     "BaseAction",
                                     options.Templates.BaseActionTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, config.Usings },
                                     actionDir + "\\BaseAction.cs",
                                     options.Overwrite,
                                     ref warnings[row]);

                        if (action.PartialBase)
                        {
                            GenerateCode(logPrefix,
                                     config.Service,
                                     "BaseAction.Partial",
                                     options.Templates.BaseActionPartialTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, config.Usings },
                                     actionDir + "\\BaseAction.Partial.cs",
                                     false,
                                     ref temp);
                        }

                        var j = 0;

                        foreach (var concrete in action.Concretes)
                        {
                            if (string.IsNullOrWhiteSpace(concrete))
                            {
                                logger.Log($"{logPrefix}: concrete {j} in action {action.Name} is empty. skipped.");
                                continue;
                            }

                            GenerateCode(logPrefix,
                                         config.Service,
                                         $"{concrete}Action",
                                         options.Templates.ActionTemplate,
                                         new { config.Namespace, config.Service, Action = action.Name, config.Usings, Suffix = concrete },
                                         actionDir + $"\\{concrete}Action.cs",
                                         options.Overwrite,
                                         ref warnings[row]);

                            GenerateCode(logPrefix,
                                         config.Service,
                                         $"{concrete}Action.Partial",
                                         options.Templates.ActionPartialTemplate,
                                         new { config.Namespace, config.Service, Action = action.Name, config.Usings, Suffix = concrete, action.NoDefaultAsync },
                                         actionDir + $"\\{concrete}Action.Partial.cs",
                                         false,
                                         ref temp);
                        }
                    }
                    else
                    {
                        warnings[row]++;
                    }

                    i++;
                }

                if (warnings[row] == 0)
                {
                    success++;
                }
                else
                {
                    partialSuccess++;
                }

                row++;
            }

            logger.Log("Code generation finished.\n");
            logger.Log($"Succeeded: {success}");
            logger.Log($"Failed: {failures}");
            logger.Log($"Warnings:");

            warnings.ForEach((i, n) => {
                if (n > 0)
                {
                    logger.Log($"    {i}. warnings: {n}");
                }
            });

            logger.Log($"Skipped: {skips}");

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
                result = a.GetResourceString("Locust.Service.Moon.CodeGenerator", $"InternalTemplates.{name}");
            }
            catch (Exception e)
            {
                logger.Log($"Error reading template resource {name}");
                exceptionLogger.LogException(e, $"template resource error: {name}");
            }
            return result;
        }
        static string ReadTemplateFileOrResource(string templatePath, string name)
        {
            var result = "";
            var path = templatePath + "\\" + name;

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
            var templatePath = Path.IsPathRooted(options.TemplateFolder) ? options.TemplateFolder: ApplicationPath.Root + "\\" + options.TemplateFolder;

            if (Directory.Exists(templatePath))
            {
                options.Templates.ActionTemplate = ReadTemplateFileOrResource(templatePath, "Action.txt");
                options.Templates.ActionPartialTemplate = ReadTemplateFileOrResource(templatePath, "Action.Partial.txt");
                options.Templates.BaseActionTemplate = ReadTemplateFileOrResource(templatePath, "BaseAction.txt");
                options.Templates.BaseActionPartialTemplate = ReadTemplateFileOrResource(templatePath, "BaseAction.Partial.txt");
                options.Templates.BaseServiceTemplate = ReadTemplateFileOrResource(templatePath, "BaseService.txt");
                options.Templates.BaseServicePartialTemplate = ReadTemplateFileOrResource(templatePath, "BaseService.Partial.txt");
                options.Templates.ConfigTemplate = ReadTemplateFileOrResource(templatePath, "Config.txt");
                options.Templates.InterfaceTemplate = ReadTemplateFileOrResource(templatePath, "Interface.txt");
                options.Templates.RequestTemplate = ReadTemplateFileOrResource(templatePath, "Request.txt");
                options.Templates.ResponseTemplate = ReadTemplateFileOrResource(templatePath, "Response.txt");
                options.Templates.ServiceTemplate = ReadTemplateFileOrResource(templatePath, "Service.txt");
                options.Templates.ServicePartialTemplate = ReadTemplateFileOrResource(templatePath, "Service.Partial.txt");
                options.Templates.TestActionTemplate = ReadTemplateFileOrResource(templatePath, "TestAction.txt");
                options.Templates.TestServiceTemplate = ReadTemplateFileOrResource(templatePath, "TestService.txt");
            }
            else
            {
                options.Templates.ActionTemplate = ReadTemplate("Action.txt");
                options.Templates.ActionPartialTemplate = ReadTemplate("Action.Partial.txt");
                options.Templates.BaseActionTemplate = ReadTemplate("BaseAction.txt");
                options.Templates.BaseActionPartialTemplate = ReadTemplate("BaseAction.Partial.txt");
                options.Templates.BaseServiceTemplate = ReadTemplate("BaseService.txt");
                options.Templates.BaseServicePartialTemplate = ReadTemplate("BaseService.Partial.txt");
                options.Templates.ConfigTemplate = ReadTemplate("Config.txt");
                options.Templates.InterfaceTemplate = ReadTemplate("Interface.txt");
                options.Templates.RequestTemplate = ReadTemplate("Request.txt");
                options.Templates.ResponseTemplate = ReadTemplate("Response.txt");
                options.Templates.ServiceTemplate = ReadTemplate("Service.txt");
                options.Templates.ServicePartialTemplate = ReadTemplate("Service.Partial.txt");
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
        static void test1(string[] args)
        {
            if (args != null && args.Length > 0)
            {
                var assembly = Assembly.GetExecutingAssembly();
                var resources = assembly.GetManifestResourceNames();

                Console.WriteLine($"Resources: {resources.Length}");

                foreach (var rn in resources)
                {
                    Console.WriteLine(rn);
                }

                try
                {
                    Console.WriteLine(assembly.GetResourceString("Locust.Service.Moon.CodeGenerator", args[0]));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
        static void Main(string[] args)
        {
            Start(args);
            //test1(args);

#if DEBUG
            System.Console.ReadKey();
#endif
        }
    }
}
