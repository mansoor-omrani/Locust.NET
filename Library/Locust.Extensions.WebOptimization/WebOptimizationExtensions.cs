using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace Locust.Extensions.WebOptimization
{
    public static class WebOptimizationExtensions
    {
        public static Bundle AddCssBundle(this BundleCollection bundles, string virtualPath, string cdnpath = "")
        {
            var result = bundles.FirstOrDefault(b => string.Compare(b.Path, virtualPath, StringComparison.OrdinalIgnoreCase) == 0);

            if (result != null)
                return result;

            if (!string.IsNullOrEmpty(cdnpath))
                return new StyleBundle(virtualPath, cdnpath);

            return new StyleBundle(virtualPath);
        }
    }
}
