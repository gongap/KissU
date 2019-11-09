using KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// API资源映射配置
    /// </summary>
    public class ApiResourceMap : Util.Datas.Ef.SqlServer.AggregateRootMap<ApiResource>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ApiResource> builder)
        {
            builder.ToTable("ApiResources", "ids");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ApiResource> builder)
        {
            builder.Property(t => t.Id).HasColumnName("ApiResourceId");
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}
