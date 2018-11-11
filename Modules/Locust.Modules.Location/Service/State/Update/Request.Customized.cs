using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateUpdateRequest : IBaseServiceRequest
    {
        public int StateId { get; set; }
        public Int32 CountryId { get; set; }
        public Int32 OldId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

    }
}