using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginGetAllRequest : IBaseServiceRequest
    {
        public int AppId { get; set; }
    }
}