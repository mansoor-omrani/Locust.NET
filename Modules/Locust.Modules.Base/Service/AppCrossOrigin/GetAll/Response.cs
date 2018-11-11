using System;
using System.Collections.Generic;
using Locust.ServiceModel;

using AppCrossOrigin = Locust.Modules.Base.Model.AppCrossOrigin.AdminGrid;

namespace Locust.Modules.Base.Strategies
{
	public partial class AppCrossOriginGetAllResponse : BaseServiceListResponse<AppCrossOrigin, AppCrossOriginGetAllStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppCrossOriginGetAllStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppCrossOriginGetAllStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppCrossOriginGetAllStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppCrossOriginGetAllStatus.Faulted;
        }

        public AppCrossOriginGetAllResponse()
            : this(AppCrossOriginGetAllStatus.None, new List<AppCrossOrigin>())
        { }
        public AppCrossOriginGetAllResponse(AppCrossOriginGetAllStatus status, IList<AppCrossOrigin> data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppCrossOriginGetAllStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppCrossOriginGetAllStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppCrossOriginGetAllStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppCrossOriginGetAllStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppCrossOriginGetAllStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppCrossOriginGetAllStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppCrossOriginGetAllStatus.InvalidStatus;
        }
    }
}