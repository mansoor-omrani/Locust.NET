using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Repository.EF
{
    public interface IEntity<PK>
    {
        PK Id { get; set; }
    }
    public interface IRecoverableEntity
    {
        bool IsDeleted { get; set; }
    }
    public interface IRowVesionedEntity
    {
        byte[] RowVersion { get; set; }
    }
    public interface IAuditedEntity<TUserEntity, TUserFK>
    {
        DateTime CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        TUserFK CreatedById { get; set; }
        TUserEntity CreatedBy { get; set; }
        TUserFK ModifiedById { get; set; }
        TUserEntity ModifiedBy { get; set; }
        string CreatedByName { get; set; }
        string ModifiedByName { get; set; }
    }
}
