using KissU.Modules.BookStore.Localization;
using Volo.Abp.Application.Services;

namespace KissU.Modules.BookStore
{
    public abstract class BookStoreAppService : ApplicationService
    {
        protected BookStoreAppService()
        {
            LocalizationResource = typeof(BookStoreResource);
            ObjectMapperContext = typeof(BookStoreApplicationModule);
        }
    }
}
