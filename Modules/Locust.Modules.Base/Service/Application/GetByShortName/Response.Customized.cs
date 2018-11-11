using Application = Locust.Modules.Base.Model.Application;
using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
    public partial class ApplicationGetByShortNameResponse : BaseServiceResponse<Application.AdminGrid, ApplicationGetByShortNameStatus>
    {
    }
}