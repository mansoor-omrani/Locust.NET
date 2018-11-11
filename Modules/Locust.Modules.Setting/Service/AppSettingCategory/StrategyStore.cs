using Locust.ServiceModel;
using System;
using Locust.Modules.Setting.Model;
using Locust.Modules.Setting.Strategies;
namespace Locust.Modules.Setting.Service
{
	public partial class AppSettingCategoryStrategyStore : BaseServiceStrategyStore
    {
		public AppSettingCategoryAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public AppSettingCategoryUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public AppSettingCategoryDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public AppSettingCategoryGetByPKStrategyBase GetByPK 
		{ 
			get { return _getByPKStrategy; }
		}

		public AppSettingCategoryGetByCodeStrategyBase GetByKey 
		{ 
			get { return _getByKeyStrategy; }
		}

		public AppSettingCategoryGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}

		
		protected AppSettingCategoryAddStrategyBase _addStrategy;
		protected AppSettingCategoryUpdateStrategyBase _updateStrategy;
		protected AppSettingCategoryDeleteStrategyBase _deleteStrategy;
		protected AppSettingCategoryGetByPKStrategyBase _getByPKStrategy;
		protected AppSettingCategoryGetByCodeStrategyBase _getByKeyStrategy;
		protected AppSettingCategoryGetAllStrategyBase _getAllStrategy;
		
        public AppSettingCategoryStrategyStore(AppSettingCategoryAddStrategyBase addStrategy, AppSettingCategoryUpdateStrategyBase updateStrategy, AppSettingCategoryDeleteStrategyBase deleteStrategy, AppSettingCategoryGetByPKStrategyBase getByPKStrategy, AppSettingCategoryGetByCodeStrategyBase getByKeyStrategy, AppSettingCategoryGetAllStrategyBase getAllStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (getByPKStrategy == null)
				throw new ArgumentNullException("getByPKStrategy");

			if (getByKeyStrategy == null)
				throw new ArgumentNullException("getByKeyStrategy");

			if (getAllStrategy == null)
				throw new ArgumentNullException("getAllStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteStrategy = deleteStrategy;
			_getByPKStrategy = getByPKStrategy;
			_getByKeyStrategy = getByKeyStrategy;
			_getAllStrategy = getAllStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteStrategy);
			Register(getByPKStrategy);
			Register(getByKeyStrategy);
			Register(getAllStrategy);
			
			Init();
        }
    }
}