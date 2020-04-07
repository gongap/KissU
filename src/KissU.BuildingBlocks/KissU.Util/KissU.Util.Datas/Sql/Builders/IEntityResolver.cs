﻿using System;
using System.Linq.Expressions;

namespace KissU.Util.Ddd.Domain.Datas.Sql.Builders
{
    /// <summary>
    /// 实体解析器
    /// </summary>
    public interface IEntityResolver
    {
        /// <summary>
        /// 获取表
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <returns>System.String.</returns>
        string GetTable(Type entity);

        /// <summary>
        /// 获取架构
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <returns>System.String.</returns>
        string GetSchema(Type entity);

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        /// <returns>System.String.</returns>
        string GetColumns<TEntity>(bool propertyAsAlias);

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">列名表达式</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        /// <returns>System.String.</returns>
        string GetColumns<TEntity>(Expression<Func<TEntity, object[]>> columns, bool propertyAsAlias);

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">列名表达式</param>
        /// <returns>System.String.</returns>
        string GetColumn<TEntity>(Expression<Func<TEntity, object>> column);

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="entity">实体类型</param>
        /// <param name="right">是否取右侧操作数</param>
        /// <returns>System.String.</returns>
        string GetColumn(Expression expression, Type entity, bool right = false);

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="right">是否取右侧操作数</param>
        /// <returns>Type.</returns>
        Type GetType(Expression expression, bool right = false);
    }
}