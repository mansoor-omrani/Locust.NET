﻿using System;
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
        public bool Default { get; set; }
        public Dictionary<string, string> ConfigProps { get; set; }
        public List<Dictionary<string, string>> Constructors { get; set; }
    }
    public class GeneratorTemplates
    {
        public string ConfigTemplate { get; set; }
        public string ConfigPartialTemplate { get; set; }
        public string BaseConfigTemplate { get; set; }
        public string BaseConfigPartialTemplate { get; set; }
        public string InterfaceTemplate { get; set; }
        public string InterfacePartialTemplate { get; set; }
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
        public string RequestPartialTemplate { get; set; }
        public string ResponseTemplate { get; set; }
        public string ResponsePartialTemplate { get; set; }
        public string RegistrationTemplate { get; set; }
        public string RegistrationPartialTemplate { get; set; }
    }
    public class GeneratorOptions
    {
        public GeneratorConfig Config { get; set; }
        public string TemplateFolder { get; set; }
        public GeneratorTemplates Templates { get; set; }
        public string OutputDir { get; set; }
        public bool GeneratePartials { get; set; }
        public bool Overwrite { get; set; }
        public string Extension { get; set; }
        public string TemplateExtension { get; set; }
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
            TemplateExtension = ".txt";
            Extension = ".cs";
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
        public string RequestModel { get; set; }
        public Dictionary<string, string> RequestProps { get; set; }
        public bool? ConfigBasedService { get; set; }
        public string ParentAction { get; set; }
        public string ResponseType { get; set; }
        public string RequestType { get; set; }
        public string ResponseData { get; set; }
        public Dictionary<string, string> ResponseProps { get; set; }
        public bool? DefaultAsync { get; set; }
        public bool PartialBase { get; set; }
        public bool PartialRequest { get; set; }
        public bool PartialResponse { get; set; }
        public string[] Concretes { get; set; }
        public string[] Usings { get; set; }
    }
    public class GeneratorConfigServiceConcreteItem
    {
        public string Namespace { get; set; }
        public List<Dictionary<string, string>> Constructors { get; set; }
        public List<List<string>> ParentConstructors { get; set; }
        public List<GeneratorConfigItemActionItem> Actions { get; set; }
        public string Service { get; set; }
        public string ConcreteService { get; set; }
        public string Suffix { get; set; }
        public string ActionSuffix { get; set; }
        public List<GeneratorConcreteItem> Concretes { get; set; }
        public string[] Usings { get; set; }
    }
    public class GeneratorConfigServiceItem
    {
        public string Folder { get; set; }
        public bool SingleService { get; set; }
        public string AbstractionDir { get; set; }
        public string ImplementationDir { get; set; }
        public string RegistrationDir { get; set; }
        public string Namespace { get; set; }
        public bool PartialConfig { get; set; }
        public List<Dictionary<string, string>> Constructors { get; set; }
        public List<List<string>> ParentConstructors { get; set; }
        public Dictionary<string, string> ConfigProps { get; set; }
        public bool? ConfigBasedService { get; set; }
        public string ParentConfig { get; set; }
        public string ParentService { get; set; }
        public string ParentInterface { get; set; }
        public string ParentAction { get; set; }
        public bool PartialInterface { get; set; }
        public bool PartialRegistration { get; set; }
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
        public string RegistrationDir { get; set; }
        public bool ConfigBasedService { get; set; }
        public string BaseParentService { get; set; }
        public string BaseParentAction { get; set; }
        public string BaseParentConfig { get; set; }
        public string AbstractionDir { get; set; }
        public string ImplementationDir { get; set; }
        public List<GeneratorConfigServiceItem> Services { get; set; }
        public string[] FrameworkUsings { get; set; }
        public string[] CommonUsings { get; set; }
        public GeneratorConfig()
        {
            ConfigBasedService = true;
        }
    }
    class Program
    {
        static string ConfigVersion => "1.1.0";
        static ILogger logger;
        static IExceptionLogger exceptionLogger;
        static GeneratorOptions Options { get; set; }
        static string[] SupportedExtensions => new string[] { ".cs" };
        static ServiceResponse<GeneratorConfig> GetConfig(string configFilename)
        {
            var result = new ServiceResponse<GeneratorConfig>();

            try
            {
                var content = File.ReadAllText(configFilename);

                result.Data = JsonConvert.DeserializeObject<GeneratorConfig>(content);

                if (result.Data.FrameworkUsings == null || result.Data.FrameworkUsings.Length == 0)
                {
                    result.Data.FrameworkUsings = new string[]
                    {
                        "Locust.Service",
                        "Locust.Service.Moon"
                    };
                }

                if (result.Data.CommonUsings == null || result.Data.CommonUsings.Length == 0)
                {
                    result.Data.CommonUsings = new string[]
                    {
                        "System",
                        "System.Linq",
                        "System.Text",
                        "System.Threading",
                        "System.Threading.Tasks",
                        "System.Collections.Generic"
                    };
                }

                if (string.IsNullOrEmpty(result.Data.Version) || string.Compare(result.Data.Version, ConfigVersion, true) == 0)
                {
                    foreach (var service in result.Data.Services)
                    {
                        if (service.Concretes == null || service.Concretes.Count == 0)
                        {
                            service.Concretes = new List<GeneratorConcreteItem> { new GeneratorConcreteItem { Suffix = "Default", ActionSuffix = "Default" } };
                        }

                        if (service.Usings == null)
                        {
                            service.Usings = new string[] { "Locust.Db", "Locust.Logging", "Locust.Caching" };
                        }

                        service.Usings = result.Data.FrameworkUsings.MergeWith(result.Data.CommonUsings).MergeWith(service.Usings);

                        if (service.ConfigProps == null)
                        {
                            service.ConfigProps = new Dictionary<string, string>();
                        }
                        if (string.IsNullOrEmpty(service.ParentService))
                        {
                            service.ParentService = $"BaseActionBasedService<{service.Service}BaseConfig>";
                        }
                        if (string.IsNullOrEmpty(service.ParentInterface))
                        {
                            service.ParentInterface = $"IService<{service.Service}BaseConfig>";
                        }
                        if (string.IsNullOrEmpty(service.ParentConfig))
                        {
                            service.ParentConfig = $"ServiceConfig";
                        }
                        if (string.IsNullOrEmpty(service.ParentAction))
                        {
                            service.ParentAction = $"ServiceAction";
                        }
                        if (!service.ConfigBasedService.HasValue)
                        {
                            service.ConfigBasedService = result.Data.ConfigBasedService;
                        }
                        if (service.ParentConstructors == null)
                        {
                            service.ParentConstructors = new List<List<string>>();

                            #region public BaseActionBasedService(TConfig config)
                            var d = new List<string>();

                            d.Add($"{service.Service}BaseConfig");

                            service.ParentConstructors.Add(d);
                            #endregion
                            #region BaseActionBasedService(TConfig config, ILogger logger, IExceptionLogger exceptionLogger)
                            d = new List<string>();

                            d.Add($"{service.Service}BaseConfig");
                            d.Add($"ILogger");
                            d.Add($"IExceptionLogger");

                            service.ParentConstructors.Add(d);
                            #endregion
                            #region BaseActionBasedService(TConfig config, ILogger logger, IExceptionLogger exceptionLogger, IDbHelper db)
                            d = new List<string>();

                            d.Add($"{service.Service}BaseConfig");
                            d.Add($"ILogger");
                            d.Add($"IExceptionLogger");
                            d.Add($"IDbHelper");

                            service.ParentConstructors.Add(d);
                            #endregion
                            #region BaseActionBasedService(TConfig config, ILogger logger, IExceptionLogger exceptionLogger, IDbHelper db, ICacheManager cache)
                            d = new List<string>();

                            d.Add($"{service.Service}BaseConfig");
                            d.Add($"ILogger");
                            d.Add($"IExceptionLogger");
                            d.Add($"IDbHelper");
                            d.Add($"ICacheManager");

                            service.ParentConstructors.Add(d);
                            #endregion
                        }
                        if (service.Constructors == null)
                        {
                            service.Constructors = new List<Dictionary<string, string>>
                                {
                                    new Dictionary<string, string> { ["config"] = $":{service.Service}BaseConfig" }
                                };
                        }
                        foreach (var concrete in service.Concretes)
                        {
                            if (concrete.Constructors == null || concrete.Constructors.Count == 0)
                            {
                                concrete.Constructors = new List<Dictionary<string, string>>();

                                foreach (var _ctor in service.Constructors)
                                {
                                    var d = new Dictionary<string, string>();

                                    foreach (var arg in _ctor)
                                    {
                                        var colonIndex = arg.Value.IndexOf(':');

                                        if (colonIndex != -1)
                                        {
                                            if (arg.Value.Substring(colonIndex + 1) == $"{service.Service}BaseConfig")
                                            {
                                                d.Add(arg.Key, $"{service.Service}{concrete.Suffix}Config:{arg.Value.Substring(colonIndex + 1)}");
                                            }
                                            else
                                            {
                                                d.Add(arg.Key, arg.Value);
                                            }
                                        }
                                        else
                                        {
                                            d.Add(arg.Key, arg.Value);
                                        }
                                    }

                                    concrete.Constructors.Add(d);
                                }
                            }
                        }

                        if (service.Actions == null)
                        {
                            service.Actions = new List<GeneratorConfigItemActionItem>();
                        }

                        foreach (var action in service.Actions)
                        {
                            if (action.Usings == null)
                            {
                                action.Usings = new string[0];
                            }

                            action.Usings = result.Data.FrameworkUsings.MergeWith(result.Data.CommonUsings).MergeWith(action.Usings);

                            if (action.Concretes == null || action.Concretes.Length == 0)
                            {
                                action.Concretes = new string[] { "Default" };
                            }
                            if (action.RequestProps == null)
                            {
                                action.RequestProps = new Dictionary<string, string>();
                            }
                            if (action.ResponseProps == null)
                            {
                                action.ResponseProps = new Dictionary<string, string>();
                            }
                            if (string.IsNullOrEmpty(action.RequestType))
                            {
                                action.RequestType = "ServiceRequest";
                            }
                            if (string.IsNullOrEmpty(action.ParentAction))
                            {
                                action.ParentAction = service.ParentAction;
                            }
                            if (!action.ConfigBasedService.HasValue)
                            {
                                action.ConfigBasedService = service.ConfigBasedService;
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
            var dir = Path.IsPathRooted(folder) ? folder : Environment.CurrentDirectory + "\\" + folder;

            logger.Log($"Creating templates directory {folder} ...");

            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                    logger.Log($"created.");
                }
                catch (Exception e)
                {
                    logger.Log($"Creating templates folder {folder} failed");
                    exceptionLogger.LogException(e, dir);

                    return;
                }
            }
            else
            {
                logger.Log($"already exists.");
            }

            Action<string> generateTemplate = name =>
            {
                try
                {
                    var template = ReadTemplate($"{name}.txt");

                    try
                    {
                        var filepath = $"{dir}\\{name}{Options.TemplateExtension}";

                        if (!File.Exists(filepath))
                        {
                            File.WriteAllText(filepath, template);
                            logger.Log($"Template {name} generated.");
                        }
                        else
                        {
                            logger.Log($"Template {name}{Options.TemplateExtension} already exists in templates folder");
                        }
                    }
                    catch (Exception e)
                    {
                        logger.Log($"Creating template {name}{Options.TemplateExtension} failed");
                        exceptionLogger.LogException(e, $"name: {name}{Options.TemplateExtension}");
                    }
                }
                catch (Exception)
                {
                    logger.Log($"Reading template {name}{Options.TemplateExtension} failed");
                }
            };

            logger.Log($"Generating templates ...");

            generateTemplate("Config");
            generateTemplate("Config.Partial");
            generateTemplate("BaseConfig");
            generateTemplate("BaseConfig.Partial");
            generateTemplate("Interface");
            generateTemplate("Interface.Partial");
            generateTemplate("BaseService");
            generateTemplate("BaseService.Partial");
            generateTemplate("Service");
            generateTemplate("Service.Partial");
            generateTemplate("Request");
            generateTemplate("Request.Partial");
            generateTemplate("Response");
            generateTemplate("Response.Partial");
            generateTemplate("BaseAction");
            generateTemplate("Registration");
            generateTemplate("Registration.Partial");
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
                var filepath = Environment.CurrentDirectory + $"\\{name}";

                try
                {
                    if (!File.Exists(filepath))
                    {
                        File.WriteAllText(filepath, result);
                        logger.Log($"sample config file created as {name}");
                    }
                    else
                    {
                        logger.Log($"{name} already exists at {Path.GetDirectoryName(filepath)}.");
                    }
                }
                catch (Exception e)
                {
                    logger.Log($"generating sample config failed. see error logs.");
                    exceptionLogger.LogException(e, $"Writing {filepath} failed");
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
            logger = new DynamicLogger();
            exceptionLogger = new DynamicExceptionLogger();
        }
        static ServiceResponse<GeneratorOptions> GetOptions(string[] args)
        {
            logger.Trace("Processing specified command-line arguments ...");

            var result = new ServiceResponse<GeneratorOptions>();

            Options = result.Data = new GeneratorOptions();

            var cap = new ConsoleArgParser(
                new ConsoleArgParserConfig
                {
                    Commands = "version,ver,templates,config,extension,templateextension,output,generatepartials,overwrite,rows,skips,generatetemplates,generateconfig",
                    CommandShortNames = "v,ver,t,c,e,te,o,gp,w,r,s,gt,gc"
                });

            try
            {
                if (args == null || args.Length == 0)
                {
                    System.Console.WriteLine(@"Syntax: lsmcg [[options]...]
    options:
        -version or -ver or or -v : show version
        -templates          or -t : specify external templates folder
                                    (default = don't use external templates, use internal templates)
        -config             or -c : specify config file (relative or absolute path with filename)
                                    (default = config.json)
        -extension          or -e : generated files extension (default = .cs)
        -templateextension  or -te: external template file extension (default = .txt)
        -outputdir          or -o : specify output dir (default = /output)
        -generatepartials   or -gp: generate .Partial files (default = false)
        -overwrite          or -w : overwrite output (default = false)
        -rows               or -r : specify config rows, generate only for specified rows
                                    (default = 'all': generate all services)
        -skips              or -s : skip rows e.g. 1, 5, 11, 15 (default = '')
        -generatetemplates  or -gt: {folder} generate sample templates in {folder} (relative or absolute path).
                                    default folder = /templates
                                    this switch ignores other switches and their args.
        -generateconfig     or -gc: generate sample config e.g. /gc:myconfig.json (does not overwrite existing config)
                                    this switch ignores other switches and their args.
");
                    result.SetStatus("ShowHelp");
                }
                else
                {
                    var _args = cap.Parse(args);

                    logger.Trace($"Found {_args.Count} command line arguments");

                    foreach (var _arg in _args)
                    {
                        logger.Debug($"\targ name: {_arg.Command}\targ value: {_arg.Arg}");
                    }

                    logger.Log("\n");
                    logger.Sys(_args);

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
                            Options.TemplateFolder = result.Data.TemplateFolder = gt.Arg;
                        }
                        else
                        {
                            Options.TemplateFolder = result.Data.TemplateFolder = "templates";
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

                        var configPath = Path.IsPathRooted(config) ? config : Environment.CurrentDirectory + "\\" + config;

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
                            result.SetStatus(gcr.Status);
                            break;
                        }

                        if (gcr.Data == null || gcr.Data.Services == null || gcr.Data.Services.Count == 0)
                        {
                            logger.Log("config file has no entry");
                            result.SetStatus("ConfigEmpty");
                            break;
                        }

                        var ea = _args.FirstOrDefault(ca => ca.Command == "extension");

                        if (ea != null)
                        {
                            if (string.IsNullOrEmpty(ea.Arg))
                            {
                                logger.Log("no extension is specified. used default (.cs)");
                                Options.Extension = result.Data.Extension = ".cs";
                            }
                            else
                            {
                                if (ea.Arg[0] != '.')
                                {
                                    logger.Log("extension should start with dot (.), e.g. .cs, .vb, etc.");
                                    break;
                                }

                                if (SupportedExtensions.FindIndexOf(ea.Arg, StringComparison.CurrentCultureIgnoreCase) < 0)
                                {
                                    logger.Log($"Currently internal templates are supported only for {SupportedExtensions.Join(',')}. No internal template found for {ea.Arg}. Use custom external templates.");
                                    break;
                                }
                                else
                                {
                                    Options.Extension = result.Data.Extension = ea.Arg.ToLower();
                                }
                            }
                        }
                        else
                        {
                            Options.Extension = result.Data.Extension = ".cs";
                        }

                        var ta = _args.FirstOrDefault(ca => ca.Command == "templateextension");

                        if (ta != null)
                        {
                            if (string.IsNullOrEmpty(ta.Arg))
                            {
                                logger.Log("no extension is specified for external templates. used default (.txt)");
                                Options.Extension = result.Data.Extension = ".txt";
                            }
                            else
                            {
                                if (ta.Arg[0] != '.')
                                {
                                    logger.Log("external template extension should start with dot (.), e.g. .txt, .cshtml");
                                    break;
                                }
                                else
                                {
                                    Options.TemplateExtension = result.Data.TemplateExtension = ta.Arg.ToLower();
                                }
                            }
                        }
                        else
                        {
                            Options.TemplateExtension = result.Data.TemplateExtension = ".txt";
                        }

                        Options.OutputDir = result.Data.OutputDir = outputDir;

                        Options.Config = result.Data.Config = gcr.Data;

                        var oa = _args.FirstOrDefault(ca => ca.Command == "overwrite");

                        if (oa != null)
                        {
                            Options.Overwrite = result.Data.Overwrite = string.IsNullOrEmpty(oa.Arg) || SafeClrConvert.ToBoolean(oa.Arg);
                        }

                        var cpa = _args.FirstOrDefault(ca => ca.Command == "generatepartials");

                        if (cpa != null)
                        {
                            Options.GeneratePartials = result.Data.GeneratePartials = string.IsNullOrEmpty(cpa.Arg) || SafeClrConvert.ToBoolean(cpa.Arg);
                        }

                        Options.All = result.Data.All = string.Compare(_args.FirstOrDefault(ca => ca.Command == "rows")?.Arg, "all") == 0;

                        if (!result.Data.All)
                        {
                            result.Data.SetRows(_args.FirstOrDefault(ca => ca.Command == "rows")?.Arg);
                            Options.SetRows(_args.FirstOrDefault(ca => ca.Command == "rows")?.Arg);
                        }

                        result.Data.SetSkips(_args.FirstOrDefault(ca => ca.Command == "skips")?.Arg);
                        Options.SetSkips(_args.FirstOrDefault(ca => ca.Command == "skips")?.Arg);

                        logger.Debug("Final generator options:");
                        logger.Debug(result.Data);

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
            return CreateDir("output", outputDir);
        }
        static string CreateRegistrationDir(string registrationDir)
        {
            return CreateDir("registration", registrationDir);
        }
        static string CreateAbstractionDir(string abstractionDir)
        {
            return CreateDir("abstraction", abstractionDir);
        }
        static string CreateImplementationDir(string implementationDir)
        {
            return CreateDir("implementation", implementationDir);
        }
        static string CreateDir(string name, string dir)
        {
            var result = "";

            if (!Directory.Exists(dir))
            {
                try
                {
                    Directory.CreateDirectory(dir);
                }
                catch (Exception e)
                {
                    logger.Log($"Cannot create {name} directory. Code generation aborted.");
                    exceptionLogger.LogException(e);

                    result = $"Create {name} Dir Failed";
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
        static string GenerateCode(string logPrefix, string service, string name, string ext, string template, object model, string outputPath, bool overwrite, ref int warning)
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
                logger.Log($"{logPrefix}: file {name}{ext} exists. writing skipped.");

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
            var outputDir = Path.IsPathRooted(options.OutputDir) ? options.OutputDir : Environment.CurrentDirectory + "\\" + options.OutputDir;
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

                var configFolder = string.IsNullOrEmpty(config.Folder) ? config.Service : config.Folder;
                
                var abstractionDir = string.IsNullOrEmpty(config.AbstractionDir) ? options.Config.AbstractionDir : config.AbstractionDir;
                var hasAbstractionDir = !string.IsNullOrEmpty(abstractionDir);

                abstractionDir = hasAbstractionDir ? (Path.IsPathRooted(abstractionDir) ? abstractionDir + "\\" + (config.SingleService ? "" : configFolder) :
                                        outputDir + "\\" + abstractionDir + "\\" + (config.SingleService ? "": configFolder)): outputDir + "\\" + configFolder;

                var implementationDir = string.IsNullOrEmpty(config.ImplementationDir) ? options.Config.ImplementationDir : config.ImplementationDir;
                var hasImplementationDir = !string.IsNullOrEmpty(implementationDir);
                
                implementationDir = hasImplementationDir ? (Path.IsPathRooted(implementationDir) ? implementationDir + "\\" + (config.SingleService ? "" : configFolder) :
                                        outputDir + "\\" + implementationDir + "\\" + (config.SingleService ? "" : configFolder)) : outputDir + "\\" + configFolder;

                //var serviceDir = outputDir + "\\" + configFolder;

                if (string.IsNullOrEmpty(config.Namespace))
                {
                    config.Namespace = options.Config.Namespace + "." + configFolder;
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

                var car = CreateServiceDir(config.Service, abstractionDir);

                if (!string.IsNullOrEmpty(car))
                {
                    result.SetStatus(car);
                    failures++;
                    continue;
                }

                var cir = CreateServiceDir(config.Service, implementationDir);

                if (!string.IsNullOrEmpty(cir))
                {
                    result.SetStatus(cir);
                    failures++;
                    continue;
                }

                #endregion

                var temp = 0;

                GenerateCode(logPrefix,
                             config.Service,
                             "BaseConfig",
                             options.Extension,
                             options.Templates.BaseConfigTemplate,
                             new { config.Namespace, config.Service, config.Usings, Props = config.ConfigProps, config.ParentConfig },
                             $"{abstractionDir}\\BaseConfig{options.Extension}",
                             options.Overwrite,
                             ref warnings[row]);

                if (config.PartialConfig && options.GeneratePartials)
                {
                    GenerateCode(logPrefix,
                             config.Service,
                             "BaseConfig.Partial",
                             options.Extension,
                             options.Templates.BaseConfigPartialTemplate,
                             new { config.Namespace, config.Service, config.Usings, config.ParentConfig },
                             $"{abstractionDir}\\BaseConfig.Partial{options.Extension}",
                             false,
                             ref temp);
                }

                GenerateCode(logPrefix,
                             config.Service,
                             "Interface",
                             options.Extension,
                             options.Templates.InterfaceTemplate,
                             config,
                             $"{abstractionDir}\\Interface{options.Extension}",
                             options.Overwrite,
                             ref warnings[row]);

                if (config.PartialInterface && options.GeneratePartials)
                {
                    GenerateCode(logPrefix,
                             config.Service,
                             "Interface.Partial",
                             options.Extension,
                             options.Templates.InterfacePartialTemplate,
                             config,
                             $"{abstractionDir}\\Interface.Partial{options.Extension}",
                             false,
                             ref temp);
                }

                GenerateCode(logPrefix,
                             config.Service,
                             "BaseService",
                             options.Extension,
                             options.Templates.BaseServiceTemplate,
                             config,
                             $"{abstractionDir}\\BaseService{options.Extension}",
                             options.Overwrite,
                             ref warnings[row]);

                var registrationDir = string.IsNullOrEmpty(config.RegistrationDir) ? options.Config.RegistrationDir : config.RegistrationDir;

                registrationDir = string.IsNullOrEmpty(registrationDir) ? outputDir + "\\" + configFolder :
                                        Path.IsPathRooted(registrationDir) ? registrationDir : Environment.CurrentDirectory + "\\" + registrationDir + "\\" + configFolder;

                cor = CreateRegistrationDir(registrationDir);

                if (!string.IsNullOrEmpty(cor))
                {
                    result.SetStatus(cor);

                    return result;
                }

                GenerateCode(logPrefix,
                             config.Service,
                             "Registration",
                             options.Extension,
                             options.Templates.RegistrationTemplate,
                             config,
                             $"{registrationDir}\\Registration{options.Extension}",
                             options.Overwrite,
                             ref warnings[row]);

                GenerateCode(logPrefix,
                                 config.Service,
                                 "Registration.Partial",
                                 options.Extension,
                                 options.Templates.RegistrationPartialTemplate,
                                 config,
                                 $"{registrationDir}\\Registration.Partial{options.Extension}",
                                 false,
                                 ref temp);

                if (config.PartialServiceBase && options.GeneratePartials)
                {
                    GenerateCode(logPrefix,
                             config.Service,
                             "BaseService.Partial",
                             options.Extension,
                             options.Templates.BaseServicePartialTemplate,
                             config,
                             $"{abstractionDir}\\BaseService.Partial{options.Extension}",
                             false,
                             ref temp);
                }

                var i = 0;

                foreach (var concrete in config.Concretes)
                {
                    var serviceDir = implementationDir + $"{(hasImplementationDir ? $"\\{concrete.Suffix}" : "")}";
                    var csd = CreateDir(concrete.Suffix, serviceDir);

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
                             $"{concrete.Suffix}Config",
                             options.Extension,
                             options.Templates.ConfigTemplate,
                             new { config.Namespace, config.Service, config.Usings, concrete.Suffix, Props = concrete.ConfigProps },
                             $"{serviceDir}\\{concrete.Suffix}Config{options.Extension}",
                             options.Overwrite,
                             ref warnings[row]);

                    if (config.PartialConfig && options.GeneratePartials)
                    {
                        GenerateCode(logPrefix,
                                 config.Service,
                                 $"{concrete.Suffix}Config.Partial",
                                 options.Extension,
                                 options.Templates.ConfigPartialTemplate,
                                 new { config.Namespace, config.Service, config.Usings, concrete.Suffix },
                                 $"{serviceDir}\\{concrete.Suffix}Config.Partial{options.Extension}",
                                 false,
                                 ref temp);
                    }

                    var ctors = new List<List<string>>();

                    foreach (var item in config.Constructors)
                    {
                        var _ctor = new List<string>();
                        foreach (var pair in item)
                        {
                            _ctor.Add(pair.Value);
                        }
                        ctors.Add(_ctor);
                    }

                    if (string.IsNullOrEmpty(csd))
                    {
                        GenerateCode(logPrefix,
                                     config.Service,
                                     $"{concrete.Suffix}Service",
                                     options.Extension,
                                     options.Templates.ServiceTemplate,
                                     new GeneratorConfigServiceConcreteItem
                                     {
                                         Usings = config.Usings,
                                         Namespace = config.Namespace,
                                         Service = config.Service,
                                         ConcreteService = hasImplementationDir ? concrete.Suffix: "",
                                         Actions = config.Actions,
                                         Suffix = concrete.Suffix,
                                         ActionSuffix = concrete.ActionSuffix,
                                         Constructors = concrete.Constructors,
                                         ParentConstructors = ctors
                                     },
                                     $"{serviceDir}\\{concrete.Suffix}Service{options.Extension}",
                                     options.Overwrite,
                                     ref warnings[row]);

                        if (concrete.Partial && options.GeneratePartials)
                        {
                            GenerateCode(logPrefix,
                                     config.Service,
                                     $"{concrete.Suffix}Service.Partial",
                                     options.Extension,
                                     options.Templates.ServicePartialTemplate,
                                     new { config.Usings, config.Namespace, config.Service, concrete.Suffix },
                                     $"{serviceDir}\\{concrete.Suffix}Service.Partial{options.Extension}",
                                     false,
                                     ref temp);
                        }

                        i++;
                    }
                }

                i = 0;

                foreach (var action in config.Actions)
                {
                    if (string.IsNullOrEmpty(action.Name))
                    {
                        logger.Log($"{logPrefix}: action {i} is empty. skipped.");
                        continue;
                    }

                    var actionDir = $"{abstractionDir}\\{action.Name}";
                    var cacr = CreateActionDir(config.Service, action.Name, actionDir);

                    if (string.IsNullOrEmpty(cacr))
                    {
                        GenerateCode(logPrefix,
                                     config.Service,
                                     "Request",
                                     options.Extension,
                                     options.Templates.RequestTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.RequestModel, action.Usings, Props = action.RequestProps, action.RequestType },
                                     $"{actionDir}\\Request{options.Extension}",
                                     options.Overwrite,
                                     ref warnings[row]);

                        if (action.PartialRequest && options.GeneratePartials)
                        {
                            GenerateCode(logPrefix,
                                     config.Service,
                                     "Request.Partial",
                                     options.Extension,
                                     options.Templates.RequestPartialTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.RequestModel, action.Usings, action.RequestType },
                                     $"{actionDir}\\Request.Partial{options.Extension}",
                                     false,
                                     ref temp);
                        }

                        GenerateCode(logPrefix,
                                     config.Service,
                                     "Response",
                                     options.Extension,
                                     options.Templates.ResponseTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.ResponseData, action.ResponseType, action.Usings, Props = action.ResponseProps },
                                     $"{actionDir}\\Response{options.Extension}",
                                     options.Overwrite,
                                     ref warnings[row]);

                        if (action.PartialResponse && options.GeneratePartials)
                        {
                            GenerateCode(logPrefix,
                                     config.Service,
                                     "Response.Partial",
                                     options.Extension,
                                     options.Templates.ResponsePartialTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.ResponseData, action.ResponseType, action.Usings },
                                     $"{actionDir}\\Response.Partial{options.Extension}",
                                     false,
                                     ref warnings[row]);
                        }

                        GenerateCode(logPrefix,
                                     config.Service,
                                     "BaseAction",
                                     options.Extension,
                                     options.Templates.BaseActionTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.Usings, action.ParentAction, action.ConfigBasedService },
                                     $"{actionDir}\\BaseAction{options.Extension}",
                                     options.Overwrite,
                                     ref warnings[row]);

                        if (action.PartialBase && options.GeneratePartials)
                        {
                            GenerateCode(logPrefix,
                                     config.Service,
                                     "BaseAction.Partial",
                                     options.Extension,
                                     options.Templates.BaseActionPartialTemplate,
                                     new { config.Namespace, config.Service, Action = action.Name, action.Usings, action.ParentAction, action.ConfigBasedService },
                                     $"{actionDir}\\BaseAction.Partial{options.Extension}",
                                     false,
                                     ref temp);
                        }
                    }
                }

                foreach (var concreteService in config.Concretes)
                {
                    foreach (var action in config.Actions)
                    {
                        if (string.IsNullOrEmpty(action.Name))
                        {
                            logger.Log($"{logPrefix}: action {i} is empty. skipped.");
                            continue;
                        }

                        var j = 0;

                        foreach (var concrete in action.Concretes)
                        {
                            var actionDir = $"{implementationDir}{(hasImplementationDir ? $"\\{concreteService.Suffix}" : "")}\\{action.Name}";
                            var cacr = CreateActionDir(config.Service, action.Name, actionDir);

                            if (string.IsNullOrWhiteSpace(concrete))
                            {
                                logger.Log($"{logPrefix}: concrete {j} in action {action.Name} is empty. skipped.");
                                continue;
                            }

                            GenerateCode(logPrefix,
                                         config.Service,
                                         $"{concrete}Action",
                                         options.Extension,
                                         options.Templates.ActionTemplate,
                                         new { config.Namespace, config.Service, ConcreteService = (hasImplementationDir ? concreteService.Suffix: ""), Action = action.Name, action.Usings, Suffix = concrete, SameServiceSuffix = false }, // config.Concretes.Exists(_x => _x.ActionSuffix == concrete)
                                         $"{actionDir}\\{concrete}Action{options.Extension}",
                                         options.Overwrite,
                                         ref warnings[row]);

                            if (options.GeneratePartials)
                            {
                                GenerateCode(logPrefix,
                                             config.Service,
                                             $"{concrete}Action.Partial",
                                             options.Extension,
                                             options.Templates.ActionPartialTemplate,
                                             new { config.Namespace, config.Service, ConcreteService = (hasImplementationDir ? concreteService.Suffix : ""), Action = action.Name, action.Usings, Suffix = concrete, action.DefaultAsync, SameServiceSuffix = false }, // config.Concretes.Exists(_x => _x.ActionSuffix == concrete)
                                             $"{actionDir}\\{concrete}Action.Partial{options.Extension}",
                                             false,
                                             ref warnings[row]);
                            }
                        }

                        i++;
                    }
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

            warnings.ForEach((i, n) =>
            {
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
                result = a.GetResourceString("Locust.Service.Moon.CodeGenerator", $"InternalTemplates{Options.Extension}.{name}");
            }
            catch (Exception e)
            {
                logger.Log($"Error reading template resource {name}");
                exceptionLogger.LogException(e, $"template resource error: {name}");

                throw;
            }
            return result;
        }
        static string ReadTemplateFileOrResource(string templatePath, string name)
        {
            var result = "";
            var path = templatePath + "\\" + name + Options.TemplateExtension;

            if (File.Exists(path))
            {
                try
                {
                    result = File.ReadAllText(path);
                }
                catch (Exception e)
                {
                    logger.Log($"Error reading template file {name}{Options.TemplateExtension}");
                    exceptionLogger.LogException(e, $"template file error: {name}{Options.TemplateExtension}");
                    logger.Log("Reverting to internal template ...");

                    result = ReadTemplate(name + ".txt");
                }
            }
            else
            {
                result = ReadTemplate(name + ".txt");
            }

            return result;
        }
        static void InitTemplates(GeneratorOptions options)
        {
            var templatePath = Path.IsPathRooted(options.TemplateFolder) ? options.TemplateFolder : Environment.CurrentDirectory + "\\" + options.TemplateFolder;

            if (Directory.Exists(templatePath))
            {
                options.Templates.ActionTemplate = ReadTemplateFileOrResource(templatePath, "Action");
                options.Templates.ActionPartialTemplate = ReadTemplateFileOrResource(templatePath, "Action.Partial");
                options.Templates.BaseActionTemplate = ReadTemplateFileOrResource(templatePath, "BaseAction");
                options.Templates.BaseActionPartialTemplate = ReadTemplateFileOrResource(templatePath, "BaseAction.Partial");
                options.Templates.BaseServiceTemplate = ReadTemplateFileOrResource(templatePath, "BaseService");
                options.Templates.BaseServicePartialTemplate = ReadTemplateFileOrResource(templatePath, "BaseService.Partial");
                options.Templates.ConfigTemplate = ReadTemplateFileOrResource(templatePath, "Config");
                options.Templates.ConfigPartialTemplate = ReadTemplateFileOrResource(templatePath, "Config.Partial");
                options.Templates.BaseConfigTemplate = ReadTemplateFileOrResource(templatePath, "BaseConfig");
                options.Templates.BaseConfigPartialTemplate = ReadTemplateFileOrResource(templatePath, "BaseConfig.Partial");
                options.Templates.InterfaceTemplate = ReadTemplateFileOrResource(templatePath, "Interface");
                options.Templates.InterfacePartialTemplate = ReadTemplateFileOrResource(templatePath, "Interface.Partial");
                options.Templates.RequestTemplate = ReadTemplateFileOrResource(templatePath, "Request");
                options.Templates.RequestPartialTemplate = ReadTemplateFileOrResource(templatePath, "Request.Partial");
                options.Templates.ResponseTemplate = ReadTemplateFileOrResource(templatePath, "Response");
                options.Templates.ResponsePartialTemplate = ReadTemplateFileOrResource(templatePath, "Response.Partial");
                options.Templates.RegistrationTemplate = ReadTemplateFileOrResource(templatePath, "Registration");
                options.Templates.RegistrationPartialTemplate = ReadTemplateFileOrResource(templatePath, "Registration.Partial");
                options.Templates.ServiceTemplate = ReadTemplateFileOrResource(templatePath, "Service");
                options.Templates.ServicePartialTemplate = ReadTemplateFileOrResource(templatePath, "Service.Partial");
                options.Templates.TestActionTemplate = ReadTemplateFileOrResource(templatePath, "TestAction");
                options.Templates.TestServiceTemplate = ReadTemplateFileOrResource(templatePath, "TestService");
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
                options.Templates.ConfigPartialTemplate = ReadTemplate("Config.Partial.txt");
                options.Templates.BaseConfigTemplate = ReadTemplate("BaseConfig.txt");
                options.Templates.BaseConfigPartialTemplate = ReadTemplate("BaseConfig.Partial.txt");
                options.Templates.InterfaceTemplate = ReadTemplate("Interface.txt");
                options.Templates.InterfacePartialTemplate = ReadTemplate("Interface.Partial.txt");
                options.Templates.RequestTemplate = ReadTemplate("Request.txt");
                options.Templates.RequestPartialTemplate = ReadTemplate("Request.Partial.txt");
                options.Templates.ResponseTemplate = ReadTemplate("Response.txt");
                options.Templates.ResponsePartialTemplate = ReadTemplate("Response.Partial.txt");
                options.Templates.RegistrationTemplate = ReadTemplate("Registration.txt");
                options.Templates.RegistrationPartialTemplate = ReadTemplate("Registration.Partial.txt");
                options.Templates.ServiceTemplate = ReadTemplate("Service.txt");
                options.Templates.ServicePartialTemplate = ReadTemplate("Service.Partial.txt");
                options.Templates.TestActionTemplate = ReadTemplate("TestAction.txt");
                options.Templates.TestServiceTemplate = ReadTemplate("TestService.txt");
            }
        }
        static void Start(string[] args)
        {
            logger.Log($"Locust Service Moon Code Generator v{ConfigVersion}");

            var gor = GetOptions(args);

            //logger.Log(JsonConvert.SerializeObject(gor, Formatting.Indented));

            if (gor.IsSucceeded())
            {
                Options = gor.Data;

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
        static void testRazor()
        {
            var output = Engine.Razor.RunCompile($@"
@test(Model.Name)
@helper test(string n)
{{
    <div>@n</div>
}}
", "foo1", null, new { Name = "Ali" });
            Console.WriteLine(output);
        }
        static void Main(string[] args)
        {
            Start(args);
            //test1(args);
            //testRazor();
#if DEBUG
            System.Console.ReadKey();
#endif
        }
    }
}
