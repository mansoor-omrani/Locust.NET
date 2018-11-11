using System.Collections.Generic;
using Locust.ServiceModel;
using Application = Locust.Modules.Base.Model.Application;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetAllResponse : BaseServiceListResponse<Application.AdminGrid, ApplicationGetAllStatus>
    {
    }
}