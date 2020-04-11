using Volo.Abp.Data;
using Volo.Abp.MongoDB;

namespace KissU.Modules.BookStore.MongoDB
{
    [ConnectionStringName(BookStoreDbProperties.ConnectionStringName)]
    public class BookStoreMongoDbContext : AbpMongoDbContext, IBookStoreMongoDbContext
    {
        /* Add mongo collections here. Example:
         * public IMongoCollection<Question> Questions => Collection<Question>();
         */

        protected override void CreateModel(IMongoModelBuilder modelBuilder)
        {
            base.CreateModel(modelBuilder);

            modelBuilder.ConfigureBookStore();
        }
    }
}