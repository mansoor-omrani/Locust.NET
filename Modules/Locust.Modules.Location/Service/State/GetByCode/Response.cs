using System;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.State.Full;

namespace Locust.Modules.Location.Strategies
{
	public partial class StateGetByCodeResponse : BaseServiceResponse<ResponseType, StateGetByCodeStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == StateGetByCodeStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == StateGetByCodeStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == StateGetByCodeStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == StateGetByCodeStatus.Faulted;
        }

        public StateGetByCodeResponse()
            : this(StateGetByCodeStatus.None, default(ResponseType))
        { }
        public StateGetByCodeResponse(StateGetByCodeStatus status,ResponseType data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = StateGetByCodeStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = StateGetByCodeStatus.Success;
        }

		public override void Failed()
        {
            this.Status = StateGetByCodeStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = StateGetByCodeStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = StateGetByCodeStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = StateGetByCodeStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != StateGetByCodeStatus.InvalidStatus;
        }
    }
}