using Locust.ServiceModel;
using System;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class ApiClientCustomerHubStrategyStore : BaseServiceStrategyStore
    {
		public ApiClientCustomerHubAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public ApiClientCustomerHubUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public ApiClientCustomerHubQuickUpdateStrategyBase QuickUpdate 
		{ 
			get { return _quickUpdateStrategy; }
		}

		public ApiClientCustomerHubDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public ApiClientCustomerHubGetByPKStrategyBase GetByPK 
		{ 
			get { return _getByPKStrategy; }
		}

		public ApiClientCustomerHubGetPageStrategyBase GetPage 
		{ 
			get { return _getPageStrategy; }
		}

		
		protected ApiClientCustomerHubAddStrategyBase _addStrategy;
		protected ApiClientCustomerHubUpdateStrategyBase _updateStrategy;
		protected ApiClientCustomerHubQuickUpdateStrategyBase _quickUpdateStrategy;
		protected ApiClientCustomerHubDeleteStrategyBase _deleteStrategy;
		protected ApiClientCustomerHubGetByPKStrategyBase _getByPKStrategy;
		protected ApiClientCustomerHubGetPageStrategyBase _getPageStrategy;
		
        public ApiClientCustomerHubStrategyStore(ApiClientCustomerHubAddStrategyBase addStrategy, ApiClientCustomerHubUpdateStrategyBase updateStrategy, ApiClientCustomerHubQuickUpdateStrategyBase quickUpdateStrategy, ApiClientCustomerHubDeleteStrategyBase deleteStrategy, ApiClientCustomerHubGetByPKStrategyBase getByPKStrategy, ApiClientCustomerHubGetPageStrategyBase getPageStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (quickUpdateStrategy == null)
				throw new ArgumentNullException("quickUpdateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (getByPKStrategy == null)
				throw new ArgumentNullException("getByPKStrategy");

			if (getPageStrategy == null)
				throw new ArgumentNullException("getPageStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_quickUpdateStrategy = quickUpdateStrategy;
			_deleteStrategy = deleteStrategy;
			_getByPKStrategy = getByPKStrategy;
			_getPageStrategy = getPageStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(quickUpdateStrategy);
			Register(deleteStrategy);
			Register(getByPKStrategy);
			Register(getPageStrategy);
			
			Init();
        }
    }
}