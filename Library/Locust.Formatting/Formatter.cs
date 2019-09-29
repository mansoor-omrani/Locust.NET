using Locust.Translation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Formatting
{
    public static class Formatter
    {
        private static ITranslator _translator;
        public static ITranslator DefaultTranslator
        {
            get
            {
                if (_translator == null)
                {
                    _translator = new HybridTranslator();
                }

                return _translator;
            }
            set { _translator = value; }
        }
        public static string Format(string format, object data)
        {
            var result = "";
            return result;
        }
    }
}
