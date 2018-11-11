using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationDeleteResponse : BaseServiceResponse<object, ApplicationDeleteStatus>
    {
        public string ShortName { get; set; }
    }
}