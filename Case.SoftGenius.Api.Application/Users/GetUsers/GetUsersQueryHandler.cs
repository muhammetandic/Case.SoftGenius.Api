using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Application.Abstractions.Messaging;
using Case.SoftGenius.Api.Domain.Dtos;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Application.Users.GetUsers;

public sealed class GetUsersQueryHandler(IUserRepository userRepository) : IQueryHandler<GetUsersQuery, FilteredResult<UserDto>>
{
    public async Task<FilteredResult<UserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<User> users;
        int totalCount;
        if (request.Filter.All)
            (users, totalCount) = await userRepository.GetAllAsync();
        else
            (users, totalCount) = await userRepository.GetAllAsync(request.Filter);

        var data = users.Select(x => new UserDto(
                x.Id,
                x.Name,
                x.Email,
                x.IsActive,
                x.Country?.Name ?? string.Empty
            )).ToList();
        return new FilteredResult<UserDto>(data, totalCount);
    }
}
