using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Web.Mvc.Bootstrap3.Models
{
    public enum ButtonSize
    {
        xs, sm, lg
    }
    public enum RenderType
    {
        button, input, anchor
    }
    public enum ButtonType
    {
        button, submit
    }
    public class BootstrapButton
    {
        public string Id { get; set; }
        public string Text { get; set; }
        public ButtonSize? Size { get; set; }
        public DisplayClass ButtonClass { get; set; }
        public ButtonType Type { get; set; }
        public RenderType RenderType { get; set; }
        public string Class { get; set; }
        public string Link { get; set; }
        public bool IsActive { get; set; }
        public bool BlockButton { get; set; }
        public bool Disabled { get; set; }
        public string BodyPartialName { get; set; }
        public object BodyPartialModel { get; set; }
        private Dictionary<string, string> attributes;
        public Dictionary<string, string> Attributes
        {
            get
            {
                if (attributes == null)
                    attributes = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
                return attributes;
            }
            set
            {
                attributes = value;
            }
        }
        public static BootstrapButton Create(ButtonType type, string text, DisplayClass bnClass = DisplayClass.@default, ButtonSize? size = null)
        {
            return new BootstrapButton { Type = type, Text = text, ButtonClass = bnClass, Size = size };
        }
    }
}
