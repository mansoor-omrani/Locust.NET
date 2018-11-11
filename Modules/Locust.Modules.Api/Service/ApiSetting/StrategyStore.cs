using Locust.ServiceModel;
using System;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class ApiSettingStrategyStore : BaseServiceStrategyStore
    {
		public ApiSettingAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public ApiSettingUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public ApiSettingDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public ApiSettingGetAllByApiStrategyBase GetAllByApi 
		{ 
			get { return _getAllByApiStrategy; }
		}

		
		protected ApiSettingAddStrategyBase _addStrategy;
		protected ApiSettingUpdateStrategyBase _updateStrategy;
		protected ApiSettingDeleteStrategyBase _deleteStrategy;
		protected ApiSettingGetAllByApiStrategyBase _getAllByApiStrategy;
		
        public ApiSettingStrategyStore(ApiSettingAddStrategyBase addStrategy, ApiSettingUpdateStrategyBase updateStrategy, ApiSettingDeleteStrategyBase deleteStrategy, ApiSettingGetAllByApiStrategyBase getAllByApiStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (getAllByApiStrategy == null)
				throw new ArgumentNullException("getAllByApiStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteStrategy = deleteStrategy;
			_getAllByApiStrategy = getAllByApiStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteStrategy);
			Register(getAllByApiStrategy);
			
			Init();
        }
    }
}