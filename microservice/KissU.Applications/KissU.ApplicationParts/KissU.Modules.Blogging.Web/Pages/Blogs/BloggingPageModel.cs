using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KissU.Modules.Blogging.Web.Pages.Blogs
{
    public abstract class BloggingPageModel : AbpPageModel
    {
        public BloggingPageModel()
        {
            ObjectMapperContext = typeof(BloggingWebModule);
        }
    }
}