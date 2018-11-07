using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Tracing
{
    [Serializable]
    public class SqlCmdException : Exception
    {
        public int Line { get; set; }
        public int Number { get; set; }
        public int State { get; set; }
        public int Severity { get; set; }
        public string Procedure { get; set; }
        public string Description { get; set; }
        public SqlCmdException()
        {
        }

        public SqlCmdException(SerializationInfo info, StreamingContext context)
        {
            if (info != null)
            {
                try { HResult = info.GetInt32("HResult"); } catch { }
                try { Line = info.GetInt32("Line"); } catch { }
                try { Number = info.GetInt32("Number"); } catch { }
                try { State = info.GetInt32("State"); } catch { }
                try { Severity = info.GetInt32("Severity"); } catch { }
                try { Procedure = info.GetString("Procedure"); } catch { }
                try { Description = info.GetString("Description"); } catch { }
                try { Source = info.GetString("Source"); } catch { }
                try { HelpLink = info.GetString("HelpLink"); } catch { }
            }
        }
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            if (info != null)
            {
                info.AddValue("Line", this.Line);
                info.AddValue("Number", this.Number);
                info.AddValue("State", this.State);
                info.AddValue("Severity", this.Severity);
                info.AddValue("Procedure", this.Procedure);
                info.AddValue("Description", this.Description);
            }
        }
    }
}
