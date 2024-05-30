using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Domain.Dtos;
using Case.SoftGenius.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Case.SoftGenius.Api.Infrastructure.Repositories;

public class CountryRepository(AppDbContext appDbContext) : GenericRepository<Country>(appDbContext), ICountryRepository
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task<(IEnumerable<Country> Data, int TotalCount)> GetAllAsync(QueryFilter filter)
    {
        var data = await _appDbContext.Countries
            .Skip(filter.Page * filter.PageSize)
            .Take(filter.PageSize)
            .AsNoTracking()
            .ToListAsync();
        var totalCount = await _appDbContext.Countries.CountAsync();
        return (data, totalCount);
    }
}
