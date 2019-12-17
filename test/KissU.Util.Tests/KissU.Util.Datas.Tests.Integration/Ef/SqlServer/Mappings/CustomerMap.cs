using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Util.Datas.Tests.Integration.SqlServer.Ef.Mappings {
    /// <summary>
    /// 客户映射配置
    /// </summary>
    public class CustomerMap : Util.Datas.SqlServer.Ef.AggregateRootMap<Customer> {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable( EntityTypeBuilder<Customer> builder ) {
            builder.ToTable( "Customers", "Customers" );
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties( EntityTypeBuilder<Customer> builder ) {
            base.MapProperties( builder );
            //客户编号
            builder.Property( t => t.Id )
                .HasColumnName( "CustomerId" );
        }
    }
}
