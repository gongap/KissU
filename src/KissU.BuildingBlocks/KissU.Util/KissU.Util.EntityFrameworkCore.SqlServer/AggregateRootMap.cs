﻿using KissU.Util.Ddd.Domain.Domains;
using KissU.Util.EntityFrameworkCore.Core;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Util.EntityFrameworkCore.SqlServer
{
    /// <summary>
    /// 聚合根映射配置
    /// </summary>
    /// <typeparam name="TEntity">实体类型</typeparam>
    public abstract class AggregateRootMap<TEntity> : MapBase<TEntity>, IMap where TEntity : class, IVersion
    {
        /// <summary>
        /// 映射乐观离线锁
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapVersion(EntityTypeBuilder<TEntity> builder)
        {
            builder.Property(t => t.Version).IsRowVersion();
        }
    }
}