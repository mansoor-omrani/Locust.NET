using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Location.Model.City;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetByStateResponse : BaseServiceListResponse<City, CityGetByStateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CityGetByStateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CityGetByStateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CityGetByStateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CityGetByStateStatus.Faulted;
        }

        public CityGetByStateResponse()
            : this(CityGetByStateStatus.None, new List<City>())
        { }
        public CityGetByStateResponse(CityGetByStateStatus status, IList<City> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CityGetByStateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CityGetByStateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CityGetByStateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CityGetByStateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CityGetByStateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CityGetByStateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CityGetByStateStatus.InvalidStatus;
        }
    }
}