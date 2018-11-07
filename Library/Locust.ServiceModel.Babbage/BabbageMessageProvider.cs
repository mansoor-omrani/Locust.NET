using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Locust.Caching;
using Locust.Tracing;
using Locust.Translation;

namespace Locust.ServiceModel.Babbage
{
    public class BabbageMessageProvider: MessageContentProvider
    {
        private ICacheManager cache;
        protected Dictionary<string, ServiceMessages> _store;
        public string CacheItemName { get; set; }

        private void init(ICacheManager cache)
        {
            this.cache = cache;
            _store = new Dictionary<string, ServiceMessages>();
            BasePath = AppDomain.CurrentDomain.BaseDirectory;
            CacheItemName = "__serviceMessages";

            if (cache != null)
            {
                try
                {
                    _store = cache.Get<Dictionary<string, ServiceMessages>>(CacheItemName);
                }
                catch
                {
                    _store = null;
                }
            }

            if (_store == null)
            {
                _store = new Dictionary<string, ServiceMessages>();
            }

            if (_store.Count == 0)
            {
                Load();
            }
        }

        public BabbageMessageProvider(ITranslator translator): base(translator)
        {
            var cacheConfig = new CacheConfig { Name = "appdomain.cache", Duration = 3600 };
            var cache = new AppDomainCacheManager(cacheConfig);

            init(cache);
        }
        public BabbageMessageProvider(ITranslator translator, ICacheManager cache) : base(translator)
        {
            init(cache);
        }
        public string BasePath { get; set; }
        public void Clear()
        {
            _store.Clear();
        }
        public override void Load(string relativePath = "/service")
        {
            Clear();

            if (Directory.Exists(BasePath + relativePath))
            {
                var files = Directory.GetFiles(BasePath + relativePath, "messages.json", SearchOption.AllDirectories);

                foreach (var file in files)
                {
                    var content = File.ReadAllText(file);
                    var sm = JsonConvert.DeserializeObject<ServiceMessages>(content);

                    _store.Add(sm.Service, sm);
                }

                if (cache != null)
                {
                    cache.Add(CacheItemName, _store);
                }
            }
        }

        public override string GetText(Message msg)
        {
            var result = "";
            var sm = _store.FirstOrDefault(m => string.Compare(m.Key , msg.Category, StringComparison.OrdinalIgnoreCase) == 0).Value;

            if (sm == null)
            {
                sm = _store.FirstOrDefault(m => string.Compare(m.Key, "root", StringComparison.OrdinalIgnoreCase) == 0).Value;
            }

            if (sm != null)
            {
                var msgs = sm.Strategies.FirstOrDefault(x => string.Compare(x.Strategy, msg.Operation, StringComparison.OrdinalIgnoreCase) == 0);

                if (msgs == null)
                {
                    sm = _store.FirstOrDefault(m => string.Compare(m.Key, "root", StringComparison.OrdinalIgnoreCase) == 0).Value;

                    if (sm != null)
                    {
                        msgs =
                            sm.Strategies.FirstOrDefault(
                                x => string.Compare(x.Strategy, "default", StringComparison.OrdinalIgnoreCase) == 0);
                    }
                }

                if (msgs != null && msg.ParamValueProvider != null && msg.ParamValueProvider.Lang != null && !string.IsNullOrEmpty(msg.Code))
                {
                    var _msgs = msgs.Messages.FirstOrDefault(x => string.Compare(x.Lang, msg.ParamValueProvider.Lang.ShortName, StringComparison.OrdinalIgnoreCase) == 0);
                    if (_msgs != null)
                    {
                        result = _msgs.Items.FirstOrDefault(x => string.Compare(x.Key, msg.Code, StringComparison.OrdinalIgnoreCase) == 0).Value;

                        if (string.IsNullOrEmpty(result) && sm.Service != "root")
                        {
                            sm = _store.FirstOrDefault(m => string.Compare(m.Key, "root", StringComparison.OrdinalIgnoreCase) == 0).Value;

                            if (sm != null)
                            {
                                msgs = sm.Strategies.FirstOrDefault(x => string.Compare(x.Strategy, "default", StringComparison.OrdinalIgnoreCase) == 0);

                                if (msgs != null)
                                {
                                    _msgs = msgs.Messages.FirstOrDefault(x => string.Compare(x.Lang, msg.ParamValueProvider.Lang.ShortName, StringComparison.OrdinalIgnoreCase) == 0);
                                    if (_msgs != null)
                                    {
                                        result =
                                            _msgs.Items.FirstOrDefault(
                                                x =>
                                                    string.Compare(x.Key, msg.Code, StringComparison.OrdinalIgnoreCase) ==
                                                    0).Value;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }
    }
}
