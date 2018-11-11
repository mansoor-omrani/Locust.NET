using System.Collections.Generic;
using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiClientCustomerServiceBase : ApiBaseService
	{
        // GetByPK
        public string CacheKeySpecifier(ApiClientCustomerGetByPKContext context)
        {
            return UseCache? context.Request.Id.ToString():"";
        }
        public int CacheLifeSpecifier(ApiClientCustomerGetByPKContext context)
        {
            return UseCache ? context.Response.Data.RemainingLife * 60 - 5:0;
        }
        // GetByPK
        public string CacheKeySpecifier(ApiClientCustomerGetByTokenContext context)
        {
            return UseCache ? context.Request.AccessToken:"";
        }
        public int CacheLifeSpecifier(ApiClientCustomerGetByTokenContext context)
        {
            return UseCache ? context.Response.Data.RemainingLife * 60 - 5:0;
        }
        public void CacheRemove(ApiClientCustomerActivateContext context)
        {
            if (UseCache)
            {
                Cache.Remove(context.Request.ApiClientCustomerId.ToString());
                Cache.Remove(context.Response.OldAccessToken);
            }
        }
        public void CacheRemove(ApiClientCustomerDeleteContext context)
        {
            if (UseCache && context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
                Cache.Remove(context.Response.AccessToken);
            }
        }
        public void CacheRemove(ApiClientCustomerRefreshContext context)
        {
            if (context.Response.Success && UseCache)
            {
                Cache.Remove(context.Request.CallContext.Customer.ApiClientCustomerId.Value.ToString());
                Cache.Remove(context.Request.CallContext.Customer.AccessToken.Value.ToString());
            }
        }
        public void CacheRemove(ApiClientCustomerSetActivatedContext context)
        {
            if (context.Response.Success && UseCache)
            {
                Cache.Remove(context.Response.AccessToken);
                Cache.Remove(context.Request.Id.ToString());
            }
        }
        public void CacheRemove(ApiClientCustomerSetDisabledContext context)
        {
            if (context.Response.Success && UseCache)
            {
                Cache.Remove(context.Response.AccessToken);
                Cache.Remove(context.Request.Id.ToString());
            }
        }
        public void CacheRemove(ApiClientCustomerUnlockContext context)
        {
            if (context.Response.Success && UseCache)
            {
                Cache.Remove(context.Response.AccessToken);
                Cache.Remove(context.Request.Id.ToString());
            }
        }
        public void CacheRemove(ApiClientCustomerUpdateContext context)
        {
            if (context.Response.Success && UseCache)
            {
                Cache.Remove(context.Request.Id.ToString());
                Cache.Remove(context.Response.OiriginalAccessToken);
            }
        }

        protected void Init()
		{
            Cache = CacheFactory.Get(CacheName.ApiClientCustomer);
        }
    }
}