using KissU.Modules.IdentityServer.Domain.Models.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 应用程序声明映射配置
    /// </summary>
    public class ClientClaimMap : Util.Datas.Ef.SqlServer.EntityMap<ClientClaim>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ClientClaim> builder)
        {
            builder.ToTable("ClientClaims", "ids");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ClientClaim> builder)
        {
        }
    }
}
