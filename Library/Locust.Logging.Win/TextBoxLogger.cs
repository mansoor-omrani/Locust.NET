using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Locust.Extensions;

namespace Locust.Logging.Win
{
    public class TextBoxLogger:ILogger
    {
        public TextBox Target { get; set; }
        
        public void LogCategory(object category = null)
        {
            if (Target != null)
            {
                var d = DateTime.Now;
                Action act =
                    () => Target.Text += string.Format("\r\n{0}{1}", d, ((category != null) ? ": " + category : ""));
                Target.Invoke(act);
            }
        }
        public void Log(object log)
        {
            if (Target != null)
            {
                string x = null;
                if (log != null)
                {
                    if (log.GetType().IsNullableOrBasicType())
                        x = log.ToString();
                    else
                    {
                        x = JsonConvert.SerializeObject(log, Formatting.Indented);
                    }
                }
                Action act =
                    () => Target.Text += string.Format("\r\n   {0}", x);
                Target.Invoke(act);
            }
        }
    }
}
