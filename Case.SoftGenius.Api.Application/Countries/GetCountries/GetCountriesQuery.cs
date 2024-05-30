using Case.SoftGenius.Api.Application.Abstractions.Messaging;
using Case.SoftGenius.Api.Domain.Dtos;

namespace Case.SoftGenius.Api.Application.Countries.GetCountries;

public sealed record GetCountriesQuery(QueryFilter Filter) : IQuery<FilteredResult<CountryDto>>;
