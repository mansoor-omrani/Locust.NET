using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Application = Locust.Modules.Base.Model.Application;

namespace Locust.Modules.Base.Strategies
{
	public class ApplicationGetByPKContext : BabbageContext<ApplicationGetByPKResponse, Application.Full, ApplicationGetByPKStatus, ApplicationGetByPKRequest>
    {
    }
}