using Locust.ServiceModel;
using System;
using Locust.Modules.Base.Strategies;

namespace Locust.Modules.Base.Service
{
	public partial class AppCrossOriginStrategyStore : BaseServiceStrategyStore
    {
		public AppCrossOriginAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public AppCrossOriginUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public AppCrossOriginDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public AppCrossOriginGetByPKStrategyBase GetByPK 
		{ 
			get { return _getByPKStrategy; }
		}

		public AppCrossOriginGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}

		
		protected AppCrossOriginAddStrategyBase _addStrategy;
		protected AppCrossOriginUpdateStrategyBase _updateStrategy;
		protected AppCrossOriginDeleteStrategyBase _deleteStrategy;
		protected AppCrossOriginGetByPKStrategyBase _getByPKStrategy;
		protected AppCrossOriginGetAllStrategyBase _getAllStrategy;
		
        public AppCrossOriginStrategyStore(AppCrossOriginAddStrategyBase addStrategy, AppCrossOriginUpdateStrategyBase updateStrategy, AppCrossOriginDeleteStrategyBase deleteStrategy, AppCrossOriginGetByPKStrategyBase getByPKStrategy, AppCrossOriginGetAllStrategyBase getAllStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (getByPKStrategy == null)
				throw new ArgumentNullException("getByPKStrategy");

			if (getAllStrategy == null)
				throw new ArgumentNullException("getAllStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteStrategy = deleteStrategy;
			_getByPKStrategy = getByPKStrategy;
			_getAllStrategy = getAllStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteStrategy);
			Register(getByPKStrategy);
			Register(getAllStrategy);
			
			Init();
        }
    }
}