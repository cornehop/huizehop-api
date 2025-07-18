using HuizeHop.Api.Library.Database.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HuizeHop.Api.Library.Database.BaseClasses;

/// <summary>
/// Base repository for entities supporting the CRUD methods
/// </summary>
/// <param name="dbContext">The database context</param>
/// <typeparam name="TEntity">The entity type</typeparam>
public class BaseRepository<TEntity>(DbContext dbContext) : IEntityRepository<TEntity> where TEntity : BaseEntity
{
    public TEntity Create(TEntity entity)
    {
        var result = dbContext.Set<TEntity>().Add(entity);
        dbContext.SaveChanges();
        return result.Entity;
    }

    public TEntity? Read(Guid id)
    {
        return dbContext.Set<TEntity>().Find(id);
    }

    public TEntity Update(TEntity entity)
    {
        var  result = dbContext.Set<TEntity>().Update(entity);
        dbContext.SaveChanges();
        return result.Entity;
    }

    public void Delete(Guid id)
    {
        var entity = dbContext.Set<TEntity>().Find(id);
        if (entity == null)
        {
            return;
        }
        
        dbContext.Set<TEntity>().Remove(entity);
        dbContext.SaveChanges();
    }
}