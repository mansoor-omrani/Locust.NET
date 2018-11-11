using Locust.Caching;
using Locust.Collections;
using Locust.Extensions;
using Locust.Logging;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Translation
{
    public abstract class BaseTranslator : ITranslator
    {
        public string CultureDependentTextExtension { get; set; }
        public string CultureIndependentTextExtension { get; set; }
        protected Dictionary<string, string[]> _store;
        protected Dictionary<string, string[]> _storenames;
        private Dictionary<string, string[]> Store
        {
            get
            {
                if (_store.Count == 0)
                {
                    Load();
                }

                return _store;
            }
        }
        protected ICacheManager cache;
        protected bool loaded;
        protected IExceptionLogger exceptionLogger;
        protected ILogger logger;
        private string cacheItemName;
        public virtual string CacheItemName
        {
            get { return cacheItemName; }
            set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("CacheItemName");
                }

                Clear();

                cacheItemName = value;

                Load();
            }
        }
        public ICacheManager Cache { get { return cache; } }
        public IExceptionLogger ExceptionLogger { get { return exceptionLogger; } }
        public ILogger Logger { get { return logger; } }
        protected virtual void Init(ICacheManager cache, IExceptionLogger exceptionLogger, ILogger logger) { }
        private void InitInternal(ICacheManager cache, IExceptionLogger exceptionLogger, ILogger logger)
        {
            this.cache = cache;
            this.exceptionLogger = exceptionLogger;
            this.logger = logger;

            CultureDependentTextExtension = ".cdt";
            CultureIndependentTextExtension = ".cit";
            
            Logger.LogCategory($"{this.GetType().Name}.init()");
            Logger.Log($"Cache: {cache?.GetType().Name}");
            Logger.Log($"ExceptionLogger: {exceptionLogger?.GetType().Name}");
            Logger.Log($"Logger: {logger?.GetType().Name}");

            
            cacheItemName = "__translator";

            if (cache != null)
            {
                try
                {
                    Logger.Log($"Restoring items from cache");

                    _store = cache.Get<Dictionary<string, string[]>>(CacheItemName);
                    _storenames = cache.Get<Dictionary<string, string[]>>(CacheItemName + ".names");
                }
                catch (Exception e)
                {
                    Logger.Log($"Restore failed.");

                    exceptionLogger.LogException(e, $"{this.GetType().Name}.init()");

                    _store = null;
                    _storenames = null;
                }
            }

            if (_store == null)
            {
                _store = new Dictionary<string, string[]>(StringComparer.CurrentCultureIgnoreCase);
                _storenames = new Dictionary<string, string[]>(StringComparer.CurrentCultureIgnoreCase);
            }

            Init(cache, exceptionLogger, logger);
        }
        public BaseTranslator()
        {
            var cacheConfig = new CacheConfig { Name = "appdomain.cache", Duration = 3600 };
            var cache = new AppDomainCacheManager(cacheConfig);

            InitInternal(cache, new NullExceptionLogger(), new NullLogger());
        }
        public BaseTranslator(ICacheManager cache, IExceptionLogger exceptionLogger, ILogger logger)
        {
            InitInternal(cache, exceptionLogger, logger);
        }
        public void Clear()
        {
            _store.Clear();
            loaded = false;
        }
        public Dictionary<string, string[]> GetAll(string storename = "")
        {
            if (string.IsNullOrEmpty(storename))
            {
                return _store;
            }
            else
            {
                var result = new Dictionary<string, string[]>();
                var _storename_keys = _storenames.FirstOrDefault(name => string.Compare(name.Key, storename, true) == 0).Value;

                if (_storename_keys != null && _storename_keys.Length > 0)
                {
                    foreach (var item in _store)
                    {
                        if (_storename_keys.FindIndexOf(item.Key, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            result.Add(item.Key, item.Value);
                        }
                    }
                }

                return result;
            }
        }
        protected abstract void LoadInternal();
        public void Load()
        {
            Logger.LogCategory($"{this.GetType().Name}.Load()");

            if (!loaded)
            {
                Clear();

                try
                {
                    LoadInternal();

                    Logger.Log($"Updating linked texts ...");

                    UpdateLinkedTexts();

                    Logger.Log($"Caching ...");

                    if (cache != null)
                    {
                        if (!cache.Contains(CacheItemName))
                        {
                            cache.Add(CacheItemName, _store);
                        }
                        else
                        {
                            Logger.Log($"cache {CacheItemName} already exists.");

                            cache.GetOrSet(CacheItemName, () => _store);
                        }

                        Logger.Log($"succeeded.");
                    }
                    else
                    {
                        Logger.Log($"No cache found.");
                    }

                    loaded = true;
                }
                catch (Exception e)
                {
                    Logger.Log($"load exception:\n{e.ToString("\n")}");

                    exceptionLogger.LogException(e, $"{this.GetType().Name}.Load()");
                }
            }
            else
            {
                Logger.Log($"Already loaded");
            }
        }
        internal static string[] GetValues(string values)
        {
            var result = new List<string>();
            var _values = values?.Trim();

            if (!string.IsNullOrEmpty(_values))
            {
                var buffer = new CharBuffer(32);
                var i = 0;
                var state = 0;

                while (i < _values.Length)
                {
                    var ch = _values[i++];

                    switch (state)
                    {
                        case 0:
                            switch (ch)
                            {
                                case '\\':
                                    state = 1;
                                    break;
                                case ',':
                                    var value = buffer.ToString();
                                    if (!string.IsNullOrEmpty(value))
                                    {
                                        result.Add(value);
                                    }
                                    buffer.Reset();
                                    break;
                                default:
                                    buffer.Append(ch);
                                    break;
                            }

                            break;
                        case 1:
                            switch (ch)
                            {
                                case ',':
                                    buffer.Append(',');
                                    break;
                                case 'n':
                                    buffer.Append('\n');
                                    break;
                                case 'r':
                                    buffer.Append('\r');
                                    break;
                                case 'f':
                                    buffer.Append('\f');
                                    break;
                                case 'b':
                                    buffer.Append('\b');
                                    break;
                                case 'v':
                                    buffer.Append('\v');
                                    break;
                                case '\\':
                                    buffer.Append('\\');
                                    break;
                                default:
                                    buffer.Append('\\');
                                    buffer.Append(ch);
                                    break;
                            }
                            
                            state = 0;

                            break;
                    }
                }

                if (buffer.Length > 0)
                {
                    var value = buffer.ToString();

                    if (!string.IsNullOrEmpty(value))
                    {
                        result.Add(value);
                    }
                }
            }

            return result.ToArray();
        }
        public string[] Get(string key)
        {
            string[] result = new string[] { };

            if (!string.IsNullOrEmpty(key))
            {
                Store.TryGetValue(key.ToLower(), out result);
            }

            return result;
        }
        public string[] Get(string key, object globalValue, object culture, object lang)
        {
            var _key = "/" + key + "/" + globalValue + "/" + culture + "/" + lang;

            return Get(_key.ToLower());
        }
        public string[] Get(string key, string value, string lang)
        {
            var _key = "/" + key + "/" + value + "/" + lang;

            return Get(_key.ToLower());
        }
        public string GetSingle(string key)
        {
            var result = null as string;
            var values = Get(key);

            if (values != null && values.Length > 0)
                result = values[0];

            return result;
        }
        public string GetSingle(string key, object globalValue, object culture, object lang)
        {
            var _key = "/" + key + "/" + globalValue + "/" + culture + "/" + lang;

            return GetSingle(_key.ToLower());
        }
        public string GetSingle(string key, string value, string lang)
        {
            var _key = "/" + key + "/" + value + "/" + lang;

            return GetSingle(_key.ToLower());
        }
        protected virtual void ProcessCultureDependentText(string storename, string content)
        {
            var lines = content.Split('\n', MyStringSplitOptions.TrimAndRemoveEmptyEntries);
            var keys = new List<string>();
            var itemCount = 0;
            var skippedItemsCount = 0;
            var commentCount = 0;

            Logger.Log($"total lines: {lines.Length}");
            
            foreach (var l in lines)
            {
                var line = l.Trim();

                if (line.Length > 0)
                {
                    if (line[0] != '#')
                    {
                        var colonIndex = line.IndexOf(':');

                        if (colonIndex > 1 && colonIndex < line.Length)
                        {
                            var left = line.Substring(0, colonIndex).Trim();
                            var right = line.Substring(colonIndex + 1).Trim();
                            var path = left.Split('/', MyStringSplitOptions.TrimToLowerAndRemoveEmptyEntries);
                            var values = GetValues(right);

                            if (path.Length == 4)
                            {
                                var key = "/" + String.Join("/", path);
                                
                                if (!_store.ContainsKey(key))
                                {
                                    itemCount++;
                                    _store.Add(key, values);

                                    if (!string.IsNullOrEmpty(storename))
                                    {
                                        keys.Add(key);
                                    }
                                }
                                else
                                {
                                    skippedItemsCount++;
                                    Logger.Log($"Key already exists: {key}");
                                }
                            }
                        }
                    }
                    else
                    {
                        commentCount++;
                    }
                }
            }

            Logger.Log($"comment lines: {commentCount}, item lines: {itemCount}, skipped items: {skippedItemsCount}");

            if (!string.IsNullOrEmpty(storename))
            {
                if (!_storenames.ContainsKey(storename))
                {
                    _storenames.Add(storename, keys.ToArray());
                }
                else
                {
                    Logger.Log($"storename already exists: {storename}");
                }
            }
        }
        protected virtual void ProcessCultureIndependentText(string storename, string content)
        {
            var lines = content.Split('\n', MyStringSplitOptions.TrimAndRemoveEmptyEntries);
            var keys = new List<string>();
            var itemCount = 0;
            var skippedItemsCount = 0;
            var commentCount = 0;

            Logger.Log($"total lines: {lines.Length}");

            foreach (var l in lines)
            {
                var line = l.Trim();

                if (line.Length > 0)
                {
                    if (line[0] != '#')
                    {
                        var colonIndex = line.IndexOf(':');

                        if (colonIndex > 1 && colonIndex < line.Length)
                        {
                            var left = line.Substring(0, colonIndex).Trim();
                            var right = line.Substring(colonIndex + 1).Trim();
                            var path = left.Split('/', MyStringSplitOptions.TrimToLowerAndRemoveEmptyEntries);
                            var values = GetValues(right);

                            if (path.Length == 3)
                            {
                                var key = "/" + String.Join("/", path);

                                if (!_store.ContainsKey(key))
                                {
                                    itemCount++;
                                    _store.Add(key, values);

                                    if (!string.IsNullOrEmpty(storename))
                                    {
                                        keys.Add(key);
                                    }
                                }
                                else
                                {
                                    skippedItemsCount++;
                                    Logger.Log($"Key already exists: {key}");
                                }
                            }
                        }
                    }
                    else
                    {
                        commentCount++;
                    }
                }
            }

            Logger.Log($"comment lines: {commentCount}, item lines: {itemCount}, skipped items: {skippedItemsCount}");

            if (!string.IsNullOrEmpty(storename))
            {
                if (!_storenames.ContainsKey(storename))
                {
                    _storenames.Add(storename, keys.ToArray());
                }
                else
                {
                    Logger.Log($"storename already exists: {storename}");
                }
            }
        }
        private string CheckValue(string value)
        {
            var result = value;

            if (!string.IsNullOrEmpty(value) && value.Length > 2)
            {
                var temp = "";
                var sb = new StringBuilder();
                var link = "";
                var state = 0;

                foreach (var ch in value)
                {
                    switch (state)
                    {
                        case 0:
                            if (ch == '\\')
                            {
                                if (!string.IsNullOrEmpty(temp))
                                {
                                    sb.Append(temp);
                                }
                                temp = "";
                                state = 1;
                            }
                            else
                            if (ch == '{')
                            {
                                if (!string.IsNullOrEmpty(temp))
                                {
                                    sb.Append(temp);
                                }
                                temp = "";
                                state = 2;
                            }
                            else
                            {
                                temp += ch;
                            }

                            break;
                        case 1:
                            if (ch == '{')
                            {
                                sb.Append('{');
                            }
                            else
                            {
                                sb.Append('\\' + ch);
                            }
                            state = 0;
                            break;
                        case 2:
                            if (ch == '}')
                            {
                                temp = GetSingle(link);

                                if (!string.IsNullOrEmpty(temp))
                                {
                                    sb.Append(temp);
                                }
                                else
                                {
                                    sb.Append("{" + link + "}");
                                }

                                link = "";
                                temp = "";
                                state = 0;
                            }
                            else
                            {
                                link += ch;
                            }
                            break;
                    }
                }

                if (!string.IsNullOrEmpty(temp))
                {
                    sb.Append(temp);
                }

                result = sb.ToString();
            }

            return result;
        }
        protected virtual void UpdateLinkedTexts()
        {
            foreach (var item in Store)
            {
                var values = item.Value;
                if (values != null && values.Length > 0)
                {
                    for (var i = 0; i < values.Length; i++)
                    {
                        var value = values[i]?.Trim();

                        values[i] = CheckValue(value);
                    }
                }
            }
        }
    }
}
