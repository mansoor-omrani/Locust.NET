using Locust.AppPath;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ConnectionString.Json
{
    public class JsonConnectionStringProvider : BaseConnectionStringProvider
    {
        public JsonConnectionStringProvider()
        {
            ActiveConnection = "default";
        }
        public static JsonConnectionStringProvider Create()
        {
            var basePath = ConfigurationManager.AppSettings["JsonConStrBasePath"] ?? "\\..";
            var result = new JsonConnectionStringProvider();
#if DEBUG
            result.Path = ApplicationPath.Root + basePath + @"\constr.debug.json";
#else
                result.Path = ApplicationPath.Root + basePath + @"\constr.json";
#endif
            result.Load();

            return result;
        }
        public string Path
        {
            get;set;
        }
        public override void Load()
        {
            Clear();

            if (!string.IsNullOrEmpty(Path))
            {
                var content = File.ReadAllText(Path);
                var _connectionStrings = JsonConvert.DeserializeObject<List<ConnectionString>>(content);

                foreach (var cnnStr in _connectionStrings)
                {
                    Add(cnnStr.Name, cnnStr.ToString());
                }
            }
        }
        public override void Save()
        {
            var _connectionStrings = new List<ConnectionString>();

            foreach (var item in GetConnectionStrings())
            {
                _connectionStrings.Add(item);
            }

            var content = JsonConvert.SerializeObject(_connectionStrings, Formatting.Indented);

            File.WriteAllText(Path, content);
        }
    }
}
