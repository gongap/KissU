﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using KissU.Util.Datas.Stores;
using KissU.Util.Domains;
using KissU.Util.Domains.Trees;
using Microsoft.EntityFrameworkCore;

namespace KissU.Util.Datas.Ef.Core
{
    /// <summary>
    /// 树型仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    public abstract class TreeCompactRepositoryBase<TEntity, TPo>
        : TreeCompactRepositoryBase<TEntity, TPo, Guid, Guid?>, ITreeCompactRepository<TEntity>
        where TEntity : class, ITreeEntity<TEntity, Guid, Guid?>
        where TPo : class, IKey<Guid>, IVersion, IPath, IParentId<Guid?>, ISortId
    {
        /// <summary>
        /// 存储器
        /// </summary>
        private readonly IStore<TPo, Guid> _store;

        /// <summary>
        /// 初始化树型仓储
        /// </summary>
        /// <param name="store">存储器</param>
        protected TreeCompactRepositoryBase(IStore<TPo, Guid> store) : base(store)
        {
            _store = store;
        }

        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="parentId">父标识</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public override async Task<int> GenerateSortIdAsync(Guid? parentId)
        {
            var maxSortId = await _store.Find(t => t.ParentId == parentId).MaxAsync(t => t.SortId);
            return maxSortId.SafeValue() + 1;
        }
    }

    /// <summary>
    /// 树型仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TPo">持久化对象类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    /// <typeparam name="TParentId">父标识类型</typeparam>
    public abstract class TreeCompactRepositoryBase<TEntity, TPo, TKey, TParentId>
        : CompactRepositoryBase<TEntity, TPo, TKey>, ITreeCompactRepository<TEntity, TKey, TParentId>
        where TEntity : class, ITreeEntity<TEntity, TKey, TParentId>
        where TPo : class, IKey<TKey>, IVersion, IPath
    {
        /// <summary>
        /// 存储器
        /// </summary>
        private readonly IStore<TPo, TKey> _store;

        /// <summary>
        /// 初始化树型仓储
        /// </summary>
        /// <param name="store">存储器</param>
        protected TreeCompactRepositoryBase(IStore<TPo, TKey> store) : base(store)
        {
            _store = store;
        }

        /// <summary>
        /// 生成排序号
        /// </summary>
        /// <param name="parentId">父标识</param>
        /// <returns>Task&lt;System.Int32&gt;.</returns>
        public abstract Task<int> GenerateSortIdAsync(TParentId parentId);

        /// <summary>
        /// 获取全部下级实体
        /// </summary>
        /// <param name="parent">父实体</param>
        /// <returns>Task&lt;List&lt;TEntity&gt;&gt;.</returns>
        public virtual async Task<List<TEntity>> GetAllChildrenAsync(TEntity parent)
        {
            var list = await _store.FindAllAsync(t => t.Path.StartsWith(parent.Path));
            return list.Where(t => !t.Id.Equals(parent.Id)).Select(ToEntity).ToList();
        }

        /// <summary>
        /// 查找未跟踪单个实体
        /// </summary>
        /// <param name="id">标识</param>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns>Task&lt;TEntity&gt;.</returns>
        public virtual async Task<TEntity> FindByIdNoTrackingAsync(TKey id,
            CancellationToken cancellationToken = default)
        {
            return ToEntity(await _store.FindByIdNoTrackingAsync(id, cancellationToken));
        }
    }
}