﻿// <copyright file="ClientMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Domain.Models.ClientAggregate;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 应用程序映射配置
    /// </summary>
    public class ClientMap : AggregateRootMap<Client>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients", "ids");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<Client> builder)
        {
            builder.Property(t => t.Id).HasColumnName("ClientId");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
