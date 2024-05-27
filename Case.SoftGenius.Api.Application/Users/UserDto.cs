namespace Case.SoftGenius.Api.Application.Users;

public sealed record UserDto(uint? Id, string Name, string Email, bool IsActive, string CountryName);
