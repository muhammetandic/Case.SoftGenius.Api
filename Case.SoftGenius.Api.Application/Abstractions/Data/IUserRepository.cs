using Case.SoftGenius.Api.Domain.Dtos;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Application.Abstractions.Data;

public interface IUserRepository : IGenericRepository<User>
{
    Task<(IEnumerable<User> Data, int TotalCount)> GetAllAsync(QueryFilter filter);
}