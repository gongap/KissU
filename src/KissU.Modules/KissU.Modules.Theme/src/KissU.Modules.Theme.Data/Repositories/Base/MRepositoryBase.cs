// <copyright file="MRepositoryBase.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.Theme.Data.Repositories.Base
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using KissU.Modules.Theme.Domain.Base;
    using Microsoft.EntityFrameworkCore;
    using Util;
    using Util.Datas.Ef.Core;
    using Util.Datas.UnitOfWorks;
    using Util.Domains;

    /// <summary>
    ///     主从仓储
    /// </summary>
    /// <typeparam name="TMaster"></typeparam>
    /// <typeparam name="TDetail"></typeparam>
    public class MRepositoryBase<TMaster, TDetail> : RepositoryBase<TMaster>
        where TMaster : MasterEntity<TDetail>
        where TDetail : DetailEntity
    {
        /// <summary>初始化主从仓储</summary>
        /// <param name="unitOfWork">工作单元</param>
        protected MRepositoryBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        /// <summary>
        ///     查找实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        public override async Task<TMaster> FindAsync(object id, CancellationToken cancellationToken = default)
        {
            if (id.SafeString().IsEmpty())
            {
                return null;
            }

            return await Find(t => t.Id.ToString() == id.SafeString()).Include(x => x.Details)
                .SingleOrDefaultAsync(cancellationToken);
        }

        /// <summary>
        ///     查找实体列表
        /// </summary>
        /// <param name="ids">标识列表</param>
        /// <param name="cancellationToken">取消令牌</param>
        public override async Task<List<TMaster>> FindByIdsAsync(IEnumerable<Guid> ids,
            CancellationToken cancellationToken = default)
        {
            if (ids == null)
            {
                return null;
            }

            return await Find(t => ids.Contains(t.Id)).Include(x => x.Details).ToListAsync(cancellationToken);
        }

        /// <summary>
        ///     修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        public override async Task UpdateAsync(TMaster entity)
        {
            await base.UpdateAsync(entity);
            var details = await UnitOfWork.Set<TDetail>().Where(x => x.MainId == entity.Id).ToListAsync();
            var listCompare = entity.Details?.Compare(details);
            listCompare?.CreateList.ForEach(x => AddDetail(x));
            listCompare?.UpdateList.ForEach(x => UpdateDetail(x));
            listCompare?.DeleteList.ForEach(x => DeleteDetail(x));
        }

        /// <summary>
        ///     添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task AddDetail(TDetail entity)
        {
            if (entity == null)
            {
                return null;
            }

            UnitOfWork.Set<TDetail>().AddAsync(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        ///     删除实体
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task DeleteDetail(TDetail entity)
        {
            if (entity == null)
            {
                return null;
            }

            UnitOfWork.Set<TDetail>().Remove(entity);
            return Task.CompletedTask;
        }

        /// <summary>
        ///     修改实体
        /// </summary>
        /// <param name="entity">实体</param>
        protected virtual Task UpdateDetail(TDetail entity)
        {
            if (entity == null)
            {
                return null;
            }

            UnitOfWork.Entry(entity).State = EntityState.Detached;
            var old = UnitOfWork.Set<TDetail>().Find(entity.Id);
            if (old == null)
            {
                return null;
            }

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
