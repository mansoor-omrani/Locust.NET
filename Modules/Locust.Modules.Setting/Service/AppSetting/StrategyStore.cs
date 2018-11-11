using Locust.ServiceModel;
using System;
using Locust.Modules.Setting.Model;
using Locust.Modules.Setting.Strategies;
namespace Locust.Modules.Setting.Service
{
	public partial class AppSettingStrategyStore : BaseServiceStrategyStore
    {
		public AppSettingAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public AppSettingQuickAddStrategyBase QuickAdd 
		{ 
			get { return _quickAddStrategy; }
		}

		public AppSettingUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public AppSettingQuickUpdateStrategyBase QuickUpdate 
		{ 
			get { return _quickUpdateStrategy; }
		}

		public AppSettingDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public AppSettingGetByPKStrategyBase GetByPK 
		{ 
			get { return _getByPKStrategy; }
		}

		public AppSettingGetByKeyStrategyBase GetByKey 
		{ 
			get { return _getByKeyStrategy; }
		}

		public AppSettingGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}

		
		protected AppSettingAddStrategyBase _addStrategy;
		protected AppSettingQuickAddStrategyBase _quickAddStrategy;
		protected AppSettingUpdateStrategyBase _updateStrategy;
		protected AppSettingQuickUpdateStrategyBase _quickUpdateStrategy;
		protected AppSettingDeleteStrategyBase _deleteStrategy;
		protected AppSettingGetByPKStrategyBase _getByPKStrategy;
		protected AppSettingGetByKeyStrategyBase _getByKeyStrategy;
		protected AppSettingGetAllStrategyBase _getAllStrategy;
		
        public AppSettingStrategyStore(AppSettingAddStrategyBase addStrategy, AppSettingQuickAddStrategyBase quickAddStrategy, AppSettingUpdateStrategyBase updateStrategy, AppSettingQuickUpdateStrategyBase quickUpdateStrategy, AppSettingDeleteStrategyBase deleteStrategy, AppSettingGetByPKStrategyBase getByPKStrategy, AppSettingGetByKeyStrategyBase getByKeyStrategy, AppSettingGetAllStrategyBase getAllStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (quickAddStrategy == null)
				throw new ArgumentNullException("quickAddStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (quickUpdateStrategy == null)
				throw new ArgumentNullException("quickUpdateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (getByPKStrategy == null)
				throw new ArgumentNullException("getByPKStrategy");

			if (getByKeyStrategy == null)
				throw new ArgumentNullException("getByKeyStrategy");

			if (getAllStrategy == null)
				throw new ArgumentNullException("getAllStrategy");

			
			_addStrategy = addStrategy;
			_quickAddStrategy = quickAddStrategy;
			_updateStrategy = updateStrategy;
			_quickUpdateStrategy = quickUpdateStrategy;
			_deleteStrategy = deleteStrategy;
			_getByPKStrategy = getByPKStrategy;
			_getByKeyStrategy = getByKeyStrategy;
			_getAllStrategy = getAllStrategy;
			
            Register(addStrategy);
			Register(quickAddStrategy);
			Register(updateStrategy);
			Register(quickUpdateStrategy);
			Register(deleteStrategy);
			Register(getByPKStrategy);
			Register(getByKeyStrategy);
			Register(getAllStrategy);
			
			Init();
        }
    }
}