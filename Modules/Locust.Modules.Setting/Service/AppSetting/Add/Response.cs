using System;
using Locust.ServiceModel;

namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingAddResponse : BaseServiceResponse<object, AppSettingAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingAddStatus.Faulted;
        }

        public AppSettingAddResponse()
            : this(AppSettingAddStatus.None, default(object))
        { }
        public AppSettingAddResponse(AppSettingAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingAddStatus.InvalidStatus;
        }
    }
}