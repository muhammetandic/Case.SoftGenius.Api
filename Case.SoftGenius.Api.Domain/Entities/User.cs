namespace Case.SoftGenius.Api.Domain.Entities;

public sealed class User : BaseEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string Password { get; set; } = string.Empty;
}
