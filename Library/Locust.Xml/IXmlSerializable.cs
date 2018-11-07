using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Xml
{
    public class XmlSerializationOptions
    {
        public bool UseIndentation { get; set; }
        public string Indent { get; set; }
        public string CurrentIndent { get; set; }
        public XmlSerializationOptions()
        {
            Indent = new string(' ', 4);
        }
        public XmlSerializationOptions(XmlSerializationOptions options)
        {
            if (options != null)
            {
                this.UseIndentation = options.UseIndentation;
                this.Indent = options.Indent;
                this.CurrentIndent = options.CurrentIndent + Indent;
            }
        }
    }
    public interface IXmlSerializable
    {
        string ToXml(XmlSerializationOptions options = null);
    }
}
