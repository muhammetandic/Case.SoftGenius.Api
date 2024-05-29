using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.DeleteUser;

public record DeleteUserCommand(uint Id) : ICommand<bool>;
