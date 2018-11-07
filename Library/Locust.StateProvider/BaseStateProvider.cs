using Locust.Conversion;
using Locust.Logging;
using Locust.Serialization;
using Locust.WebTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Locust.StateProvider
{
    
    public abstract class BaseStateProvider<T>:IStateProvider<T> where T : class, new()
    {
        public string Name { get; private set; }
        public bool ThrowIfAlreadyStored { get; set; }
        private bool ValueChanged
        {
            get
            {
                var result = false;
                var c = HttpContext.Items[Name + ".Changed"];

                if (c == null)
                {
                    HttpContext.Items[Name + ".Changed"] = false;
                }
                else
                {
                    result = SafeClrConvert.ToBoolean(c);
                }

                return result;
            }
            set
            {
                HttpContext.Items[Name + ".Changed"] = value;
            }
        }
        public virtual ILogger Logger { get; set; }
        public virtual IExceptionLogger ExceptionLogger { get; set; }
        private IHttpContextProvider httpContextProvider;
        public IHttpContextProvider HttpContextProvider
        {
            get
            {
                if (httpContextProvider == null)
                    httpContextProvider = new DefaultHttpContextProvider();
                return httpContextProvider;
            }
            set { httpContextProvider = value; }
        }
        private ISerializer serializer;
        public ISerializer Serializer
        {
            get
            {
                if (serializer == null)
                    serializer = new JsonSerializer();
                return serializer;
            }
            set { serializer = value; }
        }
        private HttpContextBase httpContext;
        public HttpContextBase HttpContext
        {
            get
            {
                if (httpContext == null)
                    httpContext = HttpContextProvider.Get();
                return httpContext;
            }
            set { httpContext = value; }
        }
        public T Value
        {
            get
            {
                return HttpContext.Items[Name] as T;
            }
            set
            {
                if (Stat.Stored)
                {
                    if (ThrowIfAlreadyStored)
                    {
                        throw new Exception("object already saved in the state storage and cannot be changed any more.");
                    }
                }
                else
                {
                    HttpContext.Items[Name] = value;

                    var s = Stat;
                    s.LastModified = DateTime.Now;
                    Stat = s;

                    ValueChanged = true;
                }
            }
        }
        public StateProviderItem Stat
        {
            get
            {
                var stat = HttpContext.Items[Name + ".Stat"] as StateProviderItem;
                if (stat == null)
                {
                    stat = new StateProviderItem();
                    HttpContext.Items[Name + ".Stat"] = stat;
                }

                return stat;
            }
            protected set
            {
                HttpContext.Items[Name + ".Stat"] = value;
            }
        }
        protected void Stored(bool value = true)
        {
            var s = Stat;
            s.Stored = value;
            Stat = s;
        }
        public BaseStateProvider(string name)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException(nameof(name));

            Name = name;
        }
        public BaseStateProvider(string name, HttpContextBase context): this(name)
        {
            this.httpContext = context;
        }
        public BaseStateProvider(string name, IHttpContextProvider httpContextProvider, ISerializer serializer): this(name)
        {
            this.HttpContextProvider = httpContextProvider;
            this.Serializer = serializer;
        }
        public virtual void Remove()
        {
            var s = Stat;
            s.Removed = true;
            Stat = s;
        }
        protected abstract void StoreInternal();
        public void Store()
        {
            if (ValueChanged)
            {
                StoreInternal();
            }
        }
        public abstract void Restore();
    }
}
