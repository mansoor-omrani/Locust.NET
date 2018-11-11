using System;
using Locust.Conversion;
using Locust.Data;
using Locust.Db;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiClientCustomerGetByTokenRequest : BabbageRequest
    {
        public string AccessToken { get; set; }

     //   public ApiClientCustomerGetByTokenRequest()
	    //{
     //       AccessToken = new GuidCommandParameter("");
	    //}
     //   public override bool GetValue(string propertyName, out object value)
     //   {
     //       value = null;

     //       if (string.Compare(propertyName, "AccessToken", StringComparison.OrdinalIgnoreCase) == 0)
     //       {
     //           AccessToken = SafeClrConvert.ToString(value);
     //           cmdAccessToken.Value = AccessToken;

     //           return true;
     //       }

     //       return false;
     //   }
    }
}