using Locust.Caching;
using Locust.Extensions;
using Locust.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Translation
{
    public class HybridTranslator : ITranslator
    {
        private FileBasedTranslator textTranslator;
        private ResourceBasedTranslator resourceTranslator;
        private List<ITranslator> translators;
        public FileBasedTranslator File
        {
            get { return textTranslator; }
        }
        public ResourceBasedTranslator Resource
        {
            get { return resourceTranslator; }
        }
        public HybridTranslator()
        {
            textTranslator = new FileBasedTranslator();
            resourceTranslator = new ResourceBasedTranslator();

            translators = new List<ITranslator>();

            translators.Add(textTranslator);
            translators.Add(resourceTranslator);
        }
        public HybridTranslator(ICacheManager cache, IExceptionLogger exceptionLogger, ILogger logger)
        {
            textTranslator = new FileBasedTranslator(cache, exceptionLogger, logger);
            resourceTranslator = new ResourceBasedTranslator(cache, exceptionLogger, logger);

            translators = new List<ITranslator>();

            translators.Add(textTranslator);
            translators.Add(resourceTranslator);
        }
        public void Clear()
        {
            foreach (var translator in translators)
            {
                translator.Clear();
            }
        }

        public string[] Get(string key)
        {
            var result = new string[] { };

            foreach (var translator in translators)
            {
                result = translator.Get(key);

                if (result != null && result.Length > 0)
                {
                    break;
                }
            }

            return result;
        }

        public string[] Get(string key, string value, string lang)
        {
            var result = new string[] { };

            foreach (var translator in translators)
            {
                result = translator.Get(key, value, lang);

                if (result != null && result.Length > 0)
                {
                    break;
                }
            }

            return result;
        }

        public string[] Get(string key, object globalValue, object culture, object lang)
        {
            var result = new string[] { };

            foreach (var translator in translators)
            {
                result = translator.Get(key, globalValue, culture, lang);

                if (result != null && result.Length > 0)
                {
                    break;
                }
            }

            return result;
        }

        public Dictionary<string, string[]> GetAll(string storename = "")
        {
            var result = new Dictionary<string, string[]>();

            foreach (var translator in translators)
            {
                var r = translator.GetAll(storename);

                result.Merge(r);
            }

            return result;
        }

        public string GetSingle(string key)
        {
            var result = string.Empty;

            foreach (var translator in translators)
            {
                result = translator.GetSingle(key);

                if (!string.IsNullOrEmpty(result))
                {
                    break;
                }
            }

            return result;
        }

        public string GetSingle(string key, string value, string lang)
        {
            var result = string.Empty;

            foreach (var translator in translators)
            {
                result = translator.GetSingle(key, value, lang);

                if (!string.IsNullOrEmpty(result))
                {
                    break;
                }
            }

            return result;
        }

        public string GetSingle(string key, object globalValue, object culture, object lang)
        {
            var result = string.Empty;

            foreach (var translator in translators)
            {
                result = translator.GetSingle(key, globalValue, culture, lang);

                if (!string.IsNullOrEmpty(result))
                {
                    break;
                }
            }

            return result;
        }

        public void Load()
        {
            foreach (var translator in translators)
            {
                translator.Load();
            }
        }
    }
}
