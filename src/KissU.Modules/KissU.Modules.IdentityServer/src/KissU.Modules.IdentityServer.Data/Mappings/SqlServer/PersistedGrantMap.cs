// <copyright file="PersistedGrantMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    using KissU.Modules.IdentityServer.Domain.Models.PersistedGrantAggregate;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Util.Datas.Ef.SqlServer;

    /// <summary>
    ///     操作数据映射配置
    /// </summary>
    public class PersistedGrantMap : AggregateRootMap<PersistedGrant>
    {
        /// <summary>
        ///     映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<PersistedGrant> builder)
        {
            builder.ToTable("PersistedGrants", "ids");
        }

        /// <summary>
        ///     映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<PersistedGrant> builder)
        {
        }
    }
}
