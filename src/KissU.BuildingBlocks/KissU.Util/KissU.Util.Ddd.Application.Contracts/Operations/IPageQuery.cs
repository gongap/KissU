﻿using System.Collections.Generic;
using KissU.Core.Datas;
using KissU.Core.Datas.Queries;

namespace KissU.Util.Ddd.Application.Contracts.Operations
{
    /// <summary>
    /// 分页查询
    /// </summary>
    /// <typeparam name="TDto">数据传输对象类型</typeparam>
    /// <typeparam name="TQueryParameter">查询参数类型</typeparam>
    public interface IPageQuery<TDto, in TQueryParameter>
        where TDto : new()
        where TQueryParameter : IQueryParameter
    {
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>List&lt;TDto&gt;.</returns>
        List<TDto> Query(TQueryParameter parameter);

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="parameter">查询参数</param>
        /// <returns>PagerList&lt;TDto&gt;.</returns>
        PagerList<TDto> PagerQuery(TQueryParameter parameter);
    }
}