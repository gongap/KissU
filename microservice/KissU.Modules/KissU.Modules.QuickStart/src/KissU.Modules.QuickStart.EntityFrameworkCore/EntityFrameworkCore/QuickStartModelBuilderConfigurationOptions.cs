using JetBrains.Annotations;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace KissU.Modules.QuickStart.EntityFrameworkCore
{
    public class QuickStartModelBuilderConfigurationOptions : AbpModelBuilderConfigurationOptions
    {
        public QuickStartModelBuilderConfigurationOptions(
            [NotNull] string tablePrefix = "",
            [CanBeNull] string schema = null)
            : base(
                tablePrefix,
                schema)
        {

        }
    }
}