using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Translation
{
    public static class TranslatorHelper
    {
        public static Dictionary<string, string[]> ReadLocalizationFile(string filename)
        {
            var result = new Dictionary<string, string[]>();

            if (File.Exists(filename))
            {
                var content = File.ReadAllLines(filename);

                foreach (var line in content)
                {
                    var _line = line?.Trim();

                    if (!string.IsNullOrEmpty(_line))
                    {
                        if (_line[0] != '#')
                        {
                            var colonIndex = _line.IndexOf(':');

                            if (colonIndex > 0)
                            {
                                var key = _line.Substring(0, colonIndex).ToLower();
                                var values = BaseTranslator.GetValues(_line.Substring(colonIndex + 1));

                                if (!result.ContainsKey(key))
                                {
                                    result.Add(key, values);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
