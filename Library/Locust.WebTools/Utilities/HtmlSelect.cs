using Locust.Conversion;
using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Locust.WebTools
{
    public class HtmlOption
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string ClassName { get; set; }
        public string Title { get; set; }
    }
    public class HtmlSelect
    {
        public string Name { get; set; }
        public string ID { get; set; }
        public string Class { get; set; }
        public string Style { get; set; }
        public bool Multiple { get; set; }
        public int Size { get; set; }
        public string DefaultValue { get; set; }
        public string FirstValue { get; set; }
        public string FirstText { get; set; }
        public string CurrentValue { get; set; }
        public Dictionary<string, string> Items { get; set; }

        public string Render()
        {
            var sb = new List<string>();

            sb.Add("<select");

            if (!string.IsNullOrEmpty(Name))
                sb.Add(" name=\"" + HttpUtility.HtmlEncode(Name) + "\"");
            if (!string.IsNullOrEmpty(ID))
                sb.Add(" id=\"" + HttpUtility.HtmlEncode(ID) + "\"");
            if (!string.IsNullOrEmpty(Class))
                sb.Add(" class=\"" + HttpUtility.HtmlEncode(Class) + "\"");
            if (!string.IsNullOrEmpty(Style))
                sb.Add(" style=\"" + HttpUtility.HtmlEncode(Style) + "\"");
            if (Size > 0)
                sb.Add(" size=\"" + Size.ToString() + "\"");
            if (Multiple)
                sb.Add(" multiple=\"multiple\"");

            sb.Add(">");

            if (!string.IsNullOrEmpty(FirstValue) || !string.IsNullOrEmpty(FirstText))
                sb.Add("<option value=\"" + HttpUtility.HtmlEncode(FirstValue) + "\">" + HttpUtility.HtmlEncode(FirstText) + "</option>");

            var hit = false;
            var optStart = sb.Count;

            foreach (var item in Items)
            {
                var id = SafeClrConvert.ToString(item.Key);
                var title = SafeClrConvert.ToString(item.Value);

                if (id == CurrentValue)
                {
                    sb.Add("<option value=\"" + HttpUtility.HtmlEncode(CurrentValue) + "\" selected=\"selected\">" +
                              title + "</option>");
                    hit = true;
                }
                else
                    sb.Add("<option value=\"" + HttpUtility.HtmlEncode(id) + "\">" + title + "</option>");
            }

            if (!hit && !string.IsNullOrEmpty(DefaultValue))
            {
                var index = Items.IndexOf(DefaultValue);

                if (index >= 0)
                {
                    var title = Items[DefaultValue];
                    sb[optStart + index] = "<option value=\"" + HttpUtility.HtmlEncode(DefaultValue) +
                                           "\" selected=\"selected\">" +
                                           title + "</option>";
                }
            }

            sb.Add("</select>");

            return sb.Join("");
        }

        public HtmlSelect()
        {
            this.Items = new Dictionary<string, string>();
        }
    }
}
