using KissU.Modules.Blogging.Domain.Shared.Localization.Blogging;
using Volo.Abp.Application.Services;

namespace KissU.Modules.Blogging.Application
{
    public abstract class BloggingAppServiceBase : ApplicationService
    {
        protected BloggingAppServiceBase()
        {
            ObjectMapperContext = typeof(BloggingApplicationModule);
            LocalizationResource = typeof(BloggingResource);
        }
    }
}