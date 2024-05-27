using AutoMapper;
using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;

namespace Case.SoftGenius.Api.Application.Users.GetUser;

public sealed class GetUserQueryHandler(IMapper mapper, IUserRepository userRepository) : IQueryHandler<GetUserQuery, UserDto?>
{
    public async Task<UserDto?> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetOneAsync(x => x.Id == request.Id);
        if (user is null)
        {
            return null;
        }
        return mapper.Map<UserDto>(user);
    }
}
