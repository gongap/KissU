using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts.Blogs;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace Volo.Blogging.Pages.Blog
{
    public class IndexModel : AbpPageModel
    {
        private readonly IBlogAppService _blogAppService;

        public IReadOnlyList<BlogDto> Blogs { get; private set; }

        public IndexModel(IBlogAppService blogAppService)
        {
            _blogAppService = blogAppService;
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            var result = await _blogAppService.GetListAsync();

            if (result.Items.Count == 1)
            {
                var blog = result.Items[0];
                return RedirectToPage("./Posts/Index", new { blogShortName = blog.ShortName });
            }

            Blogs = result.Items;

            return Page();
        }
    }
}
