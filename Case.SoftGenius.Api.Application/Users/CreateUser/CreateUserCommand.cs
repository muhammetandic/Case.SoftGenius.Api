using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.CreateUser;

public sealed record class CreateUserCommand(string Name, string Email, uint CountryId) : ICommand<UserDto>;
