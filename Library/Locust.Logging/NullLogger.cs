using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Logging
{
    public class NullLogger:BaseLogger
    {
        public NullLogger()
        {
        }
        public NullLogger(BaseLogger next) : base(next)
        {
        }
        protected override void LogCategoryInternal(string data)
        {
        }

        protected override void LogInternal(string data)
        {
        }
        protected override string SerializeLog(object log)
        {
            return null;
        }
        protected override string SerializeLogCategory(object category)
        {
            return null;
        }
    }
}
