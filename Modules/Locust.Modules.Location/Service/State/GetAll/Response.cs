using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.State.Full;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateGetAllResponse : BaseServiceListResponse<ResponseType, StateGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == StateGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == StateGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == StateGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == StateGetAllStatus.Faulted;
        }

        public StateGetAllResponse()
            : this(StateGetAllStatus.None, new List<ResponseType>())
        { }
        public StateGetAllResponse(StateGetAllStatus status, IList<ResponseType> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = StateGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = StateGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = StateGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = StateGetAllStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = StateGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = StateGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != StateGetAllStatus.InvalidStatus;
        }
    }
}