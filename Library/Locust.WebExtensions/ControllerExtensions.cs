using Locust.Base;
using Locust.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Locust.WebExtensions
{
    public static class ControllerExtensions
    {
        public static string RenderViewToString(this Controller controller, string viewPath, object model = null, bool partial = false)
        {
            var result = "";

            controller.ViewData.Model = model;

            using (var sw = new StringWriter())
            {
                ViewEngineResult viewEngineResult = null;
                if (partial)
                    viewEngineResult = ViewEngines.Engines.FindPartialView(controller.ControllerContext, viewPath);
                else
                    viewEngineResult = ViewEngines.Engines.FindView(controller.ControllerContext, viewPath, null);

                if (viewEngineResult == null)
                    throw new FileNotFoundException($"View {viewPath} Could Not Be Found");

                var viewContext = new ViewContext(controller.ControllerContext, viewEngineResult.View, controller.ViewData, controller.TempData, sw);

                viewEngineResult.View.Render(viewContext, sw);
                viewEngineResult.ViewEngine.ReleaseView(controller.ControllerContext, viewEngineResult.View);

                result = sw.GetStringBuilder().ToString();
            }

            return result;
        }
        /* these two methods seem to be obsolete and not usable any more.
         * they are replaced with ClientAwareController and ClientSideContentProvider
         * 1397/01/25
         * 
        public static void AddCss(this Controller controller, string cssPath, bool useMinForRelease = true)
        {
            if (!string.IsNullOrEmpty(cssPath?.Trim()))
            {
                var result = "";
                var path = "";
                var filename = "";
                var i = cssPath.LastIndexOf('/');

                if (i >= 0)
                {
                    path = cssPath.Substring(0, i);
                    filename = cssPath.Substring(i + 1);
                }
                else
                {
                    filename = cssPath;
                }

                if (!string.IsNullOrEmpty(filename))
                {
                    var name = Path.GetFileNameWithoutExtension(filename);
                    var hasMin = name.Right(4).ToLower() == ".min";
                    var extension = Path.GetExtension(filename);
#if DEBUG
                    result = path + filename;
#else
                    result = path + name + (useMinForRelease && !hasMin ? ".min" : "") + extension;
#endif
                    var cssLibs = controller.ViewData[WebHelper.CSS_DEPENDENCIES_KEY];

                    if (cssLibs == null)
                    {
                        cssLibs = new List<string>();
                    }

                    var type = cssLibs.GetType();

                    do
                    {
                        if (type == TypeHelper.TypeOfString)
                        {
                            var prevs = cssLibs.ToString().Trim();
                            controller.ViewData[WebHelper.CSS_DEPENDENCIES_KEY] = (string.IsNullOrEmpty(prevs) ? "": prevs + ",") + result;

                            break;
                        }

                        if (type == typeof(string[]))
                        {
                            var lst = (cssLibs as string[]).ToList();
                            lst.Add(result);
                            controller.ViewData[WebHelper.CSS_DEPENDENCIES_KEY] = lst;

                            break;
                        }

                        if (type == typeof(List<string>))
                        {
                            var lst = cssLibs as List<string>;
                            lst.Add(result);
                            controller.ViewData[WebHelper.CSS_DEPENDENCIES_KEY] = lst;

                            break;
                        }
                        break;
                    } while (true);
                }
            }
        }
        public static void AddJs(this Controller controller, string jsPath, bool useMinForRelease = true)
        {
            if (!string.IsNullOrEmpty(jsPath?.Trim()))
            {
                var result = "";
                var path = "";
                var filename = "";
                var i = jsPath.LastIndexOf('/');

                if (i >= 0)
                {
                    path = jsPath.Substring(0, i);
                    filename = jsPath.Substring(i + 1);
                }
                else
                {
                    filename = jsPath;
                }

                if (!string.IsNullOrEmpty(filename))
                {
                    var name = Path.GetFileNameWithoutExtension(filename);
                    var hasMin = name.Right(4).ToLower() == ".min";
                    var extension = Path.GetExtension(filename);
#if DEBUG
                    result = path + filename;
#else
                    result = path + name + (useMinForRelease && !hasMin ? ".min" : "") + extension;
#endif
                    var jsLibs = controller.ViewData[WebHelper.JS_DEPENDENCIES_KEY];

                    if (jsLibs == null)
                    {
                        jsLibs = new List<string>();
                    }

                    var type = jsLibs.GetType();

                    do
                    {
                        if (type == TypeHelper.TypeOfString)
                        {
                            var prevs = jsLibs.ToString().Trim();
                            controller.ViewData[WebHelper.JS_DEPENDENCIES_KEY] = (string.IsNullOrEmpty(prevs) ? "" : prevs + ",") + result;

                            break;
                        }

                        if (type == typeof(string[]))
                        {
                            var lst = (jsLibs as string[]).ToList();
                            lst.Add(result);
                            controller.ViewData[WebHelper.JS_DEPENDENCIES_KEY] = lst;

                            break;
                        }

                        if (type == typeof(List<string>))
                        {
                            var lst = jsLibs as List<string>;
                            lst.Add(result);
                            controller.ViewData[WebHelper.JS_DEPENDENCIES_KEY] = lst;

                            break;
                        }
                        break;
                    } while (true);
                }
            }
        }
        */
    }
}
