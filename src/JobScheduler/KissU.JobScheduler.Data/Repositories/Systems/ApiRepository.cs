using System.Threading;
using System.Threading.Tasks;
using KissU.JobScheduler.Domain.Systems.Models;
using KissU.JobScheduler.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Util;
using System;
using Util.Domains;
using System.Collections.Generic;

namespace KissU.JobScheduler.Data.Repositories.Systems
{
    /// <summary>
    /// Api资源仓储
    /// </summary>
    public class ApiRepository : RepositoryBase<Api>, IApiRepository
    {
        /// <summary>
        /// 初始化Api资源仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public ApiRepository(IJobSchedulerUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        /// 查找实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public override async Task<Api> FindAsync(object id, CancellationToken cancellationToken = default)
        {
            if (id.SafeString().IsEmpty())
                return null;
            return await Find(t => t.Id.ToString() == id.SafeString()).Include(x => x.ApiScopes).SingleOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        /// 查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <param name="cancellationToken">取消令牌</param>
        public override async Task<List<Api>> FindByIdsAsync(IEnumerable<Guid> ids, CancellationToken cancellationToken = default)
        {
            if (ids == null)
                return null;
            return await Find(t => ids.Contains(t.Id)).Include(x => x.ApiScopes).ToListAsync(cancellationToken);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public override async Task UpdateAsync(Api entity)
        {
            await base.UpdateAsync(entity);
            var apiScopes = await UnitOfWork.Set<ApiScope>().Where(x => x.ApiId == entity.Id).ToListAsync();
            var listCompare = entity.ApiScopes?.Compare(apiScopes);
            listCompare?.CreateList.ForEach(x => AddDetail(x));
            listCompare?.UpdateList.ForEach(x => UpdateDetail(x));
            listCompare?.DeleteList.ForEach(x => DeleteDetail(x));
        }

        /// <summary>
        /// 移除实体集合
        /// </summary>
        /// <param name="entities">实体集合</param>
        /// <param name="cancellationToken">取消令牌</param>
        public override async Task RemoveAsync(IEnumerable<Api> entities, CancellationToken cancellationToken = default)
        {
            await base.RemoveAsync(entities, cancellationToken);
            foreach (var entity in entities)
            {
                entity.ApiScopes?.ForEach(x => DeleteDetail(x));
            }
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        public override async Task AddAsync(Api entity, CancellationToken cancellationToken = default)
        {
            await base.AddAsync(entity);
            entity.ApiScopes?.ForEach(x => AddDetail(x));
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        private Task AddDetail(ApiScope entity)
        {
            if (entity == null)
                return null;
            UnitOfWork.Set<ApiScope>().AddAsync(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        private Task DeleteDetail(ApiScope entity)
        {
            if (entity == null)
                return null;
            entity.IsDeleted = true;
            //UnitOfWork.Set<ApiScope>().Remove(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        private Task UpdateDetail(ApiScope entity)
        {
            if (entity == null)
                return null;
            UnitOfWork.Entry(entity).State = EntityState.Detached;
            var old = UnitOfWork.Set<ApiScope>().Find(entity.Id);
            if (old == null)
                return null;
            var oldEntry = UnitOfWork.Entry(old);
            if (!(entity is IVersion version))
            {
                oldEntry.CurrentValues.SetValues(entity);
            }
            else
            {
                oldEntry.State = EntityState.Detached;
                oldEntry.CurrentValues[nameof(version.Version)] = version.Version;
                oldEntry = UnitOfWork.Attach(old);
                oldEntry.CurrentValues.SetValues(entity);
            }
            return Task.CompletedTask;
        }
    }
}