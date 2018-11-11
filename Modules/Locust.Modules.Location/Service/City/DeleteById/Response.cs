using System;
using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityDeleteByIdResponse : BaseServiceResponse<object, CityDeleteByIdStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CityDeleteByIdStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CityDeleteByIdStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CityDeleteByIdStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CityDeleteByIdStatus.Faulted;
        }

        public CityDeleteByIdResponse()
            : this(CityDeleteByIdStatus.None, default(object))
        { }
        public CityDeleteByIdResponse(CityDeleteByIdStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CityDeleteByIdStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CityDeleteByIdStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CityDeleteByIdStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CityDeleteByIdStatus.Errored;
        }
        public override void NotFound()
        {
            this.Status = CityDeleteByIdStatus.NotFound;
        }

		public override bool SetStatus(object status)
        {
            var result = CityDeleteByIdStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CityDeleteByIdStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CityDeleteByIdStatus.InvalidStatus;
        }
    }
}