using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace KissU.Modules.AuditLogging.EntityFrameworkCore.EntityFrameworkCore
{
    public class AbpAuditLoggingModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public AbpAuditLoggingModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix,
            [CanBeNull] string schema)
            : base(
                tablePrefix, 
                schema)
        {

        }
    }
}