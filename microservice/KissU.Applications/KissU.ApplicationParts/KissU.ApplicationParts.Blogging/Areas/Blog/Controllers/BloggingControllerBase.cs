using KissU.Modules.Blogging.Domain.Shared.Localization.Blogging;
using Volo.Abp.AspNetCore.Mvc;

namespace KissU.ApplicationParts.Blogging.Areas.Blog.Controllers
{
    public abstract class BloggingControllerBase : AbpController
    {
        protected BloggingControllerBase()
        {
            ObjectMapperContext = typeof(BloggingWebModule);
            LocalizationResource = typeof(BloggingResource);
        }
    }
}