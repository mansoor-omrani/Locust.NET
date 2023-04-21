using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Locust.Extensions;
using System.Runtime.CompilerServices;

namespace Locust.Logging.Win
{
    public class TextBoxLogger : BaseLogger
    {
        public TextBox Target { get; set; }

        protected override void LogCategoryInternal(string category)
        {
            if (Target != null)
            {
                var d = DateTime.Now;
                Action act =
                    () => Target.Text += string.Format("\r\n{0}{1}", d, ((category != null) ? ": " + category : ""));
                Target.Invoke(act);
            }
        }

        protected override void LogInternal(string data)
        {
            if (Target != null)
            {
                Action act = () => Target.Text += string.Format("\r\n   {0}", data);

                Target.Invoke(act);
            }
        }
    }
}
