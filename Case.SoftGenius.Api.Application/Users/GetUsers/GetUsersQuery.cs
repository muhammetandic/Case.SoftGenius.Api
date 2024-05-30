using Case.SoftGenius.Api.Application.Abstractions.Messaging;
using Case.SoftGenius.Api.Domain.Dtos;

namespace Case.SoftGenius.Api.Application.Users.GetUsers;

public sealed record GetUsersQuery(QueryFilter Filter) : IQuery<FilteredResult<UserDto>>;
