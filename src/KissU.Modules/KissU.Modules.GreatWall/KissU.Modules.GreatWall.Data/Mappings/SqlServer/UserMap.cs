using KissU.Modules.GreatWall.Domain.Models;
using KissU.Util.Datas.SqlServer.Ef;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Modules.GreatWall.Data.Mappings.SqlServer
{
    /// <summary>
    /// 用户映射配置
    /// </summary>
    public class UserMap : AggregateRootMap<User>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(DbConstants.DbTablePrefix + "Users", DbConstants.DbSchema);
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<User> builder)
        {
            builder.HasQueryFilter(t => t.IsDeleted == false);
        }
    }
}