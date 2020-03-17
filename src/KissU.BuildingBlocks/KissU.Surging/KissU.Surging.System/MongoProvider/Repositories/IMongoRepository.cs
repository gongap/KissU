using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace KissU.Surging.System.MongoProvider.Repositories
{
    /// <summary>
    /// Interface IMongoRepository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMongoRepository<T> where T : IEntity
    {
        /// <summary>
        /// Gets the collection.
        /// </summary>
        IMongoCollection<T> Collection { get; }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        T GetById(string id);

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>T.</returns>
        T GetSingle(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// Gets the single asynchronous.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> GetSingleAsync(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// Gets the list asynchronous.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Task&lt;List&lt;T&gt;&gt;.</returns>
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>List&lt;T&gt;.</returns>
        List<T> GetList(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> All();

        /// <summary>
        /// Alls the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        IQueryable<T> All(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        T Add(T entity);

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> AddAsync(T entity);

        /// <summary>
        /// Adds the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Add(IEnumerable<T> entities);

        /// <summary>
        /// Adds the many asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> AddManyAsync(IEnumerable<T> entities);

        /// <summary>
        /// Updates the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>UpdateResult.</returns>
        UpdateResult Update(FilterDefinition<T> filter, UpdateDefinition<T> entity);

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;UpdateResult&gt;.</returns>
        Task<UpdateResult> UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> entity);

        /// <summary>
        /// Updates the many.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>UpdateResult.</returns>
        UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> entity);

        /// <summary>
        /// Updates the many asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;UpdateResult&gt;.</returns>
        Task<UpdateResult> UpdateManyAsync(FilterDefinition<T> filter, UpdateDefinition<T> entity);

        /// <summary>
        /// Finds the one and update.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        T FindOneAndUpdate(FilterDefinition<T> filter, UpdateDefinition<T> entity);

        /// <summary>
        /// Finds the one and update asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> FindOneAndUpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> entity);

        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>DeleteResult.</returns>
        DeleteResult Delete(FilterDefinition<T> filter);

        /// <summary>
        /// Deletes the asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;DeleteResult&gt;.</returns>
        Task<DeleteResult> DeleteAsync(FilterDefinition<T> filter);

        /// <summary>
        /// Deletes the many.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>DeleteResult.</returns>
        DeleteResult DeleteMany(FilterDefinition<T> filter);

        /// <summary>
        /// Deletes the many asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;DeleteResult&gt;.</returns>
        Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter);

        /// <summary>
        /// Gets the page asc.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="ascSort">The asc sort.</param>
        /// <param name="pParams">The p parameters.</param>
        /// <returns>List&lt;T&gt;.</returns>
        List<T> GetPageAsc(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> ascSort,
            QueryParams pParams);

        /// <summary>
        /// Gets the page desc.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="descSort">The desc sort.</param>
        /// <param name="pParams">The p parameters.</param>
        /// <returns>List&lt;T&gt;.</returns>
        List<T> GetPageDesc(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> descSort,
            QueryParams pParams);

        /// <summary>
        /// Finds the one and delete.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>T.</returns>
        T FindOneAndDelete(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// Finds the one and delete asynchronous.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> FindOneAndDeleteAsync(Expression<Func<T, bool>> criteria);

        /// <summary>
        /// Counts the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>System.Int64.</returns>
        long Count(FilterDefinition<T> filter);

        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;System.Int64&gt;.</returns>
        Task<long> CountAsync(FilterDefinition<T> filter);

        /// <summary>
        /// Existses the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="exists">if set to <c>true</c> [exists].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Exists(Expression<Func<T, object>> criteria, bool exists);
    }
}