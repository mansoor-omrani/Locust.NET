using System;
using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingDeleteResponse : BaseServiceResponse<object, AppSettingDeleteStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingDeleteStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingDeleteStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingDeleteStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingDeleteStatus.Faulted;
        }

        public AppSettingDeleteResponse()
            : this(AppSettingDeleteStatus.None, default(object))
        { }
        public AppSettingDeleteResponse(AppSettingDeleteStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingDeleteStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingDeleteStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingDeleteStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingDeleteStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingDeleteStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingDeleteStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingDeleteStatus.InvalidStatus;
        }
    }
}