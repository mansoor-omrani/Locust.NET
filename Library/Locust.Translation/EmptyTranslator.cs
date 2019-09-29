using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Translation
{
    public class NullTranslator: ITranslator
    {
        public Dictionary<string, string[]> GetAll(string storename = "")
        {
            return new Dictionary<string, string[]>();
        }

        public string[] Get(string key)
        {
            return new string[0];
        }

        public string[] Get(string key, object globalValue, object culture, object lang)
        {
            return new string[0];
        }

        public string[] Get(string key, string value, string lang)
        {
            return new string[0];
        }

        public string GetSingle(string key)
        {
            return "";
        }

        public string GetSingle(string key, object globalValue, object culture, object lang)
        {
            return "";
        }

        public string GetSingle(string key, string value, string lang)
        {
            return "";
        }

        public void Clear()
        {
        }

        public void Load()
        {
        }
    }
}
