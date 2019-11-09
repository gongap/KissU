using KissU.Modules.IdentityServer.Domain.Models.PersistedGrantAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 操作数据映射配置
    /// </summary>
    public class PersistedGrantMap : Util.Datas.Ef.SqlServer.AggregateRootMap<PersistedGrant>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<PersistedGrant> builder)
        {
            builder.ToTable("PersistedGrants", "ids");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<PersistedGrant> builder)
        {
        }
    }
}
