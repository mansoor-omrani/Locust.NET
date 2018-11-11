using System;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.City.City;
namespace Locust.Modules.Location.Strategies
{
	public partial class CityGetByCodeResponse : BaseServiceResponse<ResponseType, CityGetByCodeStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CityGetByCodeStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CityGetByCodeStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CityGetByCodeStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CityGetByCodeStatus.Faulted;
        }

        public CityGetByCodeResponse()
            : this(CityGetByCodeStatus.None, default(ResponseType))
        { }
        public CityGetByCodeResponse(CityGetByCodeStatus status, ResponseType data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CityGetByCodeStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CityGetByCodeStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CityGetByCodeStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CityGetByCodeStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CityGetByCodeStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CityGetByCodeStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CityGetByCodeStatus.InvalidStatus;
        }
    }
}