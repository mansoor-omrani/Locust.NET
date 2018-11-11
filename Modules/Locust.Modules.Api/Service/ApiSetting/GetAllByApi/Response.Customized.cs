using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Api.Model;
using ApiSetting = Locust.Modules.Api.Model.ApiSetting;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiSettingGetAllByApiResponse : BaseServiceListResponse<ApiSetting.Full, ApiSettingGetAllByApiStatus>
    {
    }
}