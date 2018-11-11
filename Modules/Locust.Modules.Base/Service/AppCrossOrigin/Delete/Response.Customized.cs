using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginDeleteResponse : BaseServiceResponse<object, AppCrossOriginDeleteStatus>
    {
        public int AppId { get; set; }
    }
}