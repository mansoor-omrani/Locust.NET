using Locust.ServiceModel;

namespace Locust.Modules.ACL.Service.Strategies
{
    public class RoleCategoryGetByIdRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
    }
}
