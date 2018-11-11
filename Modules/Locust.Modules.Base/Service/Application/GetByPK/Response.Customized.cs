using Locust.ServiceModel;
using Application = Locust.Modules.Base.Model.Application;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetByPKResponse : BaseServiceResponse<Application.Full, ApplicationGetByPKStatus>
    {
    }
}