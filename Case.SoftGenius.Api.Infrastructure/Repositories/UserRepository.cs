using System.Linq.Expressions;
using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Case.SoftGenius.Api.Infrastructure.Repositories;

public class UserRepository(AppDbContext appDbContext) : GenericRepository<User>(appDbContext), IUserRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public new async Task<IList<User>> GetAllAsync(Expression<Func<User, bool>>? predicate = null)
    {
        var result = _appDbContext.Users.Include(x => x.Country).AsQueryable().AsNoTracking();
        if (predicate is not null)
        {
            result = result.Where(predicate);
        }
        return await result.ToListAsync();
    }

    public new async Task<User?> GetOneAsync(Expression<Func<User, bool>>? predicate = null)
    {
        var result = _appDbContext.Users.Include(x => x.Country).AsQueryable().AsNoTracking();
        if (predicate is not null)
        {
            result = result.Where(predicate);
        }
        return await result.FirstOrDefaultAsync();
    }

    public new async Task<User?> GetByIdAsync(uint id)
    {
        var result = _appDbContext.Users.Include(x => x.Country).AsQueryable().AsNoTracking();
        return await result.FirstOrDefaultAsync(x => x.Id == id);
    }
}
