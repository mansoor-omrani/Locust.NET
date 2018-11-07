using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Locust.Test.Mvc;
using Locust.ConnectionString;
using Locust.ConnectionString.Json;
using System.Configuration;
using Newtonsoft.Json;
using Locust.Extensions;
using Locust.Test.Models;
using Locust.WebTools;
using Locust.Service;
using Locust.Translation;

namespace Locust.Test.Mvc.Areas.Test.Controllers
{
    [TestAction]
    public class DbConnectionController : ClientAwareController
    {
        public DbConnectionController(ITranslator translator) : base(translator)
        {
        }

        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Check(string provider, string cnn)
        {
            if (string.IsNullOrEmpty(provider))
            {
                return Json(new ServiceResponse{ Success = false, Message = "No provider specified" });
            }

            if (string.IsNullOrEmpty(cnn))
            {
                return Json(new ServiceResponse { Success = false, Message = "No connectionstring specified to check" });
            }

            var result = false;
            var msg = "";
            IConnectionStringProvider cnnProvider = null;

            switch (provider)
            {
                case "Json": cnnProvider = JsonConnectionStringProvider.Create();
                    break;
                case "AppConfig":
                    cnnProvider = new AppConfigConnectionStringProvider();
                    break;
                case "InMemory":
                    cnnProvider = Utils.CreateInMemoryConnectionStringProvider();
                    break;
                default:
                    return Json(new ServiceResponse { Success = false, Message = "Invalid Provider" });
                    break;
            }

            using (var con = new SqlConnection(cnnProvider.GetConnectionString(cnn)))
            {
                try
                {
                    con.Open();
                    result = true;
                    con.Close();
                }
                catch (Exception e)
                {
                    msg = e.Message;
                }
            }

            return Json(new ServiceResponse { Success = result, Message = msg });
        }
        [HttpPost]
        public ActionResult ManualCheck(string datasource, string initialCatalog, string integratedSecurity, string userid, string password)
        {
            var result = false;
            var msg = "";

            var dataSourcePart          = string.IsNullOrEmpty(datasource)          ? "" : $";Data Source={datasource}";
            var initialCatalogPart      = string.IsNullOrEmpty(initialCatalog)      ? "" : $";Initial Catalog={initialCatalog}";
            var integratedSecurityPart  = string.IsNullOrEmpty(integratedSecurity)  ? "" : $";Integrated Security={integratedSecurity}";
            var useridPart              = string.IsNullOrEmpty(userid)              ? "" : $";User Id={userid}";
            var passwordPart            = string.IsNullOrEmpty(password)            ? "" : $";password={password}";

            var connectionString = $"{dataSourcePart}{initialCatalogPart}{integratedSecurityPart}{useridPart}{passwordPart}";

            if (string.IsNullOrEmpty(connectionString))
                return Json(new { Result = false, Message = "Nothing to check" });

            connectionString = connectionString.Right(connectionString.Length - 1);

            using (var con = new SqlConnection(connectionString))
            {
                try
                {
                    con.Open();
                    result = true;
                    con.Close();
                }
                catch (Exception e)
                {
                    msg = e.Message;
                }
            }

            return Json(new ServiceResponse{ Success = result, Message = msg });
        }
    }
}