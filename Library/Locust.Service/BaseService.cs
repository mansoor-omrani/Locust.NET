using Locust.Base;
using Locust.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Service
{
    public interface IService<TConfig>
        where TConfig : class, new()
    {
        string Name { get; }
        TConfig Config { get; }
        object GetAction(string name);
        object this[string action] { get; }
    }
    public abstract class BaseActionBasedService<TConfig> : IService<TConfig>
        where TConfig : class, new()
    {
        private string name;
        public virtual string Name
        {
            get
            {
                if (string.IsNullOrEmpty(name))
                    name = this.GetType().Name;

                return name;
            }
        }
        private TConfig _config;
        public TConfig Config
        {
            get
            {
                return TypeHelper.EnsureInitialized<TConfig, TConfig>(ref _config);
            }
            set { _config = value; }
        }
        public virtual object GetAction(string name)
        {
            return Actions[name];
        }
        public IDictionary<string, object> Actions { get; private set; }
        public BaseActionBasedService() : this(null)
        { }
        public BaseActionBasedService(TConfig config)
        {
            Config = config;
            Actions = new CaseSensitiveDictionary<object>(true);
        }
        public object this[string action]
        {
            get
            {
                return Actions[action];
            }
        }
    }
}
