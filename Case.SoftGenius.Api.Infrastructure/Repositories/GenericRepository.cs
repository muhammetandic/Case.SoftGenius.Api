using System.Linq.Expressions;
using Case.SoftGenius.Api.Application.Abstractions.Data;
using Case.SoftGenius.Api.Domain.Common;
using Case.SoftGenius.Api.Domain.Entities;
using Case.SoftGenius.Api.Domain.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Case.SoftGenius.Api.Infrastructure.Repositories;

public class GenericRepository<TEntity>(AppDbContext appDbContext) : IGenericRepository<TEntity> where TEntity : BaseEntity
{
    private readonly AppDbContext _appDbContext = appDbContext;
    public IQueryable<TEntity> Table => _appDbContext.Set<TEntity>();

    public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        var result = Table.AsQueryable().AsNoTracking();
        if (predicate is not null)
        {
            result.Where(predicate);
        }
        return await result.ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(uint id)
    {
        var result = Table.AsQueryable().AsNoTracking();
        return await result.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<TEntity?> GetOneAsync(Expression<Func<TEntity, bool>>? predicate = null)
    {
        var result = Table.AsQueryable().AsNoTracking();
        if (predicate is not null)
        {
            result = result.Where(predicate);
        }
        return await result.FirstOrDefaultAsync();
    }

    public TEntity Insert(TEntity entity)
    {
        if (entity is null)
        {
            throw new EntityNullException(nameof(entity));
        }

        _appDbContext.Set<TEntity>().Add(entity);
        if (entity is IAuditableEntity auditableEntity)
        {
            auditableEntity.CreatedOn = DateTime.Now;
            auditableEntity.UpdatedOn = null;
        }
        return entity;
    }

    public void Update(TEntity entity)
    {
        if (entity is null)
        {
            throw new EntityNullException(nameof(entity));
        }
        _appDbContext.Entry(entity).State = EntityState.Modified;
        if (entity is IAuditableEntity auditableEntity)
        {
            auditableEntity.UpdatedOn = DateTime.Now;
        }
    }

    public void Delete(uint Id)
    {
        var entity = Table.FirstOrDefault(x => x.Id == Id);
        if (entity is null)
        {
            throw new EntityNullException(nameof(entity));
        }
        _appDbContext.Set<TEntity>().Remove(entity);
    }
}
