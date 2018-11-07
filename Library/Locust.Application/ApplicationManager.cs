using Locust.Extensions;
using Locust.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Application
{
    public class ApplicationManager
    {
        private ILogger logger;
        public ILogger Logger
        {
            get
            {
                if (logger == null)
                    logger = new NullLogger();
                return logger;
            }
            set { logger = value; }
        }
        private IExceptionLogger exceptionLogger;
        public IExceptionLogger ExceptionLogger
        {
            get
            {
                if (exceptionLogger == null)
                    exceptionLogger = new NullExceptionLogger();
                return exceptionLogger;
            }
            set { exceptionLogger = value; }
        }
        public ApplicationManager(ILogger logger, IExceptionLogger exceptionLogger)
        {
            Logger = logger;
            ExceptionLogger = exceptionLogger;
        }
        public void LoadAllAssemblies()
        {
            Logger.LogCategory("ApplicationManager.LoadAllAssemblies()");

            try
            {
                var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
                var loadedPaths = loadedAssemblies.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();
                var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
                var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();

                Logger.Log($"assemblies: {loadedAssemblies.Count}");
                Logger.Log($"loadedPaths: {loadedPaths.Length}");
                Logger.Log($"referencedPaths: {referencedPaths.Length}");
                Logger.Log($"toLoad: {toLoad.Count}");

                foreach (var path in toLoad)
                {
                    try
                    {
                        Logger.Log($"loading '{path}'");
                        loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path)));
                        Logger.Log($"done.");
                    }
                    catch (Exception e)
                    {
                        ExceptionLogger.LogException(e, path);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogger.LogException(e);
            }
        }
        public void LoadAssembly(params string[] assemblyNameOrPrefix)
        {
            Logger.LogCategory("ApplicationManager.LoadAssembly()");

            if (assemblyNameOrPrefix == null || assemblyNameOrPrefix.Length == 0)
            {
                Logger.Log("nothing given to be loaded");
                return;
            }

            try
            {
                Logger.Log("assemblyPrefix: " + assemblyNameOrPrefix.Join(','));

                var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
                var loadedPaths = loadedAssemblies.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();
                var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
                var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();

                Logger.Log($"assemblies: {loadedAssemblies.Count}");
                Logger.Log($"loadedPaths: {loadedPaths.Length}");
                Logger.Log($"referencedPaths: {referencedPaths.Length}");
                Logger.Log($"toLoad: {toLoad.Count}");

                var finalLoad = new List<string>();

                Logger.Log($"constructing toLoad list ...");

                foreach (var path in toLoad)
                {
                    Logger.Log($"checking '{path}' ...");

                    var cnt = finalLoad.Count;

                    foreach (var prefix in assemblyNameOrPrefix)
                    {
                        if (string.Compare(Path.GetFileName(path).Left(prefix.Length), prefix, StringComparison.OrdinalIgnoreCase) == 0)
                        {
                            if (finalLoad.IndexOf(path) < 0)
                            {
                                Logger.Log($"   added to load list ({prefix})");

                                finalLoad.Add(path);
                            }
                            else
                            {
                                Logger.Log($"   already added to load list ({prefix})");
                            }
                        }
                    }

                    if (cnt != finalLoad.Count)
                    {
                        Logger.Log($"   not requested to be loaded");
                    }
                }

                Logger.Log($"finalLoad: {finalLoad.Count}");

                foreach (var path in finalLoad)
                {
                    try
                    {
                        Logger.Log($"loading '{path}'");
                        loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path)));
                        Logger.Log($"done.");
                    }
                    catch (Exception e)
                    {
                        ExceptionLogger.LogException(e, path);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogger.LogException(e);
            }
        }
        public void Scan(Action<Type> scan)
        {
            try
            {
                Logger.LogCategory("ApplicationManager.Scan");

                var assemblies = AppDomain.CurrentDomain.GetAssemblies();

                foreach (var assembly in assemblies)
                {
                    try
                    {
                        Logger.Log(assembly.FullName);

                        foreach (var type in assembly.GetTypes())
                        {
                            scan?.Invoke(type);
                        }
                    }
                    catch (Exception e)
                    {
                        ExceptionLogger.LogException(e);
                    }
                }
            }
            catch (Exception e)
            {
                ExceptionLogger.LogException(e);
            }
        }
    }
}
