using Locust.ServiceModel;
using System;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class ApiClientIPStrategyStore : BaseServiceStrategyStore
    {
		public ApiClientIPAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public ApiClientIPUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public ApiClientIPDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public ApiClientIPSetIsActiveStrategyBase SetIsActive
		{ 
			get { return _setIsActiveStrategy; }
		}

		public ApiClientIPGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}

		
		protected ApiClientIPAddStrategyBase _addStrategy;
		protected ApiClientIPUpdateStrategyBase _updateStrategy;
		protected ApiClientIPDeleteStrategyBase _deleteStrategy;
		protected ApiClientIPSetIsActiveStrategyBase _setIsActiveStrategy;
		protected ApiClientIPGetAllStrategyBase _getAllStrategy;
		
        public ApiClientIPStrategyStore(ApiClientIPAddStrategyBase addStrategy, ApiClientIPUpdateStrategyBase updateStrategy, ApiClientIPDeleteStrategyBase deleteStrategy, ApiClientIPSetIsActiveStrategyBase setIsActiveStrategy, ApiClientIPGetAllStrategyBase getAllStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (setIsActiveStrategy == null)
				throw new ArgumentNullException("setIsActiveStrategy");

			if (getAllStrategy == null)
				throw new ArgumentNullException("getAllStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteStrategy = deleteStrategy;
			_setIsActiveStrategy = setIsActiveStrategy;
			_getAllStrategy = getAllStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteStrategy);
			Register(setIsActiveStrategy);
			Register(getAllStrategy);
			
			Init();
        }
    }
}