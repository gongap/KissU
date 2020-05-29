﻿using System;
using Volo.Abp;
using Volo.Abp.MongoDB;

namespace KissU.Modules.AuditLogging.MongoDB
{
    public static class AbpAuditLoggingMongoDbContextExtensions
    {
        public static void ConfigureAuditLogging(
            this IMongoModelBuilder builder,
            Action<AuditLoggingMongoModelBuilderConfigurationOptions> optionsAction = null)
        {
            Check.NotNull(builder, nameof(builder));

            var options = new AuditLoggingMongoModelBuilderConfigurationOptions(
                AbpAuditLoggingDbProperties.DbTablePrefix
                );

            optionsAction?.Invoke(options);

            builder.Entity<AuditLog>(b =>
            {
                b.CollectionName = options.CollectionPrefix + "AuditLogs";
            });
        }
    }
}
