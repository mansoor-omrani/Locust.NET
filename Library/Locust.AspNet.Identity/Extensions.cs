using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Locust.AspNet.Identity.Models;

namespace Locust.AspNet.Identity
{
    public static class Extensions
    {
        public static void Add(this ApiResultMessages messages, ModelStateDictionary modelState)
        {
            foreach (var item in modelState)
            {
                var ms = item.Value;

                foreach (var modelError in ms.Errors)
                {
                    var errorText = modelError.ErrorMessage;

                    if (!String.IsNullOrEmpty(errorText))
                    {
                        messages.Add(errorText);
                    }
                }
            }
        }
    }
}
