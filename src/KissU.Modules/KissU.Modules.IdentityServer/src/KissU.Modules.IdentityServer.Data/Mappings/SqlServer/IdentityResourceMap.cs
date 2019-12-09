// <copyright file="IdentityResourceMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    using KissU.Modules.IdentityServer.Domain.Models.IdentityResourceAggregate;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Util.Datas.Ef.SqlServer;

    /// <summary>
    /// 身份资源映射配置
    /// </summary>
    public class IdentityResourceMap : AggregateRootMap<IdentityResource>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.ToTable("IdentityResources", "ids");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<IdentityResource> builder)
        {
            builder.Property(t => t.Id).HasColumnName("IdentityResourceId");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
