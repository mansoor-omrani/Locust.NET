using Locust.ServiceModel;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginAddResponse : BaseServiceResponse<object, AppCrossOriginAddStatus>
    {
        public int Id { get; set; }
    }
}