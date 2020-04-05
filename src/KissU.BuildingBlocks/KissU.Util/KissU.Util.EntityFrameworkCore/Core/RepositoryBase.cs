﻿using System;
using KissU.Util.Ddd.Datas.UnitOfWorks;
using KissU.Util.Ddd.Domains;
using KissU.Util.Ddd.Domains.Repositories;

namespace KissU.Util.EntityFrameworkCore.Core
{
    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class RepositoryBase<TEntity> : RepositoryBase<TEntity, Guid>, IRepository<TEntity>
        where TEntity : class, IAggregateRoot<TEntity, Guid>
    {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected RepositoryBase(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }
    }

    /// <summary>
    /// 仓储
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    /// <typeparam name="TKey">实体标识类型</typeparam>
    public abstract class RepositoryBase<TEntity, TKey> : StoreBase<TEntity, TKey>, IRepository<TEntity, TKey>
        where TEntity : class, IAggregateRoot<TEntity, TKey>
    {
        /// <summary>
        /// 初始化仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        protected RepositoryBase(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}