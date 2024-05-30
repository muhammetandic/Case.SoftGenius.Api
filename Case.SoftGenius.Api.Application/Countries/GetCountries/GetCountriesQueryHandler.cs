using AutoMapper;
using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;
using Case.SoftGenius.Api.Domain.Dtos;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Application.Countries.GetCountries;

public sealed class GetCountriesQueryHandler(IMapper mapper, ICountryRepository countryRepository) : IQueryHandler<GetCountriesQuery, FilteredResult<CountryDto>>
{
    public async Task<FilteredResult<CountryDto>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Country> countries;
        int totalCount;
        if (request.Filter.All)
            (countries, totalCount) = await countryRepository.GetAllAsync();
        else
            (countries, totalCount) = await countryRepository.GetAllAsync(request.Filter);
        var data = mapper.Map<IEnumerable<CountryDto>>(countries);
        return new FilteredResult<CountryDto>(data, totalCount);
    }
}
