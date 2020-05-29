using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace KissU.Modules.AuditLogging.MongoDB
{
    public class AuditLoggingMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public AuditLoggingMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
