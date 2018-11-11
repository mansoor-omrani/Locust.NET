using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Locust.ServiceModel;

namespace Locust.Test.Test
{
    public class test_servicemodel:BaseTest
    {
        private void test1()
        {
            //BaseService.LoadAllServices(new string[] { "Locust.Modules" });
            var s = ServiceConfig.GetServiceAbstraction("RoleCategory");

            System.Console.WriteLine(s != null);
        }

        private void test2()
        {
            //var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
            //var loadedPaths = loadedAssemblies.Select(a => a.Location).ToArray();
            
            //var referencedPaths = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
            //var toLoad = referencedPaths.Where(r => !loadedPaths.Contains(r, StringComparer.InvariantCultureIgnoreCase)).ToList();
            //foreach (var path in toLoad)
            //{
            //    System.Console.WriteLine(Path.GetFileName(path));
            //}
            //toLoad.ForEach(path => loadedAssemblies.Add(AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(path))));
            
        }
        public override void Test()
        {
            test1();
        }
    }
}
