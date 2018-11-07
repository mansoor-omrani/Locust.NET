using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Translation
{
    public interface ITranslator
    {
        Dictionary<string, string[]> GetAll(string storename = "");
        string[] Get(string key);
        string[] Get(string key, object globalValue, object culture, object lang);
        string[] Get(string key, string value, string lang);
        string GetSingle(string key);
        string GetSingle(string key, object globalValue, object culture, object lang);
        string GetSingle(string key, string value, string lang);
        void Clear();
        void Load();
    }
}
