using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Extensions;
using System.Runtime.CompilerServices;

namespace Locust.Logging
{
    public class StringLogger:BaseLogger
    {
        private StringBuilder sb;

        public StringLogger()
        {
            sb = new StringBuilder();
        }
        
        public override string ToString()
        {
            var result = sb.ToString();
            sb = new StringBuilder();
            return result;
        }

        protected override void LogCategoryInternal(string data)
        {
            sb.Append(data);
        }

        protected override void LogInternal(string data)
        {
            sb.Append(data);
        }
    }
}
