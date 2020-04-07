﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace KissU.Util.Ddd.Domain.Datas.Stores.Operations
{
    /// <summary>
    /// 查找实体列表
    /// </summary>
    /// <typeparam name="TEntity">对象类型</typeparam>
    /// <typeparam name="TKey">对象标识类型</typeparam>
    public interface IFindAllNoTracking<TEntity, in TKey> where TEntity : class, IKey<TKey>
    {
        /// <summary>
        /// 查找实体列表,不跟踪
        /// </summary>
        /// <param name="predicate">条件</param>
        /// <returns>List&lt;TEntity&gt;.</returns>
        List<TEntity> FindAllNoTracking(Expression<Func<TEntity, bool>> predicate = null);
    }
}