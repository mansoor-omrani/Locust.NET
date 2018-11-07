using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Locust.Test.Mvc;
using Locust.Caching;
using Locust.WebTools;
using Locust.Test.Models;
using Locust.Service;
using Locust.Translation;

namespace Locust.Test.Mvc.Areas.Test.Controllers
{
    [TestAction]
    public partial class CacheController : ClientAwareController
    {
        public class MyData
        {
            public string Fn { get; set; }
            public string Ln { get; set; }
            public int Age { get; set; }
            public bool Sex { get; set; }
        }
        private ICacheFactory cacheFactory;
        public CacheController(ICacheFactory cacheFactory, ITranslator translator) : base(translator)
        {
            this.cacheFactory = cacheFactory;
        }
        private ICacheManager Cache(string id)
        {
            return cacheFactory.Get(id);
        }
        public virtual ActionResult Index()
        {
            ViewBag.Factory = cacheFactory;

            return View();
        }
        public virtual ActionResult Page(string id)
        {
            ViewBag.CacheName = Cache(id).Config.Name;
            ViewBag.Id = id;

            return View();
        }
        private JsonResult validate(string id, string key)
        {
            var result = null as JsonResult;

            if (string.IsNullOrEmpty(id))
            {
                result = Json(new ServiceResponse { Success = false, Message = "No Cache specified" });
            }
            else
            if (string.IsNullOrEmpty(key))
            {
                result = Json(new ServiceResponse { Success = false, Message = "No key specified" });
            }

            return result;
        }
        [HttpPost]
        public virtual JsonResult Add(string id, string key, int lifeLength, MyData data)
        {
            var result = validate(id, key);

            if (result == null)
            {
                Cache(id).Add(key, data, lifeLength);

                return Json(new ServiceResponse { Success = true });
            }
            else
            {
                return result;
            }
        }
        [HttpPost]
        public virtual JsonResult Remove(string id, string key)
        {
            var result = validate(id, key);

            if (result == null)
            {
                Cache(id).Remove(key);

                return Json(new ServiceResponse { Success = true });
            }
            else
            {
                return result;
            }
        }
        [HttpPost]
        public virtual JsonResult Get(string id, string key)
        {
            var result = validate(id, key);

            if (result == null)
            {
                var data = Cache(id).Get<MyData>(key);

                return Json(new ServiceResponse<MyData> { Success = data != null, Data = data });
            }
            else
            {
                return result;
            }
        }
        [HttpPost]
        public virtual JsonResult GetItem(string id, string key)
        {
            var result = validate(id, key);

            if (result == null)
            {
                var data = Cache(id).GetItem(key);

                return Json(new ServiceResponse<CacheItem> { Success = data != null, Data = data });
            }
            else
            {
                return result;
            }
        }
        [HttpPost]
        public async virtual Task<JsonResult> TryGet(string id, string key, string dependentKey)
        {
            var result = validate(id, key);

            if (result == null)
            {
                var cache = Cache(id);
                var data = await cache.TryGetAsync<MyData>(key, (item) => Task.FromResult(string.IsNullOrEmpty(dependentKey) || cache.Contains(dependentKey)));

                return Json(new ServiceResponse<MyData> { Success = data != null, Data = data });
            }
            else
            {
                return result;
            }
        }
        [HttpPost]
        public virtual JsonResult Contains(string id, string key)
        {
            var result = validate(id, key);

            if (result == null)
            {
                var flag = Cache(id).Contains(key);

                return Json(new ServiceResponse { Success = flag });
            }
            else
            {
                return result;
            }
        }
        [HttpPost]
        public virtual JsonResult Clean(string id)
        {
            var data = Cache(id).Clean();

            return Json(new ServiceResponse<CacheManagerCleanResult> { Success = true, Data = data });
        }
        [HttpPost]
        public virtual JsonResult Clear(string id)
        {
            Cache(id).Clear();

            return Json(new ServiceResponse { Success = true });
        }
        [HttpPost]
        public virtual JsonResult Count(string id)
        {
            return Json(new ServiceResponse<int> { Success = true, Data = Cache(id).Count });
        }
    }
}