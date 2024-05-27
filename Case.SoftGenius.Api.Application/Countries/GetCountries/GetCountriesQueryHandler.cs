using AutoMapper;
using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Countries.GetCountries;

public sealed class GetCountriesQueryHandler(IMapper mapper, ICountryRepository countryRepository) : IQueryHandler<GetCountriesQuery, IEnumerable<CountryDto>>
{
    public async Task<IEnumerable<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        var countries = await countryRepository.GetAllAsync();
        return mapper.Map<IEnumerable<CountryDto>>(countries);
    }
}
