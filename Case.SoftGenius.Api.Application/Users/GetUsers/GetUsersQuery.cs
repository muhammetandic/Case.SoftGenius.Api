using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.GetUsers;

public sealed record GetUsersQuery : IQuery<IEnumerable<UserDto>>;
