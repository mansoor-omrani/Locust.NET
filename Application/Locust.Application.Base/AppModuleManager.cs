using Locust.Conversion;
using Locust.Logging;
using Locust.Measurement;
using Locust.Reflection;
using Locust.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Application.Base
{
    [Flags]
    public enum DbInstallItem
    {
        None = 0,
        Assemblies = 1,
        Constraints = 2,
        Defaults = 4,
        Functions = 8,
        Procedures = 16,
        Roles = 32,
        Rules = 64,
        Schemas = 128,
        Sequences = 256,
        Tables = 512,
        Triggers = 1024,
        Types = 2048,
        Users = 4096,
        Views = 8192,
        Data = 16384,
        Indexes = 32768,
        Jobs = 64536,
        SchemaOnly = Assemblies + Constraints + Defaults + Functions + Procedures + Roles + Rules + Schemas + Sequences + Tables + Triggers + Types + Users + Views + Indexes,
        SchemaAndData = SchemaOnly + Data,
        TablesWithoutRelations = Schemas + Tables + Rules + Types + Defaults,
        TablesWithRelations = TablesWithoutRelations + Constraints,
        Programming = Assemblies + Functions + Procedures + Sequences + Triggers + Views,
        UsersAndRoles = Users + Roles
    }
    internal class AppModuleResourceProvider
    {
        internal Assembly Assembly { get; set; }
        private string[] resourceNames;
        internal string[] ResourceNames
        {
            get
            {
                if (resourceNames == null)
                    resourceNames = Assembly.GetManifestResourceNames();

                return resourceNames;
            }
        }
        internal AppModuleResourceProvider(Assembly asm)
        {
            Assembly = asm;

            _moduleType = null;
        }
        private Dictionary<string, SoftwareVersion> _versions;
        internal Dictionary<string, SoftwareVersion> Versions
        {
            get
            {
                if (_versions == null)
                {
                    _versions = new Dictionary<string, SoftwareVersion>();
                    var prefix = Assembly.GetName().Name + ".Data.";

                    foreach (var item in ResourceNames)
                    {
                        var dbIndex = item.IndexOf(".Db", prefix.Length);

                        if (dbIndex > 0)
                        {
                            var version = item.Substring(prefix.Length, dbIndex - prefix.Length);

                            if (!_versions.ContainsKey(version))
                            {
                                _versions.Add(version, new SoftwareVersion(version));
                            }
                        }
                    }
                }

                return _versions;
            }
        }
        private string _moduleType;
        internal string ModuleType
        {
            get
            {
                if (_moduleType == null)
                {
                    var attr = Assembly
                                .GetCustomAttributes(typeof(AssemblyTypeAttribute), false)
                                .Cast<AssemblyTypeAttribute>()
                                .FirstOrDefault() as AssemblyTypeAttribute;

                    _moduleType = attr?.Type ?? "";
                }

                return _moduleType;
            }
        }
    }
    public class AppModuleManager
    {
        private AppModuleConfig _config;
        public AppModuleConfig Config
        {
            get
            {
                if (_config == null)
                    _config = new AppModuleConfig();
                return _config;
            }
            set
            {
                _config = value;
            }
        }
        private IExceptionLogger _exceptionLogger;
        public IExceptionLogger ExceptionLogger
        {
            get
            {
                if (_exceptionLogger == null)
                    _exceptionLogger = new NullExceptionLogger();
                return _exceptionLogger;
            }
            set
            {
                _exceptionLogger = value;
            }
        }
        private ILogger _logger;
        public ILogger Logger
        {
            get
            {
                if (_logger == null)
                    _logger = new NullLogger();
                return _logger;
            }
            set
            {
                _logger = value;
            }
        }
        private AppModuleResourceProvider ResourceProvider;
        public AppModuleManager(AppModuleConfig config, IExceptionLogger exceptionLogger, ILogger logger)
        {
            this.Config = config;
            this.ExceptionLogger = exceptionLogger;
            this.Logger = logger;
        }
        public AppModuleManager() : this(new AppModuleConfig(), new NullExceptionLogger(), new NullLogger())
        {
        }
        protected ServiceResponse ValidateConfig()
        {
            var response = null as ServiceResponse;

            for (var i = 0; i < 1; i++)
            {
                if (string.IsNullOrEmpty(Config.AppModuleNameOrPath))
                {
                    response = new ServiceResponse
                    {
                        Status = "NoAppModuleSpecified",
                        Message = "Please specify application module by name or path."
                    };

                    break;
                }

                if (string.IsNullOrEmpty(Config.DbConfig.DbName))
                {
                    response = new ServiceResponse
                    {
                        Status = "DatabaseNotSpecified",
                        Message = "Please specify name of the database in which the application module is intended to be installed on."
                    };

                    break;
                }

                if (string.IsNullOrEmpty(Config.DbConfig.DbVersion))
                {
                    Logger.Log("Warning: No version is specified for database. Default version will be used.");
                }

                if (string.IsNullOrEmpty(Config.ConnectionString))
                {
                    response = new ServiceResponse
                    {
                        Status = "ConnectionStringNotSpecified",
                        Message = "Please specify connection string of the database."
                    };

                    break;
                }
            }

            return response;
        }
        public ServiceResponse Install(string version = "", DbInstallItem items = DbInstallItem.SchemaAndData)
        {
            var response = null as ServiceResponse;

            Logger.LogCategory("Installing ...");
            Logger.Log("Checking config");

            for (var i = 0; i < 1; i++)
            {
                try
                {
                    response = ValidateConfig();

                    if (response != null)
                    {
                        break;
                    }

                    response = new ServiceResponse();

                    var asmr = AssemblyHelper.Load(Config.AppModuleNameOrPath);

                    if (!asmr.Success)
                    {
                        response.Status = "LoadingAppModuleFailed";
                        response.Message = "Loading application module failed.";
                        response.Exception = asmr.Exception;

                        break;
                    }

                    ResourceProvider = new AppModuleResourceProvider(asmr.Data);

                    if (string.IsNullOrEmpty(ResourceProvider.ModuleType))
                    {
                        response.Status = "MissingAssemblyType";
                        response.Message = "Application module is missing 'AssemblyType' attribute.";

                        break;
                    }

                    if (string.Compare(ResourceProvider.ModuleType, "AppModule", true) != 0)
                    {
                        response.Status = "InvalidAssemblyType";
                        response.Message = "Specified file is not an application module.";

                        break;
                    }

                    InstallDb(asmr.Data, version, items);

                    response.Success = true;
                    response.Status = "InstallationSucceeded";
                    response.Message = "Installation Succeeded";
                }
                catch (Exception e)
                {
                    response.Status = "AbnormalTermination";
                    response.Message = "Installation encountered with an unexpected exception. Installation aborted.";
                    response.Exception = e;

                    break;
                }
            }

            Logger.Log(response.Status);
            Logger.Log(response.Message);

            if (response.Exception != null)
            {
                Logger.Log(response.Exception.Message);
                ExceptionLogger.LogException(response.Exception);
            }

            return response;
        }
        private ServiceResponse InstallDb(Assembly asm, string version, DbInstallItem items)
        {
            var result = new ServiceResponse();
            var prefix = asm.GetName().Name + ".Data";
            var _version = version;

            for (var i = 0; i < 1; i++)
            {
                if (string.IsNullOrEmpty(_version))
                {
                    _version = ResourceProvider.Versions.OrderByDescending(item => item.Value).FirstOrDefault().Key;
                }
                else
                {
                    if (string.IsNullOrEmpty(ResourceProvider.Versions.FirstOrDefault(item => item.Key == version).Key))
                    {
                        result.Status = "VersionNotFound";
                        result.Message = $"Specified application module does not contain {_version} version.";

                        break;
                    }
                }

                prefix += _version + ".Db." + Config.DbConfig.DbType;
                var items = ResourceProvider.ResourceNames.Where(name => name.StartsWith(prefix));
            }

            return result;
        }
        //public ServiceResponse Uninstall()
        //{
        //}
        //public ServiceResponse Validate()
        //{

        //}
    }
}
