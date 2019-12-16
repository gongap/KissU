// <copyright file="ApiResourceSecretMap.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using KissU.Util.Datas.Ef.SqlServer;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// API密钥映射配置
    /// </summary>
    public class ApiResourceSecretMap : EntityMap<ApiResourceSecret>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ApiResourceSecret> builder)
        {
            builder.ToTable("ApiResourceSecrets", "ids");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ApiResourceSecret> builder)
        {
        }
    }
}
