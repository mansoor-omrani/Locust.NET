using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using AppCrossOrigin = Locust.Modules.Base.Model.AppCrossOrigin.Full;

namespace Locust.Modules.Base.Strategies
{
	public class AppCrossOriginGetByPKContext : BabbageContext<AppCrossOriginGetByPKResponse, AppCrossOrigin, AppCrossOriginGetByPKStatus, AppCrossOriginGetByPKRequest>
    {
    }
}