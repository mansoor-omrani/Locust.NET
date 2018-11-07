using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Locust.WebTools
{
    public interface IHttpContextProvider
    {
        void Capture();
        HttpContextBase Get(bool cacheContext = false);
        void Set(HttpContextBase context);
    }

    public class DefaultHttpContextProvider : IHttpContextProvider
    {
        protected HttpContextBase _context;

        public DefaultHttpContextProvider()
        {
        }
        public HttpContextBase Get(bool cacheContext = false)
        {
            if (!cacheContext || _context == null)
                Capture();

            return _context;
        }

        public void Capture()
        {
            if (HttpContext.Current != null)
            {
                _context = new HttpContextWrapper(HttpContext.Current);
            }
        }
        public void Set(HttpContextBase context)
        {
            this._context = context;
        }
    }
    public class ControllerHttpContextProvider : IHttpContextProvider
    {
        private ControllerContext controllerContext;
        public ControllerHttpContextProvider(ControllerContext controllerContext)
        {
            this.controllerContext = controllerContext;
        }
        public void Capture()
        { }

        public HttpContextBase Get(bool cacheContext = false)
        {
            return controllerContext.HttpContext;
        }

        public void Set(HttpContextBase context)
        {
            throw new NotImplementedException();
        }
    }
    public class ViewHttpContextProvider : IHttpContextProvider
    {
        private ViewContext viewContext;
        public ViewHttpContextProvider(ViewContext viewContext)
        {
            this.viewContext = viewContext;
        }
        public void Capture()
        { }

        public HttpContextBase Get(bool cacheContext = false)
        {
            return viewContext.HttpContext;
        }

        public void Set(HttpContextBase context)
        {
            throw new NotImplementedException();
        }
    }
    public class FakeHttpContextProvider : IHttpContextProvider
    {
        private HttpContextBase _context;
        public void Capture()
        {
            if (_context == null)
            {
                var fakeHttpContext = new HttpContext(
                    new HttpRequest("", "http://tempuri.org", ""),
                    new HttpResponse(new StringWriter())
                    );

                fakeHttpContext.User = new GenericPrincipal(new GenericIdentity(String.Empty), new string[0]);
                _context = new HttpContextWrapper(fakeHttpContext);
            }
        }

        public HttpContextBase Get(bool cacheContext = false)
        {
            if (!cacheContext || _context == null)
                Capture();

            return _context;
        }

        public void Set(HttpContextBase context)
        {
            _context = context;
        }
    }
}
