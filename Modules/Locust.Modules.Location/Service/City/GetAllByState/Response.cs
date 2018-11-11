using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using Locust.Modules.Location.Model.City;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetAllByStateResponse : BaseServicePageResponse<CityByState, CityGetAllByStateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CityGetAllByStateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CityGetAllByStateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CityGetAllByStateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CityGetAllByStateStatus.Faulted;
        }

        public CityGetAllByStateResponse()
            : this(CityGetAllByStateStatus.None, new PageData<CityByState>())
        { }
        public CityGetAllByStateResponse(CityGetAllByStateStatus status, PageData<CityByState> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CityGetAllByStateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CityGetAllByStateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CityGetAllByStateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CityGetAllByStateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CityGetAllByStateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CityGetAllByStateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CityGetAllByStateStatus.InvalidStatus;
        }
    }
}