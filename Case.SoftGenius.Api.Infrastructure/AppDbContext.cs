using Case.SoftGenius.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Case.SoftGenius.Api.Infrastructure;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users => Set<User>();
    public DbSet<Country> Countries => Set<Country>();
}
