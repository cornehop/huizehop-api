using HuizeHop.Api.Library.Database.BaseClasses;

namespace HuizeHop.Api.Library.Database.Interfaces;

/// <summary>
/// Interface for the entity repositories
/// </summary>
/// <typeparam name="TEntity">Type of entity, has to be a BaseEntity</typeparam>
public interface IEntityRepository<TEntity> where TEntity : BaseEntity
{
    /// <summary>
    /// Creates a new entity
    /// </summary>
    /// <param name="entity">The entity to create</param>
    /// <returns>The result of the action</returns>
    public TEntity Create(TEntity entity);
    /// <summary>
    /// Gets the entity for the given <see cref="id"/>
    /// </summary>
    /// <param name="id">The unique identifier of the entity</param>
    /// <returns>The entity with the given identifier</returns>
    public TEntity? Read(Guid id);
    /// <summary>
    /// Updates an existing entity
    /// </summary>
    /// <param name="entity">The entity with updated values</param>
    /// <returns>The result of the action</returns>
    public TEntity Update(TEntity entity);
    /// <summary>
    /// Deletes an existing entity
    /// </summary>
    /// <param name="id">The unique identifier of the entity to delete</param>
    public void Delete(Guid id);
}