using Locust.Extensions;
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
        public static string Merge(this IEnumerable<ModelError> list, string separator)
        {
            var result = "";
            var count = 0;

            foreach (var item in list)
            {
                var msg = string.IsNullOrEmpty(item.ErrorMessage) ? item.Exception != null ? item.Exception.Message : "" : item.ErrorMessage;

                result += (count == 0) ? msg : separator + msg;

                count++;
            }

            return result;
        }
        public static string Merge(this IEnumerable<ModelState> modelStates, string separator)
        {
            var sb = new StringBuilder();

            foreach (var modelState in modelStates)
            {
                sb.Append((sb.Length == 0 ? "" : separator) + modelState.Errors.Merge(separator));
            }

            return sb.ToString();
        }
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
