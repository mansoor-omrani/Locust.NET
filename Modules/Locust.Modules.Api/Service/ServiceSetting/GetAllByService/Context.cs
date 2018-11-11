using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;
using ServiceSetting = Locust.Modules.Api.Model.ServiceSetting;

namespace Locust.Modules.Api.Strategies
{
	public class ServiceSettingGetAllByServiceContext : BabbageContext<ServiceSettingGetAllByServiceResponse, IList<ServiceSetting.Full>, ServiceSettingGetAllByServiceStatus, ServiceSettingGetAllByServiceRequest>
    {
    }
}