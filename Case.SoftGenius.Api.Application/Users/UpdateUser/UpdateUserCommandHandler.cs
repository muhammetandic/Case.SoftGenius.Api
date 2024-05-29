using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.UpdateUser;

public sealed class UpdateUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : ICommandHandler<UpdateUserCommand, bool>
{
    public async Task<bool> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneAsync(x => x.Id == request.Id);
        if (user is null)
        {
            return false;
        }
        user.Name = request.Name;
        user.Email = request.Email;
        user.CountryId = request.CountryId;

        userRepository.Update(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
