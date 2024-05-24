namespace Case.SoftGenius.Api.Application.Abstractions.Data;

public interface IUnitOfWork
{
    Task SaveChangesAsync(CancellationToken cancellationToken = default);
}
