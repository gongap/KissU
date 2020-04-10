using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using KissU.Core.Datas;
using KissU.Util.Ddd.Domain;
using KissU.Util.Ddd.Domain.Datas.Repositories;

namespace KissU.Util.Tests.Samples
{
    /// <summary>
    /// 实体样例
    /// </summary>
    [DisplayName("实体样例")]
    public class EntitySample : AggregateRoot<EntitySample>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntitySample" /> class.
        /// </summary>
        public EntitySample() : this(Guid.NewGuid())
        {
        }

        /// <summary>
        /// 初始化聚合根
        /// </summary>
        /// <param name="id">标识</param>
        public EntitySample(Guid id) : base(id)
        {
        }

        /// <summary>
        /// 名称
        /// </summary>
        [Required(ErrorMessage = "名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 忽略值
        /// </summary>
        [IgnoreMap]
        public string IgnoreValue { get; set; }
    }

    /// <summary>
    /// 仓储样例
    /// </summary>
    public interface IRepositorySample : IRepository<EntitySample>
    {
    }

    /// <summary>
    /// 仓储样例
    /// </summary>
    public class RepositorySample : IRepositorySample
    {
        /// <summary>
        /// Finds this instance.
        /// </summary>
        /// <returns>IQueryable&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<EntitySample> Find()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds as no tracking.
        /// </summary>
        /// <returns>IQueryable&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<EntitySample> FindAsNoTracking()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>IQueryable&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<EntitySample> Find(ICriteria<EntitySample> criteria)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>IQueryable&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<EntitySample> Find(Expression<Func<EntitySample, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EntitySample.</returns>
        public EntitySample Find(object id)
        {
            return new EntitySample();
        }

        /// <summary>
        /// Finds the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> FindByIds(params Guid[] ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> FindByIds(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> FindByIds(string ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> FindByIdsAsync(params Guid[] ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> FindByIdsAsync(IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> FindByIdsAsync(string ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Singles the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>EntitySample.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public EntitySample Single(Expression<Func<EntitySample, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Singles the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<EntitySample> SingleAsync(Expression<Func<EntitySample, bool>> predicate,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds all.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> FindAll(Expression<Func<EntitySample, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds all asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> FindAllAsync(Expression<Func<EntitySample, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Existses the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Exists(Expression<Func<EntitySample, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Existses the specified ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Exists(params Guid[] ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Existses the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> ExistsAsync(Expression<Func<EntitySample, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Existses the asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<bool> ExistsAsync(params Guid[] ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Counts the specified predicate.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>System.Int32.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Count(Expression<Func<EntitySample, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Counts the asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<int> CountAsync(Expression<Func<EntitySample, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Queries the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> Query(IQueryBase<EntitySample> query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Queries the asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> QueryAsync(IQueryBase<EntitySample> query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Queries as no tracking.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> QueryAsNoTracking(IQueryBase<EntitySample> query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Queries as no tracking asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> QueryAsNoTrackingAsync(IQueryBase<EntitySample> query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pagers the query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>PagerList&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public PagerList<EntitySample> PagerQuery(IQueryBase<EntitySample> query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pagers the query asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Task&lt;PagerList&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<PagerList<EntitySample>> PagerQueryAsync(IQueryBase<EntitySample> query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pagers the query as no tracking.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>PagerList&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public PagerList<EntitySample> PagerQueryAsNoTracking(IQueryBase<EntitySample> query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Pagers the query as no tracking asynchronous.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>Task&lt;PagerList&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<PagerList<EntitySample>> PagerQueryAsNoTrackingAsync(IQueryBase<EntitySample> query)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Add(EntitySample entity)
        {
        }

        /// <summary>
        /// Adds the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Add(IEnumerable<EntitySample> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task AddAsync(EntitySample entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task AddAsync(IEnumerable<EntitySample> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        public void Update(EntitySample entity)
        {
        }

        /// <summary>
        /// Updates the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Update(IEnumerable<EntitySample> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UpdateAsync(EntitySample entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates the asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task UpdateAsync(IEnumerable<EntitySample> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Remove(object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Remove(EntitySample entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveAsync(object id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveAsync(EntitySample entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified ids.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Remove(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Remove(IEnumerable<EntitySample> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveAsync(IEnumerable<EntitySample> entities, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<EntitySample> FindAsync(object id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by identifier no tracking.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>EntitySample.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public EntitySample FindByIdNoTracking(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by identifier no tracking asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<EntitySample> FindByIdNoTrackingAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids no tracking.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> FindByIdsNoTracking(params Guid[] ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids no tracking.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> FindByIdsNoTracking(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids no tracking.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> FindByIdsNoTracking(string ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids no tracking asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> FindByIdsNoTrackingAsync(params Guid[] ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids no tracking asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> FindByIdsNoTrackingAsync(IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids no tracking asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> FindByIdsNoTrackingAsync(string ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds all no tracking.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>List&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<EntitySample> FindAllNoTracking(Expression<Func<EntitySample, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds all no tracking asynchronous.
        /// </summary>
        /// <param name="predicate">The predicate.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> FindAllNoTrackingAsync(Expression<Func<EntitySample, bool>> predicate = null)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<EntitySample> FindAsync(object id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the by ids asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>Task&lt;List&lt;EntitySample&gt;&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task<List<EntitySample>> FindByIdsAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Orders the by.
        /// </summary>
        /// <param name="queryable">The queryable.</param>
        /// <param name="orderBy">The order by.</param>
        /// <returns>IQueryable&lt;EntitySample&gt;.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IQueryable<EntitySample> OrderBy(IQueryable<EntitySample> queryable, string orderBy)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task AddAsync(EntitySample entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Adds the asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task AddAsync(IEnumerable<EntitySample> entities)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the specified identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <exception cref="NotImplementedException"></exception>
        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveAsync(EntitySample entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="ids">The ids.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveAsync(IEnumerable<Guid> ids)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes the asynchronous.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Task.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task RemoveAsync(IEnumerable<EntitySample> entities)
        {
            throw new NotImplementedException();
        }
    }
}