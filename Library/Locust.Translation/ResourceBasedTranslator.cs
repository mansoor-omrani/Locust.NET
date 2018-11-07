using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Logging;
using Locust.Extensions;
using System.Reflection;
using System.IO;
using System.Web;

namespace Locust.Translation
{
    public class ResourceBasedTranslator : BaseTranslator
    {
        public ResourceBasedTranslator() : base()
        {
            Init();
        }
        public ResourceBasedTranslator(ICacheManager cache, IExceptionLogger exceptionLogger, ILogger logger) : base(cache, exceptionLogger, logger)
        {
            Init();
        }
        
        protected virtual void Init()
        {
            Assemblies = new List<string>();

            Assemblies.Add("Locust.Language");
            Assemblies.Add("Locust.Measurement");
            Assemblies.Add("Locust.Calendar");
            //Assemblies.Add("Locust.Translation");
        }
        public List<string> Assemblies { get; private set; }
        private string GetFileName(string resourcename)
        {
            var result = "";
            var i = resourcename.LastIndexOf('.');

            if (i > 1)
            {
                var j = resourcename.LastIndexOf('.', i - 1);

                if (j >= 0)
                {
                    result = resourcename.Substring(j + 1, i - j - 1);
                }
            }

            return result?.ToLower();
        }
        private void LoadAssemblyTexts(Assembly assembly)
        {
            Logger.LogCategory($"LoadAssemblyTexts: {assembly.GetName().Name}");

            var resources = assembly.GetManifestResourceNames();
            if (resources.Length > 0)
            {
                var cdt = resources.Where(rn => rn.ToLower().EndsWith(CultureDependentTextExtension));
                Logger.Log($"found {cdt.Count()} culture dependent resources ");

                foreach (var rn in cdt)
                {
                    var content = assembly.GetResourceString(rn.Substring(assembly.GetName().Name.Length + 1));

                    Logger.Log($"Loading Resource: {rn}");

                    try
                    {
                        var filename = GetFileName(rn);
                        Logger.Log($"filename: {filename}");

                        ProcessCultureDependentText(filename, content);
                    }
                    catch (Exception e)
                    {
                        Logger.Log($"error loading {rn}");
                        ExceptionLogger.LogException(e, $"{this.GetType().Name}.Load(): ProcessCultureDependentText('{rn}')");
                    }
                }

                var cit = resources.Where(rn => rn.ToLower().EndsWith(CultureIndependentTextExtension));
                Logger.Log($"found {cit.Count()} culture independent resources ");

                foreach (var rn in cit)
                {
                    var content = assembly.GetResourceString(rn.Substring(assembly.GetName().Name.Length + 1));

                    Logger.Log($"Loading Resource: {rn}");

                    try
                    {
                        var filename = GetFileName(rn);
                        Logger.Log($"filename: {filename}");

                        ProcessCultureIndependentText(filename, content);
                    }
                    catch (Exception e)
                    {
                        Logger.Log($"error loading {rn}");
                        ExceptionLogger.LogException(e, $"{this.GetType().Name}.Load(): ProcessCultureIndependentText('{rn}')");
                    }
                }
            }
            else
            {
                Logger.Log($"no resource file found to read.");
            }
        }
        protected override void LoadInternal()
        {
            var assemblies = new List<Assembly>();
            Logger.LogCategory($"{this.GetType().Name}.LoadInternal");
            Logger.Log("Current resource assemblies : " + Assemblies.Join(", "));

            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            Logger.Log("Checking if an assembly is already loaded ...");

            loadedAssemblies.ForEach(asm => {
                if (Assemblies.IndexOf(asm.GetName().Name) > 0)
                {
                    Logger.Log("already loaded");
                    assemblies.Add(asm);
                }
            });

            if (assemblies.Count < Assemblies.Count)
            {
                Logger.Log("Some assemblies are not loaded. Trying to load them.");
                Logger.Log("Finding their paths ...");

                var loadedPaths = loadedAssemblies.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();
                var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                if (baseDirectory.Right(1) == "\\")
                {
                    baseDirectory = baseDirectory.Left(baseDirectory.Length - 1);
                }

                var referencedPaths = Directory.GetFiles(baseDirectory, "*.dll").ToList();
                if (baseDirectory.Right(3).ToLower() != "\\bin" && Directory.Exists(Path.Combine(baseDirectory, "bin")))
                {
                    referencedPaths.Merge(Directory.GetFiles(Path.Combine(baseDirectory, "bin"), "*.dll"));
                }

                var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
                var finalLoad = new List<string>();

                if (toLoad.Count > 0)
                {
                    Logger.Log($" {toLoad.Count} assemblies were not loaded. Checking if our resource assemblies are in them ...");

                    foreach (var path in toLoad)
                    {
                        foreach (var assembly in Assemblies)
                        {
                            if (string.Compare(Path.GetFileName(path).Left(assembly.Length), assembly, StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                Logger.Log($"{assembly} was added to final load list.");

                                finalLoad.Add(path);
                                break;
                            }
                        }
                    }

                    if (finalLoad.Count > 0)
                    {
                        Logger.Log("Loading not-loaded assemblies ...");

                        finalLoad.ForEach(path =>
                        {
                            Logger.Log($"Loading {path} ...");

                            var asm = AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path));
                            
                            if (assemblies.IndexOf(asm) < 0)
                            {
                                assemblies.Add(asm);
                            }

                            Logger.Log($"{asm.GetName().Name} Loaded.");
                        });
                    }
                    else
                    {
                        Logger.Log("Nothing found to load.");
                    }
                }
                else
                {
                    Logger.Log("All assemblies in '\\bin' folder are already loaded.");
                }
            }

            if (assemblies.Count > 0)
            {
                Logger.Log("Loading resources");

                assemblies.ForEach(asm =>
                {
                    Logger.Log($"Loading {asm.GetName().Name} texts ...");
                    LoadAssemblyTexts(asm);
                    Logger.Log($"Loaded.");
                });
            }
        }
    }
}
