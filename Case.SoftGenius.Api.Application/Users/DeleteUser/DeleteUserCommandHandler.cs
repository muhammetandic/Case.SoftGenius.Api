using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.DeleteUser;

public class DeleteUserCommandHandler(IUnitOfWork unitOfWork, IUserRepository userRepository) : ICommandHandler<DeleteUserCommand, bool>
{
    public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneAsync(x => x.Id == request.Id);
        if (user is null)
        {
            return false;
        }

        userRepository.Delete(user.Id);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return true;
    }
}
