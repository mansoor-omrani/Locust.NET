using Locust.ServiceModel;
using System;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class ServiceSettingStrategyStore : BaseServiceStrategyStore
    {
		public ServiceSettingAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public ServiceSettingUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public ServiceSettingDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public ServiceSettingGetAllByServiceStrategyBase GetAllByService
		{ 
			get { return _getAllByServiceStrategy; }
		}

		
		protected ServiceSettingAddStrategyBase _addStrategy;
		protected ServiceSettingUpdateStrategyBase _updateStrategy;
		protected ServiceSettingDeleteStrategyBase _deleteStrategy;
		protected ServiceSettingGetAllByServiceStrategyBase _getAllByServiceStrategy;
		
        public ServiceSettingStrategyStore(ServiceSettingAddStrategyBase addStrategy, ServiceSettingUpdateStrategyBase updateStrategy, ServiceSettingDeleteStrategyBase deleteStrategy, ServiceSettingGetAllByServiceStrategyBase getAllByServiceStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (getAllByServiceStrategy == null)
				throw new ArgumentNullException("getAllByServiceStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteStrategy = deleteStrategy;
			_getAllByServiceStrategy = getAllByServiceStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteStrategy);
			Register(getAllByServiceStrategy);
			
			Init();
        }
    }
}