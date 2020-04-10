using KissU.Util.Datas.Tests.Integration.Commons.Datas.Pos;
using KissU.Util.EntityFrameworkCore.SqlServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Util.Datas.Tests.Integration.Ef.SqlServer.Mappings
{
    /// <summary>
    /// 商品持久化对象映射配置
    /// </summary>
    public class ProductPoMap : AggregateRootMap<ProductPo>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<ProductPo> builder)
        {
            builder.ToTable("Products", "Productions");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<ProductPo> builder)
        {
            base.MapProperties(builder);
            //商品编号
            builder.Property(t => t.Id)
                .HasColumnName("ProductId");
        }
    }
}