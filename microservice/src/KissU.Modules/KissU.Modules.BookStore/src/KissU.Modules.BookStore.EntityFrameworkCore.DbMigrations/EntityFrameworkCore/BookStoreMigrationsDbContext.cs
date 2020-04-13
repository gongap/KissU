using Microsoft.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.BookStore.EntityFrameworkCore
{
    /* This DbContext is only used for database migrations.
     * It is not used on runtime. See BookStoreDbContext for the runtime DbContext.
     * It is a unified model that includes configuration for
     * all used modules and your application.
     */
    public class BookStoreMigrationsDbContext : AbpDbContext<BookStoreMigrationsDbContext>
    {
        public BookStoreMigrationsDbContext(DbContextOptions<BookStoreMigrationsDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Configure your own tables/entities inside the ConfigureBookStore method */

            builder.ConfigureBookStore();
        }
    }
}