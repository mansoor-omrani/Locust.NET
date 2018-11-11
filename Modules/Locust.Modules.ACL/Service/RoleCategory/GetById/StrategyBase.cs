using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Locust.Caching;
using Locust.Modules.ACL.Service.Strategies;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.ACL.Strategies
{
    public abstract partial class RoleCategoryGetByIdStrategyBase : BabbageItemFetcherStrategy<RoleCategoryGetByIdResponse, Model.RoleCategory, RoleCategoryGetByIdStatus, RoleCategoryGetByIdRequest, RoleCategoryGetByIdContext>
    {
        protected ICacheFactory cacheFactory;

        public RoleCategoryGetByIdStrategyBase(ICacheFactory cacheFactory)
        {
            if (cacheFactory == null)
                throw new ArgumentNullException("cacheFactory");
            this.cacheFactory = cacheFactory;
			
			Init();
        }
    }
}
