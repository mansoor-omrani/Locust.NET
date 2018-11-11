using System;
using System.Collections.Generic;
using Locust.ServiceModel;
using API = Locust.Modules.Api.Model.Api;

namespace Locust.Modules.Api.Strategies
{
	public partial class ApiGetAllByAppShortNameResponse : BaseServiceListResponse<API.Full, ApiGetAllByAppShortNameStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == ApiGetAllByAppShortNameStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == ApiGetAllByAppShortNameStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == ApiGetAllByAppShortNameStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == ApiGetAllByAppShortNameStatus.Faulted;
        }

        public ApiGetAllByAppShortNameResponse()
            : this(ApiGetAllByAppShortNameStatus.None, new List<API.Full>())
        { }
        public ApiGetAllByAppShortNameResponse(ApiGetAllByAppShortNameStatus status, IList<API.Full> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = ApiGetAllByAppShortNameStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = ApiGetAllByAppShortNameStatus.Success;
        }

		public override void Failed()
        {
            this.Status = ApiGetAllByAppShortNameStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = ApiGetAllByAppShortNameStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = ApiGetAllByAppShortNameStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = ApiGetAllByAppShortNameStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != ApiGetAllByAppShortNameStatus.InvalidStatus;
        }
    }
}