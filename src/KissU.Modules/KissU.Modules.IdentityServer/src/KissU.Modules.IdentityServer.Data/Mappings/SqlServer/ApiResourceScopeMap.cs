using KissU.Modules.IdentityServer.Domain.Models.ApiResourceAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.IdentityServer.Data.Mappings.SqlServer
{
    /// <summary>
    /// Api许可范围映射配置
    /// </summary>
    public class ApiResourceScopeMap : Util.Datas.Ef.SqlServer.EntityMap<ApiResourceScope>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ApiResourceScope> builder)
        {
            builder.ToTable("ApiResourceScopes", "ids");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ApiResourceScope> builder)
        {
        }
    }
}
