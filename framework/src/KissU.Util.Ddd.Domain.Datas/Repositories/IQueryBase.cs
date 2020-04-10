﻿using KissU.Core.Datas;

namespace KissU.Util.Ddd.Domain.Datas.Repositories
{
    /// <summary>
    /// 查询对象
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public interface IQueryBase<TEntity> : ICriteria<TEntity> where TEntity : class
    {
        /// <summary>
        /// 获取排序条件
        /// </summary>
        /// <returns>System.String.</returns>
        string GetOrder();

        /// <summary>
        /// 获取分页参数
        /// </summary>
        /// <returns>IPager.</returns>
        IPager GetPager();
    }
}