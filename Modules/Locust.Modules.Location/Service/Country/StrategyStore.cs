using Locust.ServiceModel;
using System;
using Locust.Modules.Location.Model;
using Locust.Modules.Location.Strategies;
namespace Locust.Modules.Location.Service
{
	public partial class CountryStrategyStore : BaseServiceStrategyStore
    {
		public CountryAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public CountryUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public CountryDeleteByIdStrategyBase DeleteById 
		{ 
			get { return _deleteByIdStrategy; }
		}

		public CountryGetByIdStrategyBase GetById 
		{ 
			get { return _getByIdStrategy; }
		}

		public CountryGetByCodeStrategyBase GetByCode 
		{ 
			get { return _getByCodeStrategy; }
		}

		public CountryGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}

		
		protected CountryAddStrategyBase _addStrategy;
		protected CountryUpdateStrategyBase _updateStrategy;
		protected CountryDeleteByIdStrategyBase _deleteByIdStrategy;
		protected CountryGetByIdStrategyBase _getByIdStrategy;
		protected CountryGetByCodeStrategyBase _getByCodeStrategy;
		protected CountryGetAllStrategyBase _getAllStrategy;
		
        public CountryStrategyStore(CountryAddStrategyBase addStrategy, CountryUpdateStrategyBase updateStrategy, CountryDeleteByIdStrategyBase deleteByIdStrategy, CountryGetByIdStrategyBase getByIdStrategy, CountryGetByCodeStrategyBase getByCodeStrategy, CountryGetAllStrategyBase getAllStrategy)
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

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteByIdStrategy = deleteByIdStrategy;
			_getByIdStrategy = getByIdStrategy;
			_getByCodeStrategy = getByCodeStrategy;
			_getAllStrategy = getAllStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteByIdStrategy);
			Register(getByIdStrategy);
			Register(getByCodeStrategy);
			Register(getAllStrategy);
			
			Init();
        }
    }
}