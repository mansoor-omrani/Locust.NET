using System;
using Locust.Caching;
using Locust.Mailing;
using Locust.ServiceModel;
using Locust.ServiceModel.Babbage;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Service;
using Locust.Notification;
using Locust.SMS;

namespace Locust.Modules.Api.Strategies
{
	public abstract partial class ApiClientCustomerRegisterStrategyBase : BabbageDataManipulationStrategy<ApiClientCustomerRegisterResponse, object, ApiClientCustomerRegisterStatus, ApiClientCustomerRegisterRequest, ApiClientCustomerRegisterContext>
    {
        protected INotificationService _notification;
        public ApiClientCustomerRegisterStrategyBase (INotificationService notification)
		{
            if (notification == null)
                throw new ArgumentNullException("notification");

            _notification = notification;
			
			Init();
		}

    }
}