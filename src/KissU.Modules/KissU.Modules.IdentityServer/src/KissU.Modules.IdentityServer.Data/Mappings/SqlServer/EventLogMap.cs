// <copyright file="EventLogMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    using KissU.Modules.IdentityServer.Domain.Models.EventLog;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Util.Datas.Ef.SqlServer;

    /// <summary>
    /// 映射配置
    /// </summary>
    public class EventLogMap : AggregateRootMap<EventLog>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<EventLog> builder)
        {
            builder.ToTable("EventLogs", "ids");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<EventLog> builder)
        {
            builder.Property(t => t.Id).HasColumnName("Id");
        }
    }
}
