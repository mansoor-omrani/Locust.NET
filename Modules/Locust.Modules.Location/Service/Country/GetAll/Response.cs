using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using ResponseType = Locust.Modules.Location.Model.Country.Full;

namespace Locust.Modules.Location.Strategies
{
	public partial class CountryGetAllResponse : BaseServiceListResponse<ResponseType, CountryGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == CountryGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == CountryGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == CountryGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == CountryGetAllStatus.Faulted;
        }

        public CountryGetAllResponse()
            : this(CountryGetAllStatus.None, new List<ResponseType>())
        { }
        public CountryGetAllResponse(CountryGetAllStatus status, IList<ResponseType> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = CountryGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = CountryGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = CountryGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = CountryGetAllStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = CountryGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = CountryGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != CountryGetAllStatus.InvalidStatus;
        }
    }
}