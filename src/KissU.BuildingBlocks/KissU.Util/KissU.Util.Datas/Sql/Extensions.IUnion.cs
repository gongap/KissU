using System;
using System.Collections.Generic;
using KissU.Util.Datas.Sql.Builders;
using KissU.Util.Datas.Sql.Builders.Core;
using KissU.Util.Ddd.Datas.Sql;
using KissU.Util.Ddd.Datas.Sql.Builders;
using KissU.Util.Ddd.Datas.Sql.Builders.Core;

namespace KissU.Util.Datas.Sql
{
    /// <summary>
    /// 联合操作扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 联合多个查询，Union会排除重复结果行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器列表</param>
        /// <returns>T.</returns>
        public static T Union<T>(this T source, params ISqlBuilder[] builders) where T : IUnion
        {
            Union(source, "Union", builders);
            return source;
        }

        /// <summary>
        /// 联合操作
        /// </summary>
        private static void Union<T>(T source, string operation, IEnumerable<ISqlBuilder> builders) where T : IUnion
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (builders == null)
                return;
            if (!(source is IUnionAccessor accessor))
                return;
            foreach (var builder in builders)
            {
                builder.ClearOrderBy();
                builder.ClearPageParams();
                accessor.UnionItems.Add(new BuilderItem(operation, builder));
            }
        }

        /// <summary>
        /// 联合多个查询，Union会排除重复结果行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器列表</param>
        /// <returns>T.</returns>
        public static T Union<T>(this T source, IEnumerable<ISqlBuilder> builders) where T : IUnion
        {
            Union(source, "Union", builders);
            return source;
        }

        /// <summary>
        /// 联合多个查询，Union All不会排除重复结果行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器列表</param>
        /// <returns>T.</returns>
        public static T UnionAll<T>(this T source, params ISqlBuilder[] builders) where T : IUnion
        {
            Union(source, "Union All", builders);
            return source;
        }

        /// <summary>
        /// 联合多个查询，Union All不会排除重复结果行
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器列表</param>
        /// <returns>T.</returns>
        public static T UnionAll<T>(this T source, IEnumerable<ISqlBuilder> builders) where T : IUnion
        {
            Union(source, "Union All", builders);
            return source;
        }

        /// <summary>
        /// 交集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器列表</param>
        /// <returns>T.</returns>
        public static T Intersect<T>(this T source, params ISqlBuilder[] builders) where T : IUnion
        {
            Union(source, "Intersect", builders);
            return source;
        }

        /// <summary>
        /// 交集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器列表</param>
        /// <returns>T.</returns>
        public static T Intersect<T>(this T source, IEnumerable<ISqlBuilder> builders) where T : IUnion
        {
            Union(source, "Intersect", builders);
            return source;
        }

        /// <summary>
        /// 差集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器列表</param>
        /// <returns>T.</returns>
        public static T Except<T>(this T source, params ISqlBuilder[] builders) where T : IUnion
        {
            Union(source, "Except", builders);
            return source;
        }

        /// <summary>
        /// 差集
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="builders">Sql生成器列表</param>
        /// <returns>T.</returns>
        public static T Except<T>(this T source, IEnumerable<ISqlBuilder> builders) where T : IUnion
        {
            Union(source, "Except", builders);
            return source;
        }
    }
}