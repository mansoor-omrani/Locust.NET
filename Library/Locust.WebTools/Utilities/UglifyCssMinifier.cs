using NUglify;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.WebTools.Utilities
{
    public class UglifyCssMinifier : ICssMinifier
    {
        public string Minify(string content)
        {
            return Uglify.Css(content).Code;
        }
    }
}
