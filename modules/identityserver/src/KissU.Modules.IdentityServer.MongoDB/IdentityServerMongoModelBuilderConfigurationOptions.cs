using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace KissU.Modules.IdentityServer.MongoDB
{
    public class IdentityServerMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public IdentityServerMongoModelBuilderConfigurationOptions([NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}
