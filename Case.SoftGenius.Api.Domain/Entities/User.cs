namespace Case.SoftGenius.Api.Domain.Entities;

public sealed class User : BaseEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public required bool IsActive { get; set; } = true;
    public uint? CountryId { get; set; }

    public Country? Country { get; set; }
}
