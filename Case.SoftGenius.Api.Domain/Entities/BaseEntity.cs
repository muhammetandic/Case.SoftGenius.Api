using Case.SoftGenius.Api.Domain.Common;

namespace Case.SoftGenius.Api.Domain.Entities;

public abstract class BaseEntity : IEntity, IAuditableEntity
{
    public uint Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public DateTime? UpdatedOn { get; set; }
}
