using Locust.Modules.ACL.Strategies;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.ACL.Service.Strategies
{
    public class RoleCategoryGetByIdContext : BabbageContext<RoleCategoryGetByIdResponse, Model.RoleCategory, RoleCategoryGetByIdStatus, RoleCategoryGetByIdRequest>
    {
    }
}
