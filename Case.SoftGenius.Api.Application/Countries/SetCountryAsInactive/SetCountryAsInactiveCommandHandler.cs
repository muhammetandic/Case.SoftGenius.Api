using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Countries.SetCountryAsInactive;

public sealed class SetCountryAsInactiveCommandHandler(IUnitOfWork unitOfWork, ICountryRepository countryRepository) : ICommandHandler<SetCountryAsInactiveCommand, bool>
{
    public async Task<bool> Handle(SetCountryAsInactiveCommand request, CancellationToken cancellationToken)
    {
        var country = await countryRepository.GetOneAsync(x => x.Id == request.Id);
        if (country is null)
        {
            return false;
        }
        country.IsActive = false;
        countryRepository.Update(country);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
