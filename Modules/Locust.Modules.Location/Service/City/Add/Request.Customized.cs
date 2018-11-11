using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CityAddRequest : IBaseServiceRequest
    {
        public CommandParameter CityId { get; set; }
        public Int32 StateId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public CityAddRequest()
        {
            CityId = CommandParameter.Output(SqlDbType.Int);
        }
    }
}