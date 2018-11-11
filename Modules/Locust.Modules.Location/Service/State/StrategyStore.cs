using Locust.ServiceModel;
using System;
using Locust.Modules.Location.Model;
using Locust.Modules.Location.Strategies;
namespace Locust.Modules.Location.Service
{
	public partial class StateStrategyStore : BaseServiceStrategyStore
    {
		public StateAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public StateUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public StateDeleteByIdStrategyBase DeleteById 
		{ 
			get { return _deleteByIdStrategy; }
		}

		public StateGetByIdStrategyBase GetById 
		{ 
			get { return _getByIdStrategy; }
		}

		public StateGetByCodeStrategyBase GetByCode 
		{ 
			get { return _getByCodeStrategy; }
		}

		public StateGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}

		public StateGetCitiesStrategyBase GetCities 
		{ 
			get { return _getCitiesStrategy; }
		}

		
		protected StateAddStrategyBase _addStrategy;
		protected StateUpdateStrategyBase _updateStrategy;
		protected StateDeleteByIdStrategyBase _deleteByIdStrategy;
		protected StateGetByIdStrategyBase _getByIdStrategy;
		protected StateGetByCodeStrategyBase _getByCodeStrategy;
		protected StateGetAllStrategyBase _getAllStrategy;
		protected StateGetCitiesStrategyBase _getCitiesStrategy;
		
        public StateStrategyStore(StateAddStrategyBase addStrategy, StateUpdateStrategyBase updateStrategy, StateDeleteByIdStrategyBase deleteByIdStrategy, StateGetByIdStrategyBase getByIdStrategy, StateGetByCodeStrategyBase getByCodeStrategy, StateGetAllStrategyBase getAllStrategy, StateGetCitiesStrategyBase getCitiesStrategy)
        {
			if (addStrategy == null)
				throw new ArgumentNullException("addStrategy");

			if (updateStrategy == null)
				throw new ArgumentNullException("updateStrategy");

			if (deleteByIdStrategy == null)
				throw new ArgumentNullException("deleteByIdStrategy");

			if (getByIdStrategy == null)
				throw new ArgumentNullException("getByIdStrategy");

			if (getByCodeStrategy == null)
				throw new ArgumentNullException("getByCodeStrategy");

			if (getAllStrategy == null)
				throw new ArgumentNullException("getAllStrategy");

			if (getCitiesStrategy == null)
				throw new ArgumentNullException("getCitiesStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteByIdStrategy = deleteByIdStrategy;
			_getByIdStrategy = getByIdStrategy;
			_getByCodeStrategy = getByCodeStrategy;
			_getAllStrategy = getAllStrategy;
			_getCitiesStrategy = getCitiesStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteByIdStrategy);
			Register(getByIdStrategy);
			Register(getByCodeStrategy);
			Register(getAllStrategy);
			Register(getCitiesStrategy);
			
			Init();
        }
    }
}