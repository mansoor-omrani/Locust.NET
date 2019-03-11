using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.WebTools.Utilities
{
    public interface ICssMinifier
    {
        string Minify(string content);
    }
    public class NullCssMinifier : ICssMinifier
    {
        public string Minify(string content)
        {
            return content;
        }
    }
}
