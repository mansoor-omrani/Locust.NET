using System;
using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityUpdateResponse : BaseServiceResponse<object, CityUpdateStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CityUpdateStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CityUpdateStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CityUpdateStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CityUpdateStatus.Faulted;
        }

        public CityUpdateResponse()
            : this(CityUpdateStatus.None, default(object))
        { }
        public CityUpdateResponse(CityUpdateStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CityUpdateStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CityUpdateStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CityUpdateStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CityUpdateStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CityUpdateStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CityUpdateStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CityUpdateStatus.InvalidStatus;
        }
    }
}