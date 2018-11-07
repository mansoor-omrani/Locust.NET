using Locust.Calendar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locust.Repository.EF
{
    public class EntityBase<PK> : IEntity<PK>
    {
        public PK Id { get; set; }
    }
    public class RecoverableEntity<PK> : EntityBase<PK>, IRecoverableEntity
    {
        public bool IsDeleted { get; set; }
    }
    public class RowVersionedEntity<PK> : EntityBase<PK>, IRowVesionedEntity
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
    public class RecoverableRowVersionedEntity<PK> : EntityBase<PK>, IRecoverableEntity, IRowVesionedEntity
    {
        public bool IsDeleted { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
    public class AuditedEntity<PK, TUserEntity, TUserFK>: EntityBase<PK>, IAuditedEntity<TUserEntity, TUserFK>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        public TUserFK CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public virtual TUserEntity CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public TUserFK ModifiedById { get; set; }
        [ForeignKey(nameof(ModifiedById))]
        public virtual TUserEntity ModifiedBy { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
    public interface IEntityBase<PK, TUserEntity, TUserFK>: IEntity<PK>, IRecoverableEntity, IRowVesionedEntity, IAuditedEntity<TUserEntity, TUserFK>
    {

    }
    public class EntityBase<PK, TUserEntity, TUserFK> : EntityBase<PK>, IEntityBase<PK, TUserEntity, TUserFK>
    {
        public bool IsDeleted { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }
        private DateTimeField _createdDate;
        [JsonIgnore]
        public DateTimeField CreatedDateField
        {
            get
            {
                if (_createdDate == null)
                {
                    _createdDate = new DateTimeField();
                }

                _createdDate.Gregorian.Read(CreatedDate);

                return _createdDate;
            }
        }
        public TUserFK CreatedById { get; set; }
        [ForeignKey(nameof(CreatedById))]
        public virtual TUserEntity CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        private DateTimeField _modifiedDate;
        [JsonIgnore]
        public DateTimeField ModifiedDateField
        {
            get
            {
                if (_modifiedDate == null)
                {
                    _modifiedDate = new DateTimeField();
                }

                if (ModifiedDate.HasValue)
                {
                    _modifiedDate.Gregorian.Read(ModifiedDate.Value);
                }

                return _modifiedDate;
            }
        }
        public TUserFK ModifiedById { get; set; }
        [ForeignKey(nameof(ModifiedById))]
        public virtual TUserEntity ModifiedBy { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
}
