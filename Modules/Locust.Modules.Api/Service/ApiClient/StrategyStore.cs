using Locust.ServiceModel;
using System;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Strategies;

namespace Locust.Modules.Api.Service
{
	public partial class ApiClientStrategyStore : BaseServiceStrategyStore
    {
		public ApiClientAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public ApiClientUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public ApiClientDeleteByPKStrategyBase DeleteByPK 
		{ 
			get { return _deleteByPKStrategy; }
		}

		public ApiClientDeleteByKeyStrategyBase DeleteByKey 
		{ 
			get { return _deleteByKeyStrategy; }
		}

		public ApiClientRemoveByPKStrategyBase RemoveByPK 
		{ 
			get { return _removeByPKStrategy; }
		}

		public ApiClientRemoveByKeyStrategyBase RemoveByKey 
		{ 
			get { return _removeByKeyStrategy; }
		}

		public ApiClientGetByPKStrategyBase GetByPK 
		{ 
			get { return _getByPKStrategy; }
		}

		public ApiClientGetByKeyStrategyBase GetByKey 
		{ 
			get { return _getByKeyStrategy; }
		}

		public ApiClientGetByHashStrategyBase GetByHash 
		{ 
			get { return _getByHashStrategy; }
		}

		public ApiClientGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}

		public ApiClientGetApisStrategyBase GetApis 
		{ 
			get { return _getApisStrategy; }
		}

		public ApiClientSaveApisStrategyBase SaveApis 
		{ 
			get { return _saveApisStrategy; }
		}

		public ApiClientGetPageStrategyBase GetPage 
		{ 
			get { return _getPageStrategy; }
		}

		
		protected ApiClientAddStrategyBase _addStrategy;
		protected ApiClientUpdateStrategyBase _updateStrategy;
		protected ApiClientDeleteByPKStrategyBase _deleteByPKStrategy;
		protected ApiClientDeleteByKeyStrategyBase _deleteByKeyStrategy;
		protected ApiClientRemoveByPKStrategyBase _removeByPKStrategy;
		protected ApiClientRemoveByKeyStrategyBase _removeByKeyStrategy;
		protected ApiClientGetByPKStrategyBase _getByPKStrategy;
		protected ApiClientGetByKeyStrategyBase _getByKeyStrategy;
		protected ApiClientGetByHashStrategyBase _getByHashStrategy;
		protected ApiClientGetAllStrategyBase _getAllStrategy;
		protected ApiClientGetApisStrategyBase _getApisStrategy;
		protected ApiClientSaveApisStrategyBase _saveApisStrategy;
		protected ApiClientGetPageStrategyBase _getPageStrategy;
		
        public ApiClientStrategyStore(ApiClientAddStrategyBase addStrategy, ApiClientUpdateStrategyBase updateStrategy, ApiClientDeleteByPKStrategyBase deleteByPKStrategy, ApiClientDeleteByKeyStrategyBase deleteByKeyStrategy, ApiClientRemoveByPKStrategyBase removeByPKStrategy, ApiClientRemoveByKeyStrategyBase removeByKeyStrategy, ApiClientGetByPKStrategyBase getByPKStrategy, ApiClientGetByKeyStrategyBase getByKeyStrategy, ApiClientGetByHashStrategyBase getByHashStrategy, ApiClientGetAllStrategyBase getAllStrategy, ApiClientGetApisStrategyBase getApisStrategy, ApiClientSaveApisStrategyBase saveApisStrategy, ApiClientGetPageStrategyBase getPageStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteByPKStrategy == null)
				throw new ArgumentNullException("deleteByPKStrategy");

			if (deleteByKeyStrategy == null)
				throw new ArgumentNullException("deleteByKeyStrategy");

			if (removeByPKStrategy == null)
				throw new ArgumentNullException("removeByPKStrategy");

			if (removeByKeyStrategy == null)
				throw new ArgumentNullException("removeByKeyStrategy");

			if (getByPKStrategy == null)
				throw new ArgumentNullException("getByPKStrategy");

			if (getByKeyStrategy == null)
				throw new ArgumentNullException("getByKeyStrategy");

			if (getByHashStrategy == null)
				throw new ArgumentNullException("getByHashStrategy");

			if (getAllStrategy == null)
				throw new ArgumentNullException("getAllStrategy");

			if (getApisStrategy == null)
				throw new ArgumentNullException("getApisStrategy");

			if (saveApisStrategy == null)
				throw new ArgumentNullException("saveApisStrategy");

			if (getPageStrategy == null)
				throw new ArgumentNullException("getPageStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteByPKStrategy = deleteByPKStrategy;
			_deleteByKeyStrategy = deleteByKeyStrategy;
			_removeByPKStrategy = removeByPKStrategy;
			_removeByKeyStrategy = removeByKeyStrategy;
			_getByPKStrategy = getByPKStrategy;
			_getByKeyStrategy = getByKeyStrategy;
			_getByHashStrategy = getByHashStrategy;
			_getAllStrategy = getAllStrategy;
			_getApisStrategy = getApisStrategy;
			_saveApisStrategy = saveApisStrategy;
			_getPageStrategy = getPageStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteByPKStrategy);
			Register(deleteByKeyStrategy);
			Register(removeByPKStrategy);
			Register(removeByKeyStrategy);
			Register(getByPKStrategy);
			Register(getByKeyStrategy);
			Register(getByHashStrategy);
			Register(getAllStrategy);
			Register(getApisStrategy);
			Register(saveApisStrategy);
			Register(getPageStrategy);
			
			Init();
        }
    }
}