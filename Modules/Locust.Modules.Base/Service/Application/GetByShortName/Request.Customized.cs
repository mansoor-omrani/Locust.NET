using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetByShortNameRequest : IBaseServiceRequest
    {
        public string ShortName { get; set; }
    }
}