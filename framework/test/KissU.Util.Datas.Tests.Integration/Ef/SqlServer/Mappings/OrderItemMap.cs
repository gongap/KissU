using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Util.Datas.Tests.Integration.Ef.SqlServer.Mappings
{
    /// <summary>
    /// 订单明细映射配置
    /// </summary>
    public class OrderItemMap : EntityMap<OrderItem>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems", "Sales");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<OrderItem> builder)
        {
            base.MapProperties(builder);
            //订单明细编号
            builder.Property(t => t.Id)
                .HasColumnName("OrderItemId");
        }
    }
}