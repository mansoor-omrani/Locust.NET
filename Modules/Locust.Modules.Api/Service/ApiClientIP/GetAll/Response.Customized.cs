using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using ApiClientIP = Locust.Modules.Api.Model.ApiClientIP;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientIPGetAllResponse : BaseServiceListResponse<ApiClientIP.AdminGrid, ApiClientIPGetAllStatus>
    {
    }
}