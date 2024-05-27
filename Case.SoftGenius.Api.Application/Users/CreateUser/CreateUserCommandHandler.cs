using AutoMapper;
using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Application.Users.CreateUser;

public sealed class CreateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository) : ICommandHandler<CreateUserCommand, UserDto>
{
    public async Task<UserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = mapper.Map<User>(request);
        userRepository.Insert(user);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        return mapper.Map<UserDto>(user);
    }
}
