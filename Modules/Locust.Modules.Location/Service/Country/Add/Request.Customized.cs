using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CountryAddRequest : IBaseServiceRequest
    {
        public CommandParameter CountryId { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }

        public CountryAddRequest()
        {
            CountryId = CommandParameter.Output(SqlDbType.Int);
        }

    }
}