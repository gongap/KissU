using JetBrains.Annotations;
using Volo.Abp.MongoDB;

namespace KissU.Modules.BookStore.MongoDB
{
    public class BookStoreMongoModelBuilderConfigurationOptions : AbpMongoModelBuilderConfigurationOptions
    {
        public BookStoreMongoModelBuilderConfigurationOptions(
            [NotNull] string collectionPrefix = "")
            : base(collectionPrefix)
        {
        }
    }
}