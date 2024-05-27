using AutoMapper;
using Case.SoftGenius.Api.Application.Users.CreateUser;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Application.Users;

public class UserMap : Profile
{
    public UserMap()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<CreateUserCommand, User>().ReverseMap();
    }
}
