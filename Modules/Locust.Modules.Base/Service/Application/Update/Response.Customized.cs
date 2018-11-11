using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationUpdateResponse : BaseServiceResponse<object, ApplicationUpdateStatus>
    {
        public string OldShortName { get; set; }
    }
}