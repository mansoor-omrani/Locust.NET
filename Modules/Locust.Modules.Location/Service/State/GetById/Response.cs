using System;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.State.Full;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateGetByIdResponse : BaseServiceResponse<ResponseType, StateGetByIdStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == StateGetByIdStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == StateGetByIdStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == StateGetByIdStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == StateGetByIdStatus.Faulted;
        }

        public StateGetByIdResponse()
            : this(StateGetByIdStatus.None, default(ResponseType))
        { }
        public StateGetByIdResponse(StateGetByIdStatus status,ResponseType data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = StateGetByIdStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = StateGetByIdStatus.Success;
        }

		public override void Failed()
        {
            this.Status = StateGetByIdStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = StateGetByIdStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = StateGetByIdStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = StateGetByIdStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != StateGetByIdStatus.InvalidStatus;
        }
    }
}