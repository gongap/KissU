using System.Collections.Generic;
using KissU.Util.Datas.Sql.Builders;
using KissU.Util.Domains.Repositories;

namespace KissU.Util.Datas.Sql
{
    /// <summary>
    /// Sql生成器
    /// </summary>
    public interface ISqlBuilder : ICondition, ISelect, IFrom, IJoin, IWhere, IGroupBy, IOrderBy, IUnion, ICte
    {
        /// <summary>
        /// 分页参数
        /// </summary>
        IPager Pager { get; }

        /// <summary>
        /// 复制Sql生成器
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder Clone();

        /// <summary>
        /// 创建一个新的Sql生成器
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder New();

        /// <summary>
        /// 生成Sql语句
        /// </summary>
        /// <returns>System.String.</returns>
        string ToSql();

        /// <summary>
        /// 生成调试Sql语句，Sql语句中的参数被替换为参数值
        /// </summary>
        /// <returns>System.String.</returns>
        string ToDebugSql();

        /// <summary>
        /// 清空并初始化
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder Clear();

        /// <summary>
        /// 清空Select子句
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearSelect();

        /// <summary>
        /// 清空From子句
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearFrom();

        /// <summary>
        /// 清空Join子句
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearJoin();

        /// <summary>
        /// 清空Where子句
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearWhere();

        /// <summary>
        /// 清空GroupBy子句
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearGroupBy();

        /// <summary>
        /// 清空OrderBy子句
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearOrderBy();

        /// <summary>
        /// 清空Sql参数
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearSqlParams();

        /// <summary>
        /// 清空分页参数
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearPageParams();

        /// <summary>
        /// 清空联合操作项
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearUnionBuilders();

        /// <summary>
        /// 清空公用表表达式
        /// </summary>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder ClearCte();

        /// <summary>
        /// 添加Sql参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <param name="value">参数值</param>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder AddParam(string name, object value);

        /// <summary>
        /// 获取Sql参数列表
        /// </summary>
        /// <returns>IReadOnlyDictionary&lt;System.String, System.Object&gt;.</returns>
        IReadOnlyDictionary<string, object> GetParams();

        /// <summary>
        /// 设置分页
        /// </summary>
        /// <param name="pager">分页参数</param>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder Page(IPager pager);

        /// <summary>
        /// 设置跳过行数
        /// </summary>
        /// <param name="count">跳过的行数</param>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder Skip(int count);

        /// <summary>
        /// 设置获取行数
        /// </summary>
        /// <param name="count">获取的行数</param>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder Take(int count);

        /// <summary>
        /// 忽略过滤器
        /// </summary>
        /// <typeparam name="TSqlFilter">Sql过滤器类型</typeparam>
        /// <returns>ISqlBuilder.</returns>
        ISqlBuilder IgnoreFilter<TSqlFilter>() where TSqlFilter : ISqlFilter;
    }
}