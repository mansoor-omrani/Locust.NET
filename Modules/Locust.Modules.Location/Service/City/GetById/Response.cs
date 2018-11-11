using System;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.City.City;

namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetByIdResponse : BaseServiceResponse<ResponseType, CityGetByIdStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CityGetByIdStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CityGetByIdStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CityGetByIdStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CityGetByIdStatus.Faulted;
        }

        public CityGetByIdResponse()
            : this(CityGetByIdStatus.None, default(ResponseType))
        { }
        public CityGetByIdResponse(CityGetByIdStatus status,ResponseType data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CityGetByIdStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CityGetByIdStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CityGetByIdStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CityGetByIdStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CityGetByIdStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CityGetByIdStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CityGetByIdStatus.InvalidStatus;
        }
    }
}