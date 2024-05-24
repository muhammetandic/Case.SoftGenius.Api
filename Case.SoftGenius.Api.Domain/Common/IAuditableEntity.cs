namespace Case.SoftGenius.Api.Domain.Common;

public interface IAuditableEntity
{
    DateTime CreatedOn { get; set; }
    DateTime? UpdatedOn { get; set; }
}
