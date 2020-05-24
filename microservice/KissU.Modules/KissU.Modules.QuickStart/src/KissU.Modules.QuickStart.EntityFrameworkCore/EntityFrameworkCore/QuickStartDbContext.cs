using KissU.Modules.QuickStart.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace KissU.Modules.QuickStart.EntityFrameworkCore
{
    [ConnectionStringName(QuickStartDbProperties.ConnectionStringName)]
    public class QuickStartDbContext : AbpDbContext<QuickStartDbContext>, IQuickStartDbContext
    {
        /* Add DbSet for each Aggregate Root here. Example:
         * public DbSet<Question> Questions { get; set; }
         */
        public DbSet<Book> Books { get; set; }

        public QuickStartDbContext(DbContextOptions<QuickStartDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ConfigureQuickStart();
        }
    }
}