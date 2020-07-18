using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KissU.ApplicationParts.Blogging.Pages.Blogs
{
    public abstract class BloggingPageModel : AbpPageModel
    {
        public BloggingPageModel()
        {
            ObjectMapperContext = typeof(BloggingWebModule);
        }
    }
}