using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.City.CityState;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateGetCitiesResponse : BaseServiceListResponse<ResponseType, StateGetCitiesStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == StateGetCitiesStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == StateGetCitiesStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == StateGetCitiesStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == StateGetCitiesStatus.Faulted;
        }

        public StateGetCitiesResponse()
            : this(StateGetCitiesStatus.None, new List<ResponseType>())
        { }
        public StateGetCitiesResponse(StateGetCitiesStatus status, IList<ResponseType> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = StateGetCitiesStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = StateGetCitiesStatus.Success;
        }

		public override void Failed()
        {
            this.Status = StateGetCitiesStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = StateGetCitiesStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = StateGetCitiesStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = StateGetCitiesStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != StateGetCitiesStatus.InvalidStatus;
        }
    }
}