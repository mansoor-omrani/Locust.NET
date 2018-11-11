using Locust.ServiceModel;
namespace Locust.Modules.Base.Strategies
{
	public partial class ApplicationAddResponse : BaseServiceResponse<object, ApplicationAddStatus>
    {
        public int Id { get; set; }
    }
}