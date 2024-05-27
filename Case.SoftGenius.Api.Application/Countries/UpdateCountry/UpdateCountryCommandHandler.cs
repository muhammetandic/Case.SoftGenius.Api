using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Countries.UpdateCountry;

public sealed class UpdateCountryCommandHandler(IUnitOfWork unitOfWork, ICountryRepository countryRepository) : ICommandHandler<UpdateCountryCommand, bool>
{
    public async Task<bool> Handle(UpdateCountryCommand request, CancellationToken cancellationToken)
    {
        var country = await countryRepository.GetOneAsync(x => x.Id == request.Id);
        if (country is null)
        {
            return false;
        }
        country.Name = request.Name;
        countryRepository.Update(country);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
