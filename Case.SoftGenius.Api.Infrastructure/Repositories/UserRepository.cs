using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Infrastructure.Repositories;

public class UserRepository(AppDbContext appDbContext) : GenericRepository<User>(appDbContext), IUserRepository
{
}
