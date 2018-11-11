using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Application = Locust.Modules.Base.Model.Application;

namespace Locust.Modules.Base.Strategies
{
	public class ApplicationGetAllContext : BabbageContext<ApplicationGetAllResponse, IList<Application.AdminGrid>, ApplicationGetAllStatus, ApplicationGetAllRequest>
    {
    }
}