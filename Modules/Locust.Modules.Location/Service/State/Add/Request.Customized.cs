using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateAddRequest : IBaseServiceRequest
    {
        public CommandParameter StateId { get; set; }
        public Int32 CountryId { get; set; }
        public Int32 OldId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

	    public StateAddRequest()
	    {
	        StateId = CommandParameter.Output(SqlDbType.Int);
	    }
    }
}