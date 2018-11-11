using Application = Locust.Modules.Base.Model.Application;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Base.Strategies
{
    public class ApplicationGetByShortNameContext : BabbageContext<ApplicationGetByShortNameResponse, Application.AdminGrid, ApplicationGetByShortNameStatus, ApplicationGetByShortNameRequest>
    {
    }
}