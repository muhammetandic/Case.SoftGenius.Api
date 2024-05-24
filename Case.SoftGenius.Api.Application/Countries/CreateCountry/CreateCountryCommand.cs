using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Countries.CreateCountry;

public sealed record CreateCountryCommand(string Name) : ICommand<CountryDto>;