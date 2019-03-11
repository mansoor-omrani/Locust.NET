using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.WebTools.Utilities
{
    public interface IJavascriptObfuscator
    {
        string Obfuscate(string content);
    }
    public class NullJavascriptObfuscator : IJavascriptObfuscator
    {
        public string Obfuscate(string content)
        {
            return content;
        }
    }
}
