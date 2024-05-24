using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Domain.Entities;

namespace Case.SoftGenius.Api.Infrastructure.Repositories;

public class CountryRepository(AppDbContext appDbContext) : GenericRepository<Country>(appDbContext), ICountryRepository
{
}
