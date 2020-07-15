using KissU.Modules.Blogging.Domain.Shared.Localization.Blogging;
using Volo.Abp.AspNetCore.Mvc;

namespace KissU.Modules.Blogging.Web.Areas.Blog.Controllers
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