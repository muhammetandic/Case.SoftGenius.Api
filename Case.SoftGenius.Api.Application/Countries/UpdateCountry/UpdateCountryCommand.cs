using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Countries.UpdateCountry;

public sealed record UpdateCountryCommand(uint Id, string Name) : ICommand<bool>;
