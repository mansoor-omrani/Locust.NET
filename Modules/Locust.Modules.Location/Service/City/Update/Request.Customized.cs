using System;
using System.Data;
using Locust.Data;
using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CityUpdateRequest : IBaseServiceRequest
    {
        public int CityId { get; set; }
        public int StateId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        
    }
}