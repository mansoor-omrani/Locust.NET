using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Locust.WebExtensions
{
    public static class ModelStateExtensions
    {
        public static void AddDetailedModelException(this ModelStateDictionary modelState, string key, Exception e)
        {
            var current = e;
            while (current != null)
            {
                modelState.AddModelError(key, current.Message);
                current = current.InnerException;
            }
        }
        public static void AddDetailedModelExceptionIfUserIsInRole(this ModelStateDictionary modelState, string key, Exception e, string role)
        {
            if (HttpContext.Current?.User?.IsInRole(role) == true)
            {
                modelState.AddDetailedModelException(key, e);
            }
        }
        public static void AddModelErrors(this ModelStateDictionary modelState, Dictionary<string, string> dictionary)
        {
            if (dictionary != null)
            {
                foreach (var item in dictionary)
                {
                    modelState.AddModelError(item.Key, item.Value);
                }
            }
        }
        public static void AddModelErrorIfUserIsInRole(this ModelStateDictionary modelState, string key, string errorMessage, string role)
        {
            if (HttpContext.Current?.User?.IsInRole(role) == true)
            {
                modelState.AddModelError(key, errorMessage);
            }
        }
        public static MvcHtmlString ValidationMessageIfUserIsInRole(this HtmlHelper htmlHelper, string modelName, object htmlAttributes, string role)
        {
            if (HttpContext.Current?.User?.IsInRole(role) == true)
            {
                return htmlHelper.ValidationMessage(modelName, htmlAttributes);
            }
            else
            {
                return new MvcHtmlString("");
            }
        }
    }
}
