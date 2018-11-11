using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using AppCrossOrigin = Locust.Modules.Base.Model.AppCrossOrigin.AdminGrid;

namespace Locust.Modules.Base.Strategies
{
	public class AppCrossOriginGetAllContext : BabbageContext<AppCrossOriginGetAllResponse, IList<AppCrossOrigin>, AppCrossOriginGetAllStatus, AppCrossOriginGetAllRequest>
    {
    }
}