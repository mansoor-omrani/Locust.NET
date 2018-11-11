using System;
using Locust.ServiceModel;

namespace Locust.Modules.ACL.Strategies
{
    public partial class RoleCategoryGetByIdResponse : BaseServiceResponse<Model.RoleCategory, RoleCategoryGetByIdStatus>
    {
        public override bool IsSuccessfull()
        {
            return Status == RoleCategoryGetByIdStatus.Success;
        }
        public override bool IsFailed()
        {
            return Status == RoleCategoryGetByIdStatus.Failed;
        }
        public override bool IsErrored()
        {
            return Status == RoleCategoryGetByIdStatus.Errored;
        }
        public override bool IsFaulted()
        {
            return Status == RoleCategoryGetByIdStatus.Faulted;
        }
        public RoleCategoryGetByIdResponse()
            : base(RoleCategoryGetByIdStatus.None, default(Model.RoleCategory))
        { }
        public RoleCategoryGetByIdResponse(RoleCategoryGetByIdStatus status, Model.RoleCategory data)
            : base(status, data)
        { }
        public override void Faulted()
        {
            this.Status = RoleCategoryGetByIdStatus.Faulted;
        }
        public override void Succeeded()
        {
            this.Status = RoleCategoryGetByIdStatus.Success;
        }
        public override void Failed()
        {
            this.Status = RoleCategoryGetByIdStatus.Failed;
        }
        public override void Errored()
        {
            this.Status = RoleCategoryGetByIdStatus.Errored;
        }
        public override bool SetStatus(object status)
        {
            var result = RoleCategoryGetByIdStatus.None;

            if (status == null || !Enum.TryParse(status.ToString(), true, out result))
            {
                result = RoleCategoryGetByIdStatus.InvalidStatus;
            }

            this.Status = result;
            return this.Status != RoleCategoryGetByIdStatus.InvalidStatus;
        }

        public override void NotFound()
        {
            this.Status = RoleCategoryGetByIdStatus.NotFound;
        }
    }
}
