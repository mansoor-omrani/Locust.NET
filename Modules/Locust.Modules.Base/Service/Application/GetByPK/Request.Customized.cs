using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationGetByPKRequest : IBaseServiceRequest
    {
		public int Id { get; set; }
    }
}