using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Locust.Extensions;

namespace Locust.ServiceModel.Unity
{
    public class ServiceConfigure
    {
        private static void RegisterAll(IUnityContainer container)
        {
            Debug.WriteLine("Registering Services");

            var baseServiceConfig = typeof(ServiceConfig);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();

            foreach (var assembly in assemblies)
            {
                try
                {
                    Debug.WriteLine("3." + assembly.FullName);

                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.IsClass && !type.IsAbstract && type.IsSubclassOf(baseServiceConfig))
                        {
                            Debug.WriteLine("4." + type.FullName);

                            var config = Activator.CreateInstance(type) as ServiceConfig;

                            config.Configure();
                        }
                    }
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e.Message);
                }
            }

            foreach (var item in ServiceConfig.GetMappings())
            {
                container.RegisterType(item.Key, item.Value);
            }
        }
        private static void LoadAllAssemblies(params string[] assemblyPrefix)
        {
            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            var loadedPaths = loadedAssemblies.Where(a => !a.IsDynamic).Select(a => a.Location).ToArray();

            var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
            var finalLoad = new List<string>();

            Debug.WriteLine("Loading assemblies");

            foreach (var path in toLoad)
            {
                Debug.WriteLine("1." + path);

                foreach (var prefix in assemblyPrefix)
                {
                    if (string.Compare(Path.GetFileName(path).Left(prefix.Length), prefix, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        Debug.WriteLine("2." + path);

                        finalLoad.Add(path);
                    }
                }

            }

            finalLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
        }
        //private static void LoadAllServices()
        //{
        //    var container = UnityConfig.GetConfiguredContainer();
        //    var baseService = typeof(BaseService);
        //    var assemblies = AppDomain.CurrentDomain.GetAssemblies();

        //    foreach (var assembly in assemblies)
        //    {
        //        foreach (var type in assembly.GetTypes())
        //        {
        //            if (type.IsClass && type.IsAbstract && type.IsSubclassOf(baseService))
        //            {
        //                container.Resolve(type);
        //            }
        //        }
        //    }
        //}

        public static void Configure(IUnityContainer container)
        {
            LoadAllAssemblies("Locust");
            RegisterAll(container);
            //LoadAllServices();
        }
    }
}
