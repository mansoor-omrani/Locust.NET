using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiServiceBase : ApiBaseService
    {
        // GetByPK
        public string CacheKeySpecifier(ApiGetByPKContext context)
        {
            return UseCache ? context.Request.Id.ToString() : "";
        }
        public string CacheKeySpecifier(ApiGetByPathContext context)
        {
            return UseCache ? context.Request.AppId.ToString() + "." + context.Request.Path : "";
        }
        public void CacheRemove(ApiUpdateContext context)
        {
            if (UseCache && context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
                Cache.Remove(context.Response.AppId.ToString() + "." + context.Response.OldPath);
            }
        }
        public void CacheRemove(ApiDeleteContext context)
        {
            if (UseCache && context.Response.Success)
            {
                Cache.Remove(context.Request.Id.ToString());
                Cache.Remove(context.Response.AppId.ToString() + "." + context.Response.Path);
            }
        }
        protected void Init()
        {
            Cache = CacheFactory.Get(CacheName.Api);
        }
    }
}