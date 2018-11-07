using Locust.Conversion;
using Locust.Serialization;
using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.StateProvider
{
    public class SessionStateProvider<T>: BaseStateProvider<T> where T:class, new()
    {
        #region ctor
        public SessionStateProvider(string name) : base(name)
        { }
        public SessionStateProvider(string name, HttpContextBase context): base(name, context)
        { }
        public SessionStateProvider(string name, IHttpContextProvider httpContextProvider, ISerializer serializer) : base(name, httpContextProvider, serializer)
        {
        }
        #endregion
        public HttpSessionStateBase Session
        {
            get { return HttpContext.Session; }
        }
        protected override void StoreInternal()
        {
            if (Session != null)
            {
                if (Stat.Removed)
                {
                    Session.Remove(Name);
                    Session.Remove(Name + ".Stat");
                }
                else
                {
                    Session[Name] = Value;
                    Session[Name + ".Stat"] = Stat;
                }
            }
            else
                throw new Exception("No Session found!");
        }
        public override void Restore()
        {
            if (Session != null)
            {
                Value = Session[Name] as T;
                Stat = Session[Name + ".Stat"] as StateProviderItem;
            }
            else
                throw new Exception("No Session found!");
        }
    }
}
