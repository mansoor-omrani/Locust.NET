using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using ServiceSetting = Locust.Modules.Api.Model.ServiceSetting;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ServiceSettingGetAllByServiceStrategyBase : BabbageListFetcherStrategy<ServiceSettingGetAllByServiceResponse, ServiceSettingGetAllByServiceStatus, ServiceSettingGetAllByServiceRequest, ServiceSettingGetAllByServiceContext, ServiceSetting.Full>
    {
		protected void Init()
		{
		}

    }
}