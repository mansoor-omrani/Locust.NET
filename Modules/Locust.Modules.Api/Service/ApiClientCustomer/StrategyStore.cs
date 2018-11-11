using Locust.ServiceModel;
using System;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class ApiClientCustomerStrategyStore : BaseServiceStrategyStore
    {
		public ApiClientCustomerAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public ApiClientCustomerUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public ApiClientCustomerDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public ApiClientCustomerSetActivatedStrategyBase SetActivated 
		{ 
			get { return _setActivatedStrategy; }
		}

		public ApiClientCustomerSetDisabledStrategyBase SetDisabled 
		{ 
			get { return _setDisabledStrategy; }
		}

		public ApiClientCustomerUnlockStrategyBase Unlock 
		{ 
			get { return _unlockStrategy; }
		}

		public ApiClientCustomerGetByPKStrategyBase GetByPK 
		{ 
			get { return _getByPKStrategy; }
		}

		public ApiClientCustomerGetByTokenStrategyBase GetByToken 
		{ 
			get { return _getByTokenStrategy; }
		}

		public ApiClientCustomerCheckStrategyBase Check 
		{ 
			get { return _checkStrategy; }
		}

		public ApiClientCustomerActivateStrategyBase Activate 
		{ 
			get { return _activateStrategy; }
		}

		public ApiClientCustomerRefreshStrategyBase Refresh 
		{ 
			get { return _refreshStrategy; }
		}

		public ApiClientCustomerRegisterStrategyBase Register 
		{ 
			get { return _registerStrategy; }
		}

		public ApiClientCustomerEnrolStrategyBase Enrol 
		{ 
			get { return _enrolStrategy; }
		}

		public ApiClientCustomerGetPageStrategyBase GetPage 
		{ 
			get { return _getPageStrategy; }
		}

		
		protected ApiClientCustomerAddStrategyBase _addStrategy;
		protected ApiClientCustomerUpdateStrategyBase _updateStrategy;
		protected ApiClientCustomerDeleteStrategyBase _deleteStrategy;
		protected ApiClientCustomerSetActivatedStrategyBase _setActivatedStrategy;
		protected ApiClientCustomerSetDisabledStrategyBase _setDisabledStrategy;
		protected ApiClientCustomerUnlockStrategyBase _unlockStrategy;
		protected ApiClientCustomerGetByPKStrategyBase _getByPKStrategy;
		protected ApiClientCustomerGetByTokenStrategyBase _getByTokenStrategy;
		protected ApiClientCustomerCheckStrategyBase _checkStrategy;
		protected ApiClientCustomerActivateStrategyBase _activateStrategy;
		protected ApiClientCustomerRefreshStrategyBase _refreshStrategy;
		protected ApiClientCustomerRegisterStrategyBase _registerStrategy;
		protected ApiClientCustomerEnrolStrategyBase _enrolStrategy;
		protected ApiClientCustomerGetPageStrategyBase _getPageStrategy;
		
        public ApiClientCustomerStrategyStore(ApiClientCustomerAddStrategyBase addStrategy, ApiClientCustomerUpdateStrategyBase updateStrategy, ApiClientCustomerDeleteStrategyBase deleteStrategy, ApiClientCustomerSetActivatedStrategyBase setActivatedStrategy, ApiClientCustomerSetDisabledStrategyBase setDisabledStrategy, ApiClientCustomerUnlockStrategyBase unlockStrategy, ApiClientCustomerGetByPKStrategyBase getByPKStrategy, ApiClientCustomerGetByTokenStrategyBase getByTokenStrategy, ApiClientCustomerCheckStrategyBase checkStrategy, ApiClientCustomerActivateStrategyBase activateStrategy, ApiClientCustomerRefreshStrategyBase refreshStrategy, ApiClientCustomerRegisterStrategyBase registerStrategy, ApiClientCustomerEnrolStrategyBase enrolStrategy, ApiClientCustomerGetPageStrategyBase getPageStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (setActivatedStrategy == null)
				throw new ArgumentNullException("setActivatedStrategy");

			if (setDisabledStrategy == null)
				throw new ArgumentNullException("setDisabledStrategy");

			if (unlockStrategy == null)
				throw new ArgumentNullException("unlockStrategy");

			if (getByPKStrategy == null)
				throw new ArgumentNullException("getByPKStrategy");

			if (getByTokenStrategy == null)
				throw new ArgumentNullException("getByTokenStrategy");

			if (checkStrategy == null)
				throw new ArgumentNullException("checkStrategy");

			if (activateStrategy == null)
				throw new ArgumentNullException("activateStrategy");

			if (refreshStrategy == null)
				throw new ArgumentNullException("refreshStrategy");

			if (registerStrategy == null)
				throw new ArgumentNullException("registerStrategy");

			if (enrolStrategy == null)
				throw new ArgumentNullException("enrolStrategy");

			if (getPageStrategy == null)
				throw new ArgumentNullException("getPageStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteStrategy = deleteStrategy;
			_setActivatedStrategy = setActivatedStrategy;
			_setDisabledStrategy = setDisabledStrategy;
			_unlockStrategy = unlockStrategy;
			_getByPKStrategy = getByPKStrategy;
			_getByTokenStrategy = getByTokenStrategy;
			_checkStrategy = checkStrategy;
			_activateStrategy = activateStrategy;
			_refreshStrategy = refreshStrategy;
			_registerStrategy = registerStrategy;
			_enrolStrategy = enrolStrategy;
			_getPageStrategy = getPageStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteStrategy);
			Register(setActivatedStrategy);
			Register(setDisabledStrategy);
			Register(unlockStrategy);
			Register(getByPKStrategy);
			Register(getByTokenStrategy);
			Register(checkStrategy);
			Register(activateStrategy);
			Register(refreshStrategy);
			Register(registerStrategy);
			Register(enrolStrategy);
			Register(getPageStrategy);
			
			Init();
        }
    }
}