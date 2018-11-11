using System;
using Locust.ServiceModel;

namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetByCodeRequest : IBaseServiceRequest
    {
        public string code { get; set; }
    }
}