using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Locust.Conversion;
using Locust.Extensions;
using Locust.WebTools;

namespace Locust.Tracing
{
    public class PublicWebDebugRequestGetter:IDebugRequestGetter
    {
        protected IHttpContextProvider contextProvider;
        protected HttpContextBase context;

        private void Init(IHttpContextProvider contextProvider)
        {
            if (contextProvider == null)
            {
                throw new ArgumentNullException("contextProvider");
            }

            this.contextProvider = contextProvider;
            context = contextProvider.Get();
        }
        public PublicWebDebugRequestGetter()
        {
            Init(new DefaultHttpContextProvider());
        }
        public PublicWebDebugRequestGetter(IHttpContextProvider contextProvider)
        {
            Init(contextProvider);
        }
        public virtual bool GetDebugMode()
        {
            return SafeClrConvert.ToBoolean(context.Request.Headers["x-app-debug"]);
        }

        public virtual bool GetTraceMode()
        {
            return SafeClrConvert.ToBoolean(context.Request.Headers["x-app-trace"]);
        }

        public virtual DebugLevel GetDebugLevel()
        {
            var result = DebugLevel.Dialog;

            if (context != null)
            {
                var x = SafeClrConvert.ToString(context.Request.Headers["x-app-debug-level"]);

                if (x.IsNumeric())
                {
                    result = SafeClrConvert.ToInt32(x).ToEnum<DebugLevel>();
                }
                else
                {
                    Enum.TryParse(x, true, out result);
                }
            }

            return result;
        }

        public virtual MessageViewerType GetViewerType()
        {
            var result = MessageViewerType.Guest;

            if (context != null)
            {
                var x = SafeClrConvert.ToString(context.Request.Headers["x-app-viewer-type"]);

                if (x.IsNumeric())
                {
                    result = SafeClrConvert.ToInt32(x).ToEnum<MessageViewerType>();
                }
                else
                {
                    Enum.TryParse(x, true, out result);
                }
            }

            return result;
        }
    }
}
