namespace Case.SoftGenius.Api.Domain.Entities;

public sealed class Country : BaseEntity
{
    public required string Name { get; set; }
    public required bool IsActive { get; set; } = true;

    public IList<User> Users { get; set; } = [];
}
