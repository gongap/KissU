using System.Threading;
using System.Threading.Tasks;
using KissU.Domain.Systems.Models;
using KissU.Domain.Systems.Repositories;
using Util.Datas.Ef.Core;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Util;
using System;
using Util.Domains;
using System.Collections.Generic;

namespace KissU.Data.Repositories.Systems
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
        public ApiRepository(IKissUUnitOfWork unitOfWork) : base(unitOfWork)
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
            return await Set.Include(x => x.ApiScopes).Where(x => x.Id.ToString() == id.SafeString()).SingleOrDefaultAsync<Api>(cancellationToken);
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public override Task UpdateAsync(Api entity)
        {
            Update(entity);
            SaveDetail(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 移除实体
        /// </summary>
        /// <param name="id">实体标识</param>
        public override void Remove(object id)
        {
            var entity = Find(id);
            if (entity == null)
                return;
            entity.ApiScopes?.ToList().ForEach(x => DeleteDetail(x));
            base.Remove(id);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        /// <param name="cancellationToken">取消令牌</param>
        public override Task AddAsync(Api entity, CancellationToken cancellationToken = default)
        {
            base.Add(entity);
            entity.ApiScopes?.ToList().ForEach(x => AddDetail(x));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 保存实体
        /// </summary>
        /// <param name="entity">实体</param>
        public Task SaveDetail(Api entity)
        {
            var old = Find(entity.Id);
            if (old == null)
                return null;
            var listCompare = entity.ApiScopes?.Compare(old.ApiScopes);
            listCompare?.CreateList.ForEach(x => AddDetail(x));
            listCompare?.UpdateList.ForEach(x=> UpdateDetail(x));
            listCompare?.DeleteList.ForEach(x => DeleteDetail(x));
            return Task.CompletedTask;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public Task AddDetail(ApiScope entity)
        {
            if (entity == null)
                return null;
            UnitOfWork.Set<ApiScope>().Add(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        public Task DeleteDetail(ApiScope entity)
        {
            if (entity == null)
                return null;
            UnitOfWork.Set<ApiScope>().Remove(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public Task UpdateDetail(ApiScope entity)
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