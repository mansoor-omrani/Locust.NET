using System;
using Locust.ServiceModel;
using Locust.Modules.Location.Model;
namespace Locust.Modules.Location.Strategies
{
	public partial class CountryDeleteByIdResponse : BaseServiceResponse<object, CountryDeleteByIdStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CountryDeleteByIdStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CountryDeleteByIdStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CountryDeleteByIdStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CountryDeleteByIdStatus.Faulted;
        }

        public CountryDeleteByIdResponse()
            : this(CountryDeleteByIdStatus.None, default(object))
        { }
        public CountryDeleteByIdResponse(CountryDeleteByIdStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CountryDeleteByIdStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CountryDeleteByIdStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CountryDeleteByIdStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CountryDeleteByIdStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CountryDeleteByIdStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CountryDeleteByIdStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CountryDeleteByIdStatus.InvalidStatus;
        }
    }
}