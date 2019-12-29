using KissU.Util.Datas.SqlServer.Ef;
using KissU.Util.Datas.Tests.Integration.Commons.Datas.Pos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Util.Datas.Tests.Integration.SqlServer.Ef.Mappings
{
    /// <summary>
    /// 商品持久化对象映射配置
    /// </summary>
    public class ProductPoMap : AggregateRootMap<ProductPo>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        protected override void MapTable(EntityTypeBuilder<ProductPo> builder)
        {
            builder.ToTable("Products", "Productions");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        protected override void MapProperties(EntityTypeBuilder<ProductPo> builder)
        {
            base.MapProperties(builder);
            //商品编号
            builder.Property(t => t.Id)
                .HasColumnName("ProductId");
        }
    }
}