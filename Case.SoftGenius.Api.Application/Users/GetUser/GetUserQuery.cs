using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.GetUser;

public sealed record GetUserQuery(uint Id) : IQuery<UserDto?>;
