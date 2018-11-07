using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.ServiceModel
{
    public class BaseServiceStrategyStore
    {
        private Dictionary<Type, Type> context_to_strategy;
        private Dictionary<Type, IBaseServiceStrategy> strategy_store;
        public BaseServiceStrategyStore()
        {
            context_to_strategy = new Dictionary<Type, Type>();
            strategy_store = new Dictionary<Type, IBaseServiceStrategy>();
        }
        private BaseService service;
        public BaseService Service
        {
            get { return service; }
            set
            {
                if (service == null)
                {
                    service = value;
                }
            }
        }

        public IEnumerable<Type> GetAllStrategyTypes()
        {
            return context_to_strategy.Select(item => item.Value);
        }
        public IEnumerable<IBaseServiceStrategy> GetAllStrategies()
        {
            return strategy_store.Select(item => item.Value).ToList();
        }
        protected void Register<TResponse, UStatus, VData, WRequest, TContext>(BaseServiceStrategy<TResponse, UStatus, VData, WRequest, TContext> strategy)
            where TResponse : BaseServiceResponse<UStatus, VData>, new()
            where WRequest : class, IBaseServiceRequest, new()
            where TContext : ServiceStrategyContext<TResponse, UStatus, VData, WRequest>, new()
        {
            if (strategy == null)
                throw new ArgumentNullException("strategy");

            var type = strategy.GetType();

            context_to_strategy.Add(typeof(TContext), type);
            strategy_store.Add(type, strategy);

            strategy.Store = this;
        }
        public IBaseServiceStrategy GetStrategy<TContext>()
        {
            return GetStrategy(typeof(TContext));
        }
        public IBaseServiceStrategy GetStrategy(Type contextType)
        {
            if (context_to_strategy.ContainsKey(contextType))
            {
                var strategyType = context_to_strategy[contextType];
                var strategy = strategy_store[strategyType];

                return strategy;
            }
            else
            {
                return null;
            }
        }
    }
}
