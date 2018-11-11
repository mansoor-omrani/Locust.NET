using Locust.Caching;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;
using ServiceSetting = Locust.Modules.Api.Model.ServiceSetting;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ServiceSettingGetAllByServiceStrategyBase : BabbageListFetcherStrategy<ServiceSettingGetAllByServiceResponse, ServiceSettingGetAllByServiceStatus, ServiceSettingGetAllByServiceRequest, ServiceSettingGetAllByServiceContext, ServiceSetting.Full>
    {
        protected ServiceSettingServiceBase Service
        {
            get { return Store.Service as ServiceSettingServiceBase; }
        }
        public ServiceSettingGetAllByServiceStrategyBase ()
		{
			Init();
		}

    }
}