using Case.SoftGenius.Api.Application.Abstractions.Data;

namespace Case.SoftGenius.Api.Infrastructure;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private readonly AppDbContext _appDbContext = appDbContext;

    public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await _appDbContext.SaveChangesAsync(cancellationToken);
    }
}
