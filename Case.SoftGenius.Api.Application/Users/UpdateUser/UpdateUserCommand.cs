using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.UpdateUser;

public sealed record UpdateUserCommand(uint Id, string Name, string Email, uint? CountryId) : ICommand<bool>;

