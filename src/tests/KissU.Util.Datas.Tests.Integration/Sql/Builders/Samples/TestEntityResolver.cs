using System;
using System.Linq;
using System.Linq.Expressions;
using KissU.Core;
using KissU.Core.Helpers;
using KissU.Util.Datas.Tests.Integration.Samples;

namespace KissU.Util.Datas.Tests.Integration.Sql.Builders.Samples
{
    /// <summary>
    /// 实体解析器
    /// </summary>
    public class TestEntityResolver : IEntityResolver
    {
        /// <summary>
        /// 获取表
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <returns>System.String.</returns>
        public string GetTable(Type entity)
        {
            return $"t_{entity.Name}";
        }

        /// <summary>
        /// 获取架构
        /// </summary>
        /// <param name="entity">实体类型</param>
        /// <returns>System.String.</returns>
        public string GetSchema(Type entity)
        {
            return "s";
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        /// <returns>System.String.</returns>
        public string GetColumns<TEntity>(bool propertyAsAlias)
        {
            return "*";
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="columns">列名表达式</param>
        /// <param name="propertyAsAlias">是否将属性名映射为列别名</param>
        /// <returns>System.String.</returns>
        public string GetColumns<TEntity>(Expression<Func<TEntity, object[]>> columns, bool propertyAsAlias)
        {
            return Lambda.GetLastNames(columns).Select(column => $"t_{column}").Join();
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <typeparam name="TEntity">实体类型</typeparam>
        /// <param name="column">列名表达式</param>
        /// <returns>System.String.</returns>
        public string GetColumn<TEntity>(Expression<Func<TEntity, object>> column)
        {
            return $"t_{Lambda.GetLastName(column)}";
        }

        /// <summary>
        /// 获取列名
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="entity">实体类型</param>
        /// <param name="right">是否取右侧操作数</param>
        /// <returns>System.String.</returns>
        public string GetColumn(Expression expression, Type entity, bool right)
        {
            return $"t_{Lambda.GetLastName(expression, right)}";
        }

        /// <summary>
        /// 获取类型
        /// </summary>
        /// <param name="expression">表达式</param>
        /// <param name="right">是否取右侧操作数</param>
        /// <returns>Type.</returns>
        public Type GetType(Expression expression, bool right = false)
        {
            return typeof(Sample);
        }
    }
}