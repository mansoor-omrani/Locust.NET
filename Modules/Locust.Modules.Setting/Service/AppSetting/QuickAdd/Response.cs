using System;
using Locust.ServiceModel;
using Locust.Modules.Setting.Model;
namespace Locust.Modules.Setting.Strategies
{
	public partial class AppSettingQuickAddResponse : BaseServiceResponse<object, AppSettingQuickAddStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == AppSettingQuickAddStatus.Success;
        }

		public override bool IsFailed()
        {
            return Status == AppSettingQuickAddStatus.Failed;
        }

		 public override bool IsErrored()
        {
            return Status == AppSettingQuickAddStatus.Errored;
        }

		public override bool IsFaulted()
        {
            return Status == AppSettingQuickAddStatus.Faulted;
        }

        public AppSettingQuickAddResponse()
            : this(AppSettingQuickAddStatus.None, default(object))
        { }
        public AppSettingQuickAddResponse(AppSettingQuickAddStatus status,object data)
            : base(status, data)
        { }

		public override void Faulted()
        {
            this.Status = AppSettingQuickAddStatus.Faulted;
        }

		public override void Succeeded()
        {
            this.Status = AppSettingQuickAddStatus.Success;
        }

		public override void Failed()
        {
            this.Status = AppSettingQuickAddStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = AppSettingQuickAddStatus.Errored;
        }
        public override void NotFound()
        {
            throw new NotImplementedException();
        }

		public override bool SetStatus(object status)
        {
            var result = AppSettingQuickAddStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = AppSettingQuickAddStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != AppSettingQuickAddStatus.InvalidStatus;
        }
    }
}