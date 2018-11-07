using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Locust.MvcAttributes
{
    public class ETagAttribute : ActionFilterAttribute
    {
        private int duration;
        private HttpCacheability cachecontrol;
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Filter = new ETagFilter(filterContext.HttpContext.Response, filterContext.RequestContext.HttpContext.Request, duration, cachecontrol);
        }
        public ETagAttribute()
        {
            this.duration = -1;
            this.cachecontrol = HttpCacheability.ServerAndNoCache;
        }
        public ETagAttribute(int duration, HttpCacheability cachecontrol)
        {
            this.duration = duration;
            this.cachecontrol = cachecontrol;
        }
        public ETagAttribute(HttpCacheability cachecontrol)
        {
            this.duration = -1;
            this.cachecontrol = cachecontrol;
        }
        public ETagAttribute(int duration)
        {
            this.duration = duration;
            this.cachecontrol = HttpCacheability.ServerAndNoCache;
        }
    }
    public class ETagFilter : MemoryStream
    {
        private HttpResponseBase _response = null;
        private HttpRequestBase _request;
        private Stream _filter = null;
        private int duration;
        private HttpCacheability cachecontrol;
        public ETagFilter(HttpResponseBase response, HttpRequestBase request, int duration, HttpCacheability cachecontrol)
        {
            _response = response;
            _request = request;
            _filter = response.Filter;

            this.duration = duration;
            this.cachecontrol = cachecontrol;
        }

        private string GetToken(Stream stream)
        {
            var checksum = new byte[0];

            checksum = MD5.Create().ComputeHash(stream);

            return Convert.ToBase64String(checksum, 0, checksum.Length);
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            var data = new byte[count];

            Buffer.BlockCopy(buffer, offset, data, 0, count);

            var token = GetToken(new MemoryStream(data));

            var clientToken = _request.Headers["If-None-Match"];

            if (token != clientToken)
            {

                _response.Cache.SetLastModified(DateTime.Now);
                _response.Cache.SetExpires(DateTime.Now.AddSeconds(this.duration));

                try
                {
                    _response.Cache.SetETag(token);
                }
                catch (Exception)
                { }

                _response.Cache.SetCacheability(cachecontrol);

                _filter.Write(data, 0, count);
            }
            else
            {
                _response.SuppressContent = true;
                _response.StatusCode = 304;
                _response.StatusDescription = "Not Modified";
                _response.Headers["Content-Length"] = "0";
            }
        }
    }
}
