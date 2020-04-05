using System;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Core.Logs;
using KissU.Util.Ddd.Domains;

namespace KissU.Util.Applications
{
    /// <summary>
    /// 增删改查服务 - Save
    /// </summary>
    /// <typeparam name="TEntity">The type of the t entity.</typeparam>
    /// <typeparam name="TDto">The type of the t dto.</typeparam>
    /// <typeparam name="TRequest">The type of the t request.</typeparam>
    /// <typeparam name="TCreateRequest">The type of the t create request.</typeparam>
    /// <typeparam name="TUpdateRequest">The type of the t update request.</typeparam>
    /// <typeparam name="TQueryParameter">The type of the t query parameter.</typeparam>
    /// <typeparam name="TKey">The type of the t key.</typeparam>
    public abstract partial class CrudServiceBase<TEntity, TDto, TRequest, TCreateRequest, TUpdateRequest,
        TQueryParameter, TKey>
    {
        /// <summary>
        /// 提交后操作 - 该方法由工作单元拦截器调用
        /// </summary>
        public void CommitAfter()
        {
            SaveAfter();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>结果</returns>
        /// <exception cref="ArgumentNullException">request</exception>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual string Create(TCreateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = ToEntityFromCreateRequest(request);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Create(entity);
            return entity.Id.ToString();
        }

        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="request">创建参数</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">request</exception>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual async Task<string> CreateAsync(TCreateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = ToEntityFromCreateRequest(request);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await CreateAsync(entity);
            return entity.Id.ToString();
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <exception cref="ArgumentNullException">request</exception>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual void Update(TUpdateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = ToEntityFromUpdateRequest(request);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Update(entity);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="request">修改参数</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">request</exception>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual async Task UpdateAsync(TUpdateRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var entity = ToEntityFromUpdateRequest(request);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await UpdateAsync(entity);
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="request">参数</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">request</exception>
        /// <exception cref="ArgumentNullException">entity</exception>
        public virtual async Task SaveAsync(TRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            SaveBefore(request);
            var entity = ToEntity(request);
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            if (IsNew(request, entity))
            {
                await CreateAsync(entity);
                request.Id = entity.Id.ToString();
            }
            else
                await UpdateAsync(entity);
        }

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected void Create(TEntity entity)
        {
            CreateBefore(entity);
            entity.Init();
            _repository.Add(entity);
            CreateAfter(entity);
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void CreateBefore(TEntity entity)
        {
        }

        /// <summary>
        /// 创建后操作
        /// </summary>
        /// <param name="entity">The entity.</param>
        protected virtual void CreateAfter(TEntity entity)
        {
            AddLog(entity);
        }

        /// <summary>
        /// 创建实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        protected async Task CreateAsync(TEntity entity)
        {
            CreateBefore(entity);
            await CreateBeforeAsync(entity);
            entity.Init();
            await _repository.AddAsync(entity);
            CreateAfter(entity);
            await CreateAfterAsync(entity);
        }

        /// <summary>
        /// 创建前操作
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        protected virtual Task CreateBeforeAsync(TEntity entity)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 创建后操作
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        protected virtual Task CreateAfterAsync(TEntity entity)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <exception cref="ArgumentNullException">oldEntity</exception>
        protected void Update(TEntity entity)
        {
            var oldEntity = FindOldEntity(entity.Id);
            if (oldEntity == null)
            {
                throw new ArgumentNullException(nameof(oldEntity));
            }

            var changes = oldEntity.GetChanges(entity);
            UpdateBefore(entity);
            _repository.Update(entity);
            UpdateAfter(entity, changes);
        }

        /// <summary>
        /// 查找旧实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>结果</returns>
        protected virtual TEntity FindOldEntity(TKey id)
        {
            return _repository.Find(id);
        }

        /// <summary>
        /// 查找旧实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        protected virtual async Task<TEntity> FindOldEntityAsync(TKey id)
        {
            return await _repository.FindAsync(id);
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual void UpdateBefore(TEntity entity)
        {
        }

        /// <summary>
        /// 修改后操作
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="changeValues">变更值集合</param>
        protected virtual void UpdateAfter(TEntity entity, ChangeValueCollection changeValues)
        {
            Log.BusinessId(entity.Id.SafeString()).Content($"Id:{entity.Id},{changeValues}");
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        /// <exception cref="ArgumentNullException">oldEntity</exception>
        protected async Task UpdateAsync(TEntity entity)
        {
            var oldEntity = await FindOldEntityAsync(entity.Id);
            if (oldEntity == null)
            {
                throw new ArgumentNullException(nameof(oldEntity));
            }

            var changes = oldEntity.GetChanges(entity);
            UpdateBefore(entity);
            await UpdateBeforeAsync(entity);
            await _repository.UpdateAsync(entity);
            UpdateAfter(entity, changes);
            await UpdateAfterAsync(entity, changes);
        }

        /// <summary>
        /// 修改前操作
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        protected virtual Task UpdateBeforeAsync(TEntity entity)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 修改后操作
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="changeValues">变更值集合</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        protected virtual Task UpdateAfterAsync(TEntity entity, ChangeValueCollection changeValues)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 保存前操作
        /// </summary>
        /// <param name="request">参数</param>
        protected virtual void SaveBefore(TRequest request)
        {
        }

        /// <summary>
        /// 是否创建
        /// </summary>
        /// <param name="request">参数</param>
        /// <param name="entity">实体</param>
        /// <returns>结果</returns>
        protected virtual bool IsNew(TRequest request, TEntity entity)
        {
            return string.IsNullOrWhiteSpace(request.Id) || entity.Id.Equals(default(TKey));
        }

        /// <summary>
        /// 保存后操作
        /// </summary>
        protected virtual void SaveAfter()
        {
            WriteLog($"保存{EntityDescription}成功");
        }
    }
}