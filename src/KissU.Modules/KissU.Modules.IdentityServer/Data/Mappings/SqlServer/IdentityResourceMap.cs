using KissU.Modules.IdentityServer.Domain.Models.IdentityResourceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 身份资源映射配置
    /// </summary>
    public class IdentityResourceMap : Util.Datas.Ef.SqlServer.AggregateRootMap<IdentityResource>
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
