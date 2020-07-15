using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.Blogging.Application.Contracts.Blogs.Dtos;
using KissU.Modules.Blogging.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc.UI.RazorPages;

namespace KissU.Modules.Blogging.Web.Pages.Blogs
{
    public class IndexModel : AbpPageModel
    {
        private readonly IBlogService _blogService;

        public IReadOnlyList<BlogDto> Blogs { get; private set; }

        public IndexModel(IServiceProxyFactory serviceProxyFactory)
        {
            _blogService = serviceProxyFactory.CreateProxy<IBlogService>();
        }

        public virtual async Task<IActionResult> OnGetAsync()
        {
            var result = await _blogService.GetListAsync();

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
