using Locust.ServiceModel;
using System;
using Locust.Modules.Base.Strategies;
namespace Locust.Modules.Base.Service
{
	public partial class ApplicationStrategyStore : BaseServiceStrategyStore
    {
		public ApplicationAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public ApplicationUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public ApplicationDeleteStrategyBase Delete 
		{ 
			get { return _deleteStrategy; }
		}

		public ApplicationGetByPKStrategyBase GetByPK 
		{ 
			get { return _getByPKStrategy; }
		}

		public ApplicationGetByShortNameStrategyBase GetByShortName 
		{ 
			get { return _getByShortNameStrategy; }
		}

		public ApplicationGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}

		
		protected ApplicationAddStrategyBase _addStrategy;
		protected ApplicationUpdateStrategyBase _updateStrategy;
		protected ApplicationDeleteStrategyBase _deleteStrategy;
		protected ApplicationGetByPKStrategyBase _getByPKStrategy;
		protected ApplicationGetByShortNameStrategyBase _getByShortNameStrategy;
		protected ApplicationGetAllStrategyBase _getAllStrategy;
		
        public ApplicationStrategyStore(ApplicationAddStrategyBase addStrategy, ApplicationUpdateStrategyBase updateStrategy, ApplicationDeleteStrategyBase deleteStrategy, ApplicationGetByPKStrategyBase getByPKStrategy, ApplicationGetByShortNameStrategyBase getByShortNameStrategy, ApplicationGetAllStrategyBase getAllStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteStrategy == null)
				throw new ArgumentNullException("deleteStrategy");

			if (getByPKStrategy == null)
				throw new ArgumentNullException("getByPKStrategy");

			if (getByShortNameStrategy == null)
				throw new ArgumentNullException("getByShortNameStrategy");

			if (getAllStrategy == null)
				throw new ArgumentNullException("getAllStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteStrategy = deleteStrategy;
			_getByPKStrategy = getByPKStrategy;
			_getByShortNameStrategy = getByShortNameStrategy;
			_getAllStrategy = getAllStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteStrategy);
			Register(getByPKStrategy);
			Register(getByShortNameStrategy);
			Register(getAllStrategy);
			
			Init();
        }
    }
}