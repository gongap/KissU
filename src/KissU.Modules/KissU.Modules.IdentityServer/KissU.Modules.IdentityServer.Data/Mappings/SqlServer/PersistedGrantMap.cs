// <copyright file="PersistedGrantMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 操作数据映射配置
    /// </summary>
    public class PersistedGrantMap : AggregateRootMap<PersistedGrant>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<PersistedGrant> builder)
        {
            builder.ToTable(Consts.DbTablePrefix + "PersistedGrants", Consts.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<PersistedGrant> builder)
        {
        }
    }
}
