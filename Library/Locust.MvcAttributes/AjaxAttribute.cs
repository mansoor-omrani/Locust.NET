using Locust.Service;
using System;
using System.Text;
using System.Web.Mvc;

namespace Locust.MvcAttributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AjaxAttribute : ActionFilterAttribute
    {
        public string MessageKey { get; set; }
        public AjaxAttribute(string messageKey = "")
        {
            MessageKey = messageKey;
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (!actionContext.HttpContext.Request.IsAjaxRequest())
            {
                var data = new ServiceResponse { Status = "NotAjaxRequest", MessageKey = MessageKey };
                var response = data.ToJson();
                var result = new ContentResult();

                result.ContentType = "application/json";
                result.ContentEncoding = Encoding.UTF8;
                result.Content = response;

                actionContext.Result = result;
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AjaxPostAttribute : AjaxAttribute
    {
        public AjaxPostAttribute(string messageKey = ""):base(messageKey)
        {
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.Request.HttpMethod.ToUpper() != "POST")
            {
                var data = new ServiceResponse { Status = "PostRequestExpected", MessageKey = MessageKey };
                var response = data.ToJson();
                var result = new ContentResult();

                result.ContentType = "application/json";
                result.ContentEncoding = Encoding.UTF8;
                result.Content = response;

                actionContext.Result = result;
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AjaxGetAttribute : AjaxAttribute
    {
        public AjaxGetAttribute(string messageKey = "") : base(messageKey)
        {
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.Request.HttpMethod.ToUpper() != "GET")
            {
                var data = new ServiceResponse { Status = "GetRequestExpected", MessageKey = MessageKey };
                var response = data.ToJson();
                var result = new ContentResult();

                result.ContentType = "application/json";
                result.ContentEncoding = Encoding.UTF8;
                result.Content = response;

                actionContext.Result = result;
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AjaxPutAttribute : AjaxAttribute
    {
        public AjaxPutAttribute(string messageKey = "") : base(messageKey)
        {
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.Request.HttpMethod.ToUpper() != "PUT")
            {
                var data = new ServiceResponse { Status = "PutRequestExpected", MessageKey = MessageKey };
                var response = data.ToJson();
                var result = new ContentResult();

                result.ContentType = "application/json";
                result.ContentEncoding = Encoding.UTF8;
                result.Content = response;

                actionContext.Result = result;
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AjaxDeleteAttribute : AjaxAttribute
    {
        public AjaxDeleteAttribute(string messageKey = "") : base(messageKey)
        {
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.Request.HttpMethod.ToUpper() != "DELETE")
            {
                var data = new ServiceResponse { Status = "DeleteRequestExpected", MessageKey = MessageKey };
                var response = data.ToJson();
                var result = new ContentResult();

                result.ContentType = "application/json";
                result.ContentEncoding = Encoding.UTF8;
                result.Content = response;

                actionContext.Result = result;
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }
    }
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class AjaxHeadAttribute : AjaxAttribute
    {
        public AjaxHeadAttribute(string messageKey = "") : base(messageKey)
        {
        }
        public override void OnActionExecuting(ActionExecutingContext actionContext)
        {
            if (actionContext.HttpContext.Request.HttpMethod.ToUpper() != "HEAD")
            {
                var data = new ServiceResponse { Status = "HeadRequestExpected", MessageKey = MessageKey };
                var response = data.ToJson();
                var result = new ContentResult();

                result.ContentType = "application/json";
                result.ContentEncoding = Encoding.UTF8;
                result.Content = response;

                actionContext.Result = result;
            }
            else
            {
                base.OnActionExecuting(actionContext);
            }
        }
    }
}
