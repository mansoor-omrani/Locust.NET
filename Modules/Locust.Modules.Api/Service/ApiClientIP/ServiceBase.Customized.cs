using Locust.Logging;
using Locust.ServiceModel;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public abstract partial class ApiClientIPServiceBase : ApiBaseService
    {
		
		protected void Init()
		{
		    Cache = CacheFactory.Get(CacheName.ApiClientIP);
		}
    }
}