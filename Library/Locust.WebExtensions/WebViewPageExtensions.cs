using Locust.Conversion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Locust.WebExtensions
{
    public static class WebViewPageExtensions
    {
        public static IEnumerable<SelectListItem> GetSelectList(this HtmlHelper helper, object value)
        {
            IEnumerable<SelectListItem> result = null;
            
            var enumType = helper.ViewData["EnumType"] as Type ?? helper.ViewData.ModelMetadata.ModelType;
            if (enumType != null && enumType.IsEnum)
            {
                var itemTexts = helper.ViewData["ItemTexts"] as IEnumerable<string>;
                if (itemTexts == null)
                {
                    itemTexts = helper.ViewContext.HttpContext.Cache["EditorTemplate." + enumType.Name + ".ItemTexts"] as IEnumerable<string>;
                    if (itemTexts == null)
                    {
                        itemTexts = new List<string>();
                        var arr = Enum.GetValues(enumType);

                        foreach (var item in arr)
                        {
                            var name = null as string;
                            var display = enumType
                                   .GetMember(item.ToString()).First()
                                   .GetCustomAttributes(false)
                                   .OfType<DisplayAttribute>()
                                   .LastOrDefault();

                            if (display != null)
                            {
                                name = display.GetName();
                            }
                            else
                            {
                                name = item.ToString();
                            }

                            (itemTexts as List<string>).Add(name);
                        }

                        helper.ViewContext.HttpContext.Cache["EditorTemplate." + enumType.Name + ".ItemTexts"] = itemTexts;
                    }
                }

                result = WebHelper.CreateSelectList(enumType, SafeClrConvert.ToInt32(value), itemTexts);
            }

            if (result == null)
            {
                result = helper.ViewData["Items"] as IEnumerable<SelectListItem> ?? new List<SelectListItem>();
            }

            return result;
        }
    }
}
