using System;
using System.Collections.Generic;

namespace KissU.Util.Ddd.Datas.Sql.Builders
{
    /// <summary>
    /// 实体别名注册器
    /// </summary>
    public interface IEntityAliasRegister
    {
        /// <summary>
        /// From子句设置的实体类型
        /// </summary>
        Type FromType { get; set; }

        /// <summary>
        /// 实体别名
        /// </summary>
        IDictionary<Type, string> Data { get; }

        /// <summary>
        /// 注册实体别名
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <param name="alias">别名</param>
        void Register(Type type, string alias);

        /// <summary>
        /// 是否包含实体类型
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <returns><c>true</c> if [contains] [the specified type]; otherwise, <c>false</c>.</returns>
        bool Contains(Type type);

        /// <summary>
        /// 获取实体别名
        /// </summary>
        /// <param name="type">实体类型</param>
        /// <returns>System.String.</returns>
        string GetAlias(Type type);

        /// <summary>
        /// 复制实体别名注册器
        /// </summary>
        /// <returns>IEntityAliasRegister.</returns>
        IEntityAliasRegister Clone();
    }
}