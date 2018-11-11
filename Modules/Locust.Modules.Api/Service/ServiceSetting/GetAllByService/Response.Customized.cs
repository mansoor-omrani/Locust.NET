using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ServiceSetting = Locust.Modules.Api.Model.ServiceSetting;

namespace Locust.Modules.Api.Strategies
{
	public partial class ServiceSettingGetAllByServiceResponse : BaseServiceListResponse<ServiceSetting.Full, ServiceSettingGetAllByServiceStatus>
    {
    }
}