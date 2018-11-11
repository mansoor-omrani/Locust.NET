using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginUpdateResponse : BaseServiceResponse<object, AppCrossOriginUpdateStatus>
    {
        public int AppId { get; set; }
    }
}