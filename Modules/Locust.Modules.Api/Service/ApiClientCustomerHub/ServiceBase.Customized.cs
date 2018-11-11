using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiClientCustomerHubServiceBase : ApiBaseService
    {
        public bool IsValidHub(int apiClientCustomerHubId, object req)
        {
            return UseCache && Cache.Contains(apiClientCustomerHubId.ToString()) && IsValidRequest(req);
        }
        // GetByPK
        public string CacheKeySpecifier(ApiClientCustomerHubGetByPKContext context)
        {
            return UseCache ? context.Request.Id.ToString() : "";
        }
        public void CacheRemove(ApiClientCustomerHubDeleteContext context)
        {
            if (UseCache && context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
                InvalidateRequests();
            }
        }
        public void CacheRemove(ApiClientCustomerHubUpdateContext context)
        {
            if (UseCache && context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
                InvalidateRequests();
            }
        }
        public void CacheRemove(ApiClientCustomerHubQuickUpdateContext context)
        {
            if (UseCache && context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
                InvalidateRequests();
            }
        }
        protected void Init()
		{
		    Cache = CacheFactory.Get(CacheName.ApiClientCustomerHub);
		}
    }
}