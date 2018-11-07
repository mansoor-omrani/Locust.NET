using Locust.AppPath;
using Locust.Extensions;
using Locust.MvcAttributes;
using Locust.Service;
using Locust.Translation;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Locust.WebTools
{
    public class GetItemsResponse
    {
        public string Hash { get; set; }
        public Dictionary<string, string[]> Data { get; set; }
    }
    public class LocalizationController : MultiLanguageController
    {
        private static string localizationPath;
        private static string defaultExtension;
        private static string allowedStoreNames;
        static LocalizationController()
        {
            localizationPath = WebConfigurationManager.AppSettings["LocalizationPath"];
            defaultExtension = WebConfigurationManager.AppSettings["LocalizationFileDefaultExtension"];
            allowedStoreNames = WebConfigurationManager.AppSettings["LocalizationAllowedStoreNames"] ?? "";

            if (string.IsNullOrEmpty(localizationPath))
            {
#if DEBUG
                localizationPath = $"{ApplicationPath.Root}/Localization";
#else
                localizationPath = $"{ApplicationPath.Root}/../Localization";
#endif
            }

            if (string.IsNullOrEmpty(defaultExtension))
            {
                defaultExtension = "txt";
            }
        }
        public LocalizationController(ITranslator translator):base(translator)
        {
        }
        private Dictionary<string, string[]> GetTranslatorItems(string storename, string hash)
        {
            var result = new Dictionary<string, string[]>();

            if (!string.IsNullOrEmpty(allowedStoreNames) && !string.IsNullOrEmpty(storename) && storename.In(allowedStoreNames))
            {
                result = Translator.GetAll(storename);
            }

            return result;
        }
        private ActionResult GetItems(string storename, string type, string hash)
        {
            var response = new GetItemsResponse();
            var suggestedFiles = new string[]
            {
                localizationPath + $"/{type}/{storename}.{Lang.ShortName}.{defaultExtension}",
                localizationPath + $"/{type}/{storename}-{Lang.ShortName}.{defaultExtension}",
                localizationPath + $"/{type}/{storename}.{defaultExtension}"
            };

            foreach (var file in suggestedFiles)
            {
                if (System.IO.File.Exists(file))
                {
                    response.Data = TranslatorHelper.ReadLocalizationFile(file);
                    break;
                }
            }

            if (response.Data == null)
            {
                response.Data = GetTranslatorItems(storename, hash);
            }

            var result = JsonConvert.SerializeObject(response.Data);
            response.Hash = Locust.Cryptography.Cryptography.GetMD5(result);

            if (!string.IsNullOrEmpty(hash) && string.Compare(hash, response.Hash, true) == 0)
            {
                response.Data = null;
                response.Hash = "";
            }

            result = JsonConvert.SerializeObject(response);

            return Content(result, "text/plain");
        }
        [ActionName("cit")]
        [HttpPost]
        [ETag(duration: 604800, cachecontrol: HttpCacheability.Private)]    // cache for one week
        public ActionResult CultureIndependentText(string id, string hash)
        {
            var result = GetItems(id, "cit", hash);

            return result;
        }
        [ActionName("cdt")]
        [HttpPost]
        [ETag(duration: 604800, cachecontrol: HttpCacheability.Private)]    // cache for one week
        public ActionResult CultureDependentText(string id, string hash)
        {
            var result = GetItems(id, "cdt", hash);

            return result;
        }
    }
}