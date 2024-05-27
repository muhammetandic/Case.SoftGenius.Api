﻿using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Countries.GetCountries;

public sealed record GetCountriesQuery() : IQuery<IEnumerable<CountryDto>>;
