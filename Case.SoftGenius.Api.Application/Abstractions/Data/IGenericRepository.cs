using System.Linq.Expressions;
using Case.SoftGenius.Api.Domain.Common;

namespace Case.SoftGenius.Api.Application.Abstractions.Data;

public interface IGenericRepository<TEntity> where TEntity : IEntity
{
    IQueryable<TEntity> Table { get; }

    Task<(IEnumerable<TEntity> Data, int TotalCount)> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null);

    Task<TEntity?> GetByIdAsync(uint id);

    Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>? predicate = null);

    TEntity Insert(TEntity entity);

    void Update(TEntity entity);

    void Delete(uint Id);
}
