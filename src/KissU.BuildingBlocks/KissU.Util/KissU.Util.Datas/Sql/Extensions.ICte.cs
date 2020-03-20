using System;
using KissU.Core.Datas.Sql;
using KissU.Core.Datas.Sql.Builders;
using KissU.Core.Datas.Sql.Builders.Core;
using KissU.Util.Datas.Sql.Builders;
using KissU.Util.Datas.Sql.Builders.Core;

namespace KissU.Util.Datas.Sql
{
    /// <summary>
    /// 公用表表达式CTE操作扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 设置公用表表达式CTE
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="name">公用表表达式CTE的名称</param>
        /// <param name="builder">Sql生成器</param>
        /// <returns>T.</returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public static T With<T>(this T source, string name, ISqlBuilder builder) where T : ICte
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (string.IsNullOrWhiteSpace(name) || builder == null)
                return source;
            if (source is ICteAccessor accessor)
                accessor.CteItems.Add(new BuilderItem(name, builder));
            return source;
        }
    }
}