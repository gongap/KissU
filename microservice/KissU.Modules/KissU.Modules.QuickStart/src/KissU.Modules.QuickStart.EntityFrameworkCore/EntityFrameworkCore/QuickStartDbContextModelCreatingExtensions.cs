using System;
using KissU.Modules.QuickStart.Books;
using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace KissU.Modules.QuickStart.EntityFrameworkCore
{
    public static class QuickStartDbContextModelCreatingExtensions
    {
        public static void ConfigureQuickStart(
            this ModelBuilder builder,
            Action<QuickStartModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new QuickStartModelBuilderConfigurationOptions(
                QuickStartDbProperties.DbTablePrefix,
                QuickStartDbProperties.DbSchema
            );

            optionsAction?.Invoke(options); 

            builder.Entity<Book>(b =>
            {
                b.ToTable(options.TablePrefix + "Books", options.Schema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });
        }
    }
}