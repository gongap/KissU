using GreatWall.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GreatWall.Data.Mappings.SqlServer {
    /// <summary>
    /// 用户映射配置
    /// </summary>
    public class UserMap : Util.Datas.Ef.SqlServer.AggregateRootMap<User> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<User> builder ) {
            builder.ToTable( "User", "Systems" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<User> builder ) {
            //用户标识
            builder.Property( t => t.Id )
                .HasColumnName( "UserId" );
            builder.HasQueryFilter( t => t.IsDeleted == false );
        }
    }
}
