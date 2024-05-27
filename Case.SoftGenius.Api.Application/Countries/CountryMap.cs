using AutoMapper;
using Case.SoftGenius.Api.Application.Countries.CreateCountry;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Application.Countries;

public class CountryMap : Profile
{
    public CountryMap()
    {
        CreateMap<CreateCountryCommand, Country>().ReverseMap();
        CreateMap<Country, CountryDto>().ReverseMap();
    }
}
