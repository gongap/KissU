using System;
using KissU.Modules.BackgroundJobs.Domain;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace KissU.Modules.BackgroundJobs.MongoDB
{
    public static class BackgroundJobsMongoDbContextExtensions
    {
        public static void ConfigureBackgroundJobs(
            this IMongoModelBuilder builder,
            Action<AbpMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new BackgroundJobsMongoModelBuilderConfigurationOptions(
                BackgroundJobsDbProperties.DbTablePrefix
            );

            optionsAction?.Invoke(options);

            builder.Entity<BackgroundJobRecord>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "BackgroundJobs";
            });
        }
    }
}