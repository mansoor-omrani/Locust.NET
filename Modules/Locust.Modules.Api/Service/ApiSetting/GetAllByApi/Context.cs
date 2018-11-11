using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using Locust.ServiceModel.Babbage;
using ApiSetting = Locust.Modules.Api.Model.ApiSetting;

namespace Locust.Modules.Api.Strategies
{
	public class ApiSettingGetAllByApiContext : BabbageContext<ApiSettingGetAllByApiResponse, IList<ApiSetting.Full>, ApiSettingGetAllByApiStatus, ApiSettingGetAllByApiRequest>
    {
    }
}