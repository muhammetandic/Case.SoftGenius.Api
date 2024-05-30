namespace Case.SoftGenius.Api.Domain.Dtos;

public sealed record FilteredResult<TEntity>(IEnumerable<TEntity> Data, int TotalCount);
