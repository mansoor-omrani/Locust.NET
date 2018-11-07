using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Extensions;
using Locust.Conversion;
using Locust.WebTools;

namespace Locust.BaseInfo.Web
{
    public static class Extensions
    {
        public static HtmlSelect GetSelect(this SqlBaseInfoProvider bip, string category, object options = null)
        {
            var data = bip.GetAllAsDictionary(category);

            var result = new HtmlSelect
            {
                Name = category,
                ID = category,
                Items = data
            };

            if (options != null)
            {
                result.Class = SafeClrConvert.ToString(options.ReadProperty("class"));
                result.CurrentValue = SafeClrConvert.ToString(options.ReadProperty("currentvalue"));
                result.FirstText = SafeClrConvert.ToString(options.ReadProperty("firsttext"));
                result.FirstValue = SafeClrConvert.ToString(options.ReadProperty("firstvalue"));
                result.Style = SafeClrConvert.ToString(options.ReadProperty("style"));
                result.Size = SafeClrConvert.ToInt32(options.ReadProperty("size"));
                result.Multiple = SafeClrConvert.ToBoolean(options.ReadProperty("multiple"));
            }

            return result;
        }
        public static HtmlSelect GetSelect<T>(this SqlBaseInfoProvider bip, object options = null)
        {
            return bip.GetSelect(typeof(T).Name, options);
        }
    }
}
