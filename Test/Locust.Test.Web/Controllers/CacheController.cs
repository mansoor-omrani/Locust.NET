using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Locust.Caching;
using Locust.Caching.Web;
using Locust.Conversion;
using Locust.Db;
using Locust.RandomGenerator;

namespace Locust.Test.Web.Controllers
{
    public class Foo
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public bool Exists { get; set; }
        public decimal Price { get; set; }
    }
    public class CacheController : Controller
    {
        private static int count = 1;
        private ICacheManager GetCache()
        {
            var cfg = new CacheConfig { AutoExpire = true, AutoRemoveDeadItems = true, Duration = 10, Name = "myConfig"};
            ICacheManager wcm = new WebCacheManager(cfg);
            wcm = new HttpCacheManager(cfg);
            return wcm;
        }

        private IEnumerable<KeyValuePair<string, CacheItem>> GetItems()
        {
            var wcm = GetCache();
            var model = wcm.GetAll();

            return model;
        }
        public ActionResult Index(string id = "")
        {
            var model = GetItems();

            ViewBag.CurrentItem = id;
            ViewBag.Message = TempData["Message"];
            ViewBag.Item = TempData["Item"];

            return View(model);
        }
        [HttpPost]
        public ActionResult Add()
        {
            try
            {
                var wcm = GetCache();
                var key = SafeClrConvert.ToString(Request.Form["txtKey"]);
                var f = JsonConvert.DeserializeObject<Foo>(SafeClrConvert.ToString(Request.Form["txtData"]));
                var life = SafeClrConvert.ToInt32(Request.Form["txtLifeLength"]);

                if (life < 0)
                {
                    life = 0;
                }

                if (f != null && !string.IsNullOrEmpty(key))
                {
                    wcm.Add(key, f, life);

                    TempData["Message"] = "Item added";
                }
                else
                {
                    TempData["Message"] = "Item is not Foo or has no key";
                }
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
            }

            return Redirect("/cache");
        }
        [HttpPost]
        public ActionResult Edit(string id)
        {
            try
            {
                var wcm = GetCache();
                var key = SafeClrConvert.ToString(Request.Form["txtKey"]);
                var f = JsonConvert.DeserializeObject<Foo>(SafeClrConvert.ToString(Request.Form["txtData"]));
                var life = SafeClrConvert.ToInt32(Request.Form["txtLifeLength"]);

                if (life < 0)
                {
                    life = 0;
                }

                if (f != null && !string.IsNullOrEmpty(key))
                {
                    wcm.Add(key, f, life);
                }

                TempData["Message"] = "Item updated";
            }
            catch (Exception e)
            {
                TempData["Message"] = e.Message;
            }

            return Redirect("/cache");
        }
        public ActionResult Remove(string id)
        {
            var wcm = GetCache();

            wcm.Remove(id);

            TempData["Message"] = "Item removed";

            return Redirect("/cache");
        }
        public ActionResult Clean()
        {
            var wcm = GetCache();

            wcm.Clean();

            TempData["Message"] = "Cache cleaned";

            return Redirect("/cache");
        }
        [HttpPost]
        public ActionResult Get()
        {
            var wcm = GetCache();
            var key = SafeClrConvert.ToString(Request.Form["txtKey"]);
            var x = wcm.Get(key);

            TempData["Item"] = x;

            if (x == null)
            {
                TempData["Message"] = "Item not found";
            }

            return Redirect("/cache");
        }

        private void consume(object x)
        {
            
        }

        private double Harness(ICacheManager cm, int TaskCount, int MaxItems, int GetCount)
        {
            var srg = new SimpleRandomGenerator();

            for (var i = 0; i < MaxItems; i++)
            {
                var f = new Foo();

                f.Name = srg.Generate(new RandomGeneratorSetting(RandomCodeType.Alpha, 300));
                f.Size = SafeClrConvert.ToInt32(new RandomGeneratorSetting(RandomCodeType.Num, 3));
                f.Price = SafeClrConvert.ToInt32(new RandomGeneratorSetting(RandomCodeType.Num, 5));
                f.Exists = SafeClrConvert.ToInt32(new RandomGeneratorSetting(RandomCodeType.Num, 2)) % 2 == 0;

                cm.Add("item" + i, f);
            }

            var tasks = new Task[TaskCount];
            var rnd = new Random();

            for (var i = 0; i < TaskCount; i++)
            {
                tasks[i] = new Task((c) =>
                {
                    var _c = c as ICacheManager;

                    if (_c != null)
                    {
                        for (var j = 0; j < GetCount; j++)
                        {
                            var x = _c.Get("item" + rnd.Next(0, MaxItems));

                            consume(x);

                            Thread.Yield();
                        }
                    }
                }, cm);
            }
            var sw = new Stopwatch();
            sw.Start();
            for (var i = 0; i < TaskCount; i++)
            {
                tasks[i].Start();
            }

            Task.WaitAll(tasks);
            sw.Stop();

            return sw.ElapsedMilliseconds;
        }
        public ActionResult Harness1()
        {
            const int TaskCount = 400;
            const int MaxItems = 10000;
            const int GetCount = 15000;

            var cfg = new CacheConfig { AutoExpire = true, AutoRemoveDeadItems = true, Duration = 3, Name = "myConfig" };
            ICacheManager cm = new WebCacheManager(cfg);

            var t = Harness(cm, TaskCount, MaxItems, GetCount);
            
            return Content("<h1>Harness1</h1><br/><h2>Using WebCacheManager</h2><br/>Time taken: " + t);
        }
        public ActionResult Harness2()
        {
            const int TaskCount = 400;
            const int MaxItems = 10000;
            const int GetCount = 15000;

            var cfg = new CacheConfig { AutoExpire = true, AutoRemoveDeadItems = true, Duration = 3, Name = "myConfig" };
            ICacheManager cm = new HttpCacheManager(cfg);

            var t = Harness(cm, TaskCount, MaxItems, GetCount);

            return Content("<h1>Harness1</h1><br/><h2>Using HttpCacheManager</h2><br/>Time taken: " + t);
        }
    }
}