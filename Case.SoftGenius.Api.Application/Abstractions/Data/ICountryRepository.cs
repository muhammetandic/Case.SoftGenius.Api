using Case.SoftGenius.Api.Domain.Dtos;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Application.Abstractions.Data;

public interface ICountryRepository : IGenericRepository<Country>
{
    Task<(IEnumerable<Country> Data, int TotalCount)> GetAllAsync(QueryFilter filter);
}