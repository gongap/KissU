using KissU.Modules.IdentityServer.Domain.Models.ClientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// 应用程序密钥映射配置
    /// </summary>
    public class ClientSecretMap : Util.Datas.Ef.SqlServer.EntityMap<ClientSecret>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ClientSecret> builder)
        {
            builder.ToTable("ClientSecrets", "ids");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ClientSecret> builder)
        {
        }
    }
}
