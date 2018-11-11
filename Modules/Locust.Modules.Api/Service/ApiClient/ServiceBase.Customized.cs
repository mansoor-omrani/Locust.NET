using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiClientServiceBase : ApiBaseService
    {
        public bool IsValidClient(int apiClientId, object req)
        {
            return UseCache && Cache.Contains(apiClientId.ToString()) && IsValidRequest(req);
        }
        public string CacheKeySpecifier(ApiClientGetByPKContext context)
        {
            return UseCache? context.Request.Id.ToString():"";
        }
        public string CacheKeySpecifier(ApiClientGetByKeyContext context)
        {
            return UseCache ? context.Request.ClientKey.ToString():"";
        }
        public void CacheRemove(ApiClientUpdateContext context)
        {
            if (UseCache && context.Response.Success && context.Response.Status != ApiClientUpdateStatus.NotFound)
            {
                if (!string.IsNullOrEmpty(context.Response.OldClientKey))
                {
                    Cache.Remove(context.Request.Id.ToString());
                    Cache.Remove(context.Response.OldClientKey);
                    InvalidateRequests();
                }
            }
        }
        public void CacheRemove(ApiClientDeleteByPKContext context)
        {
            if (UseCache && context.Response.Success && context.Response.Status != ApiClientDeleteByPKStatus.NotFound)
            {
                Cache.Remove(context.Request.Id.ToString());
                Cache.Remove(context.Response.ClientKey);
                InvalidateRequests();
            }
        }
        public void CacheRemove(ApiClientDeleteByKeyContext context)
        {
            if (UseCache && context.Response.Success && context.Response.Status != ApiClientDeleteByKeyStatus.NotFound)
            {
                Cache.Remove(context.Request.ClientKey);
                Cache.Remove(context.Response.Id.ToString());
                InvalidateRequests();
            }
        }
        public void CacheRemove(ApiClientRemoveByPKContext context)
        {
            if (UseCache && context.Response.Success && context.Response.Status != ApiClientRemoveByPKStatus.NotFound)
            {
                Cache.Remove(context.Response.ClientKey);
                Cache.Remove(context.Request.Id.ToString());
                InvalidateRequests();
            }
        }
        public void CacheRemove(ApiClientRemoveByKeyContext context)
        {
            if (UseCache && context.Response.Success && context.Response.Status != ApiClientRemoveByKeyStatus.NotFound)
            {
                Cache.Remove(context.Request.ClientKey);
                Cache.Remove(context.Response.Id.ToString());
                InvalidateRequests();
            }
        }
        protected void Init()
		{
		    Cache = CacheFactory.Get(CacheName.ApiClient);
		}
    }
}