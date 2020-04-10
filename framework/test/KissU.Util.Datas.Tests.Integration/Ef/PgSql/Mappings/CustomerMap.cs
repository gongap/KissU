using KissU.Util.Datas.Tests.Integration.Commons.Domains.Models;
using KissU.Util.EntityFrameworkCore.PgSql;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KissU.Util.Datas.Tests.Integration.Ef.PgSql.Mappings
{
    /// <summary>
    /// 客户映射配置
    /// </summary>
    public class CustomerMap : AggregateRootMap<Customer>
    {
        /// <summary>
        /// 映射表
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapTable(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", "Customers");
        }

        /// <summary>
        /// 映射属性
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void MapProperties(EntityTypeBuilder<Customer> builder)
        {
            base.MapProperties(builder);
            //客户编号
            builder.Property(t => t.Id)
                .HasColumnName("CustomerId");
        }
    }
}