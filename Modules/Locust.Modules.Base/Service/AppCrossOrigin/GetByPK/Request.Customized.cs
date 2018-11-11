using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginGetByPKRequest : IBaseServiceRequest
    {
        public int Id { get; set; }
    }
}