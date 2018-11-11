using Locust.ServiceModel;
using System;
using Locust.Modules.Location.Model;
using Locust.Modules.Location.Strategies;
namespace Locust.Modules.Location.Service
{
	public partial class CityStrategyStore : BaseServiceStrategyStore
    {
		public CityAddStrategyBase Add 
		{ 
			get { return _addStrategy; }
		}

		public CityUpdateStrategyBase Update 
		{ 
			get { return _updateStrategy; }
		}

		public CityDeleteByIdStrategyBase DeleteById 
		{ 
			get { return _deleteByIdStrategy; }
		}

		public CityGetByIdStrategyBase GetById 
		{ 
			get { return _getByIdStrategy; }
		}

		public CityGetByCodeStrategyBase GetByCode 
		{ 
			get { return _getByCodeStrategy; }
		}

		public CityGetAllStrategyBase GetAll 
		{ 
			get { return _getAllStrategy; }
		}
        public CityGetAllByStateStrategyBase GetAllByState
        {
            get { return _getAllByStateStrategy; }
        }
		public CityGetByStateStrategyBase GetByState 
		{ 
			get { return _getByStateStrategy; }
		}

		
		protected CityAddStrategyBase _addStrategy;
		protected CityUpdateStrategyBase _updateStrategy;
		protected CityDeleteByIdStrategyBase _deleteByIdStrategy;
		protected CityGetByIdStrategyBase _getByIdStrategy;
		protected CityGetByCodeStrategyBase _getByCodeStrategy;
		protected CityGetAllStrategyBase _getAllStrategy;
		protected CityGetAllByStateStrategyBase _getAllByStateStrategy;
		protected CityGetByStateStrategyBase _getByStateStrategy;
		
        public CityStrategyStore(CityAddStrategyBase addStrategy, CityUpdateStrategyBase updateStrategy, CityDeleteByIdStrategyBase deleteByIdStrategy, CityGetByIdStrategyBase getByIdStrategy, CityGetByCodeStrategyBase getByCodeStrategy, CityGetAllStrategyBase getAllStrategy, CityGetAllByStateStrategyBase getAllByStateStrategy, CityGetByStateStrategyBase getByStateStrategy)
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

            if (getAllByStateStrategy == null)
                throw new ArgumentNullException("getAllByStateStrategy");

			if (getByStateStrategy == null)
				throw new ArgumentNullException("getByStateStrategy");

			
			_addStrategy = addStrategy;
			_updateStrategy = updateStrategy;
			_deleteByIdStrategy = deleteByIdStrategy;
			_getByIdStrategy = getByIdStrategy;
			_getByCodeStrategy = getByCodeStrategy;
			_getAllStrategy = getAllStrategy;
            _getAllByStateStrategy = getAllByStateStrategy;
			_getByStateStrategy = getByStateStrategy;
			
            Register(addStrategy);
			Register(updateStrategy);
			Register(deleteByIdStrategy);
			Register(getByIdStrategy);
			Register(getByCodeStrategy);
			Register(getAllStrategy);
			Register(getAllByStateStrategy);
			Register(getByStateStrategy);
			
			Init();
        }
    }
}