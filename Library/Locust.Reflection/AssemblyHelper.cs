using Locust.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Reflection
{
    public static class AssemblyHelper
    {
        public static ServiceResponse<Assembly> Load(string assemblyNameOrPath)
        {
            var response = new ServiceResponse<Assembly>();
            
            try
            {
                if (!Path.HasExtension(assemblyNameOrPath))
                {
                    assemblyNameOrPath += ".dll";
                }

                assemblyNameOrPath = Path.GetFullPath(assemblyNameOrPath);

                response.Data = Assembly.LoadFrom(assemblyNameOrPath);
                response.Success = response.Data != null;
                response.Status = "LoadSuccess";
            }
            catch (Exception e)
            {
                response.Status = "CannotLoadAssembly";
                response.Message = $"Unable to load '{assemblyNameOrPath}' assembly.";
                response.Exception = e;
            }

            return response;
        }
    }
}
