using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace KissU.Core.System.MongoProvider.Repositories
{
    /// <summary>
    /// MongoRepository.
    /// Implements the <see cref="KissU.Core.System.MongoProvider.Repositories.IMongoRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <seealso cref="KissU.Core.System.MongoProvider.Repositories.IMongoRepository{T}" />
    public class MongoRepository<T> : IMongoRepository<T>
            where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoRepository{T}"/> class.
        /// </summary>
        public MongoRepository()
            : this(Util.GetDefaultConnectionString())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoRepository{T}"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public MongoRepository(string connectionString)
        {
            _collection = Util.GetCollectionFromConnectionString<T>(Util.GetDefaultConnectionString());
        }

        /// <summary>
        /// Gets the collection.
        /// </summary>
        public IMongoCollection<T> Collection
        {
            get { return _collection; }
        }

        /// <summary>
        /// Gets the by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>T.</returns>
        public T GetById(string id)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Eq("_id", ObjectId.Parse(id));
            return _collection.Find(filter).FirstOrDefault();
        }

        /// <summary>
        /// Gets the single.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>T.</returns>
        public T GetSingle(Expression<Func<T, bool>> criteria)
        {
            return _collection.Find(criteria).FirstOrDefault();
        }

        /// <summary>
        /// get single as an asynchronous operation.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> criteria)
        {
            var result = await _collection.FindSync(criteria).FirstOrDefaultAsync();
            return result;
        }

        /// <summary>
        /// Gets the page desc.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="descSort">The desc sort.</param>
        /// <param name="pParams">The p parameters.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public List<T> GetPageDesc(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> descSort, QueryParams pParams)
        {
            var sort = new SortDefinitionBuilder<T>();
            var result = _collection.Find(criteria).Sort(sort.Descending(descSort)).Skip((pParams.Index - 1) * pParams.Size).Limit(
                            pParams.Size).ToList();
            return result;
        }

        /// <summary>
        /// Gets the page asc.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="ascSort">The asc sort.</param>
        /// <param name="pParams">The p parameters.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public List<T> GetPageAsc(Expression<Func<T, bool>> criteria, Expression<Func<T, object>> ascSort, QueryParams pParams)
        {
            var sort = new SortDefinitionBuilder<T>();
            var result = _collection.Find(criteria).Sort(sort.Ascending(ascSort)).Skip((pParams.Index - 1) * pParams.Size).Limit(
                            pParams.Size).ToList();
            return result;
        }

        /// <summary>
        /// get list as an asynchronous operation.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Task&lt;List&lt;T&gt;&gt;.</returns>
        public async Task<List<T>> GetListAsync(Expression<Func<T, bool>> criteria)
        {
            var result = await _collection.FindSync(criteria).ToListAsync();
            return result;
        }

        /// <summary>
        /// Gets the list.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>List&lt;T&gt;.</returns>
        public List<T> GetList(Expression<Func<T, bool>> criteria)
        {
            var result = _collection.Find(criteria).ToList();
            return result;
        }

        /// <summary>
        /// Alls this instance.
        /// </summary>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> All()
        {
            return _collection.AsQueryable();
        }

        /// <summary>
        /// Alls the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>IQueryable&lt;T&gt;.</returns>
        public IQueryable<T> All(Expression<Func<T, bool>> criteria)
        {
            return _collection.AsQueryable().Where(criteria);
        }

        /// <summary>
        /// Adds the specified entity.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public T Add(T entity)
        {
            try
            {
                _collection.InsertOne(entity);
                return entity;
            }
            catch
            {
                return default(T);
            }
        }

        /// <summary>
        /// add as an asynchronous operation.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> AddAsync(T entity)
        {
            var result = true;
            try
            {
                await _collection.InsertOneAsync(entity);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Adds the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Add(IEnumerable<T> entities)
        {
            var result = true;
            try
            {
                _collection.InsertMany(entities);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// add many as an asynchronous operation.
        /// </summary>
        /// <param name="entities">The entities.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> AddManyAsync(IEnumerable<T> entities)
        {
            var result = true;
            try
            {
                await _collection.InsertManyAsync(entities);
            }
            catch
            {
                result = false;
            }
            return result;
        }

        /// <summary>
        /// Updates the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>UpdateResult.</returns>
        public UpdateResult Update(FilterDefinition<T> filter, UpdateDefinition<T> entity)
        {
            return _collection.UpdateOne(filter, entity, new UpdateOptions()
            {
                IsUpsert = true,
                BypassDocumentValidation = true,
            });
        }

        /// <summary>
        /// update as an asynchronous operation.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;UpdateResult&gt;.</returns>
        public async Task<UpdateResult> UpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> entity)
        {
            var result = await _collection.UpdateOneAsync(filter, entity);
            return result;
        }

        /// <summary>
        /// Updates the many.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>UpdateResult.</returns>
        public UpdateResult UpdateMany(FilterDefinition<T> filter, UpdateDefinition<T> entity)
        {
            return _collection.UpdateMany(filter, entity);
        }

        /// <summary>
        /// update many as an asynchronous operation.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;UpdateResult&gt;.</returns>
        public async Task<UpdateResult> UpdateManyAsync(FilterDefinition<T> filter, UpdateDefinition<T> entity)
        {
            var result = await _collection.UpdateManyAsync(filter, entity);
            return result;
        }

        /// <summary>
        /// Finds the one and update.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>T.</returns>
        public T FindOneAndUpdate(FilterDefinition<T> filter, UpdateDefinition<T> entity)
        {
            var result = _collection.FindOneAndUpdate(filter, entity);
            return result;
        }

        /// <summary>
        /// find one and update as an asynchronous operation.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="entity">The entity.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> FindOneAndUpdateAsync(FilterDefinition<T> filter, UpdateDefinition<T> entity)
        {
            var result = await _collection.FindOneAndUpdateAsync(filter, entity);
            return result;
        }

        /// <summary>
        /// Deletes the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>DeleteResult.</returns>
        public DeleteResult Delete(FilterDefinition<T> filter)
        {
            return _collection.DeleteOne(filter);
        }

        /// <summary>
        /// delete as an asynchronous operation.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;DeleteResult&gt;.</returns>
        public async Task<DeleteResult> DeleteAsync(FilterDefinition<T> filter)
        {
            var result = await _collection.DeleteOneAsync(filter);
            return result;
        }

        /// <summary>
        /// Deletes the many.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>DeleteResult.</returns>
        public DeleteResult DeleteMany(FilterDefinition<T> filter)
        {
            var result = _collection.DeleteMany(filter);
            return result;
        }

        /// <summary>
        /// delete many as an asynchronous operation.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;DeleteResult&gt;.</returns>
        public async Task<DeleteResult> DeleteManyAsync(FilterDefinition<T> filter)
        {
            var result = await _collection.DeleteManyAsync(filter);
            return result;
        }

        /// <summary>
        /// Finds the one and delete.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>T.</returns>
        public T FindOneAndDelete(Expression<Func<T, bool>> criteria)
        {
            var result = _collection.FindOneAndDelete(criteria);
            return result;
        }

        /// <summary>
        /// find one and delete as an asynchronous operation.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> FindOneAndDeleteAsync(Expression<Func<T, bool>> criteria)
        {
            var result = await _collection.FindOneAndDeleteAsync(criteria);
            return result;
        }


        /// <summary>
        /// Counts the specified filter.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>System.Int64.</returns>
        public long Count(FilterDefinition<T> filter)
        {
            var result = _collection.Count(filter);
            return result;
        }

        /// <summary>
        /// count as an asynchronous operation.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <returns>Task&lt;System.Int64&gt;.</returns>
        public async Task<long> CountAsync(FilterDefinition<T> filter)
        {
            var result = await _collection.CountAsync(filter);
            return result;
        }

        /// <summary>
        /// Existses the specified criteria.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <param name="exists">if set to <c>true</c> [exists].</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Exists(Expression<Func<T, object>> criteria, bool exists)
        {
            var builder = Builders<T>.Filter;
            var filter = builder.Exists(criteria, exists);
            return _collection.Find(filter).Any();
        }
    }
}
