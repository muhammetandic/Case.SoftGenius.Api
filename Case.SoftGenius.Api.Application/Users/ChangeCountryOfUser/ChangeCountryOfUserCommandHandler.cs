using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.ChangeCountryOfUser;

public class ChangeCountryOfUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : ICommandHandler<ChangeCountryOfUserCommand, bool>
{
    public async Task<bool> Handle(ChangeCountryOfUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(request.UserId);
        if (user is null)
        {
            return false;
        }

        user.CountryId = request.CountryId;
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
