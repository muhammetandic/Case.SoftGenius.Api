using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Countries.SetCountryAsInactive;

public sealed record SetCountryAsInactiveCommand(uint Id) : ICommand<bool>;