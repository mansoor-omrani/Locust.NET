using Locust.ServiceModel;
using System;
using Locust.Modules.Api.Model;
using Locust.Modules.Api.Strategies;
namespace Locust.Modules.Api.Service
{
	public partial class ApiStrategyStore : BaseServiceStrategyStore
    {
		public ApiAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public ApiUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public ApiDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public ApiGetByPKStrategyBase GetByPK 
		{ 
			get { return _getByPKStrategy; }
		}

		public ApiGetByPathStrategyBase GetByApiPath 
		{ 
			get { return _getByApiPathStrategy; }
		}

		public ApiGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}

		public ApiGetAllByAppShortNameStrategyBase GetAllByAppShortName 
		{ 
			get { return _getAllByAppShortNameStrategy; }
		}

		public ApiCheckAccessStrategyBase CheckAccess 
		{ 
			get { return _checkAccessStrategy; }
		}

		
		protected ApiAddStrategyBase _addStrategy;
		protected ApiUpdateStrategyBase _updateStrategy;
		protected ApiDeleteStrategyBase _deleteStrategy;
		protected ApiGetByPKStrategyBase _getByPKStrategy;
		protected ApiGetByPathStrategyBase _getByApiPathStrategy;
		protected ApiGetAllStrategyBase _getAllStrategy;
		protected ApiGetAllByAppShortNameStrategyBase _getAllByAppShortNameStrategy;
		protected ApiCheckAccessStrategyBase _checkAccessStrategy;
		
        public ApiStrategyStore(ApiAddStrategyBase addStrategy, ApiUpdateStrategyBase updateStrategy, ApiDeleteStrategyBase deleteStrategy, ApiGetByPKStrategyBase getByPKStrategy, ApiGetByPathStrategyBase getByApiPathStrategy, ApiGetAllStrategyBase getAllStrategy, ApiGetAllByAppShortNameStrategyBase getAllByAppShortNameStrategy, ApiCheckAccessStrategyBase checkAccessStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (getByPKStrategy == null)
				throw new ArgumentNullException("getByPKStrategy");

			if (getByApiPathStrategy == null)
				throw new ArgumentNullException("getByApiPathStrategy");

			if (getAllStrategy == null)
				throw new ArgumentNullException("getAllStrategy");

			if (getAllByAppShortNameStrategy == null)
				throw new ArgumentNullException("getAllByAppShortNameStrategy");

			if (checkAccessStrategy == null)
				throw new ArgumentNullException("checkAccessStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteStrategy = deleteStrategy;
			_getByPKStrategy = getByPKStrategy;
			_getByApiPathStrategy = getByApiPathStrategy;
			_getAllStrategy = getAllStrategy;
			_getAllByAppShortNameStrategy = getAllByAppShortNameStrategy;
			_checkAccessStrategy = checkAccessStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteStrategy);
			Register(getByPKStrategy);
			Register(getByApiPathStrategy);
			Register(getAllStrategy);
			Register(getAllByAppShortNameStrategy);
			Register(checkAccessStrategy);
			
			Init();
        }
    }
}