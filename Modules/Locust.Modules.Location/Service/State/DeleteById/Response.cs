using System;
using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class StateDeleteByIdResponse : BaseServiceResponse<object, StateDeleteByIdStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == StateDeleteByIdStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == StateDeleteByIdStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == StateDeleteByIdStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == StateDeleteByIdStatus.Faulted;
        }

        public StateDeleteByIdResponse()
            : this(StateDeleteByIdStatus.None, default(object))
        { }
        public StateDeleteByIdResponse(StateDeleteByIdStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = StateDeleteByIdStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = StateDeleteByIdStatus.Success;
        }

		public override void Failed()
        {
            this.Status = StateDeleteByIdStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = StateDeleteByIdStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = StateDeleteByIdStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = StateDeleteByIdStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != StateDeleteByIdStatus.InvalidStatus;
        }
    }
}