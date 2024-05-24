using AutoMapper;
using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Application.Countries.CreateCountry;

public sealed class CreateCountryCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    ICountryRepository countryRepository) : ICommandHandler<CreateCountryCommand, CountryDto>
{

    public async Task<CountryDto> Handle(CreateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = mapper.Map<Country>(request);

        var result = countryRepository.Insert(country);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<CountryDto>(result);
    }
}
