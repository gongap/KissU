using System;
using System.IO;
using System.Linq;
using KissU.Abp.Autofac;
using KissU.Modules.Blogging.Application;
using KissU.Modules.Blogging.Application.Files;
using KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore;
using KissU.Modules.Blogging.Service.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.Blogging.Service
{
    [DependsOn(
        typeof(BloggingServiceContractsModule),
        typeof(BloggingApplicationModule),
        typeof(BloggingEntityFrameworkCoreModule),
        typeof(AbpAutofacModule)
    )]
    public class BloggingServiceModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            Configure<AbpDbContextOptions>(options =>
            {
                options.UseSqlServer();
            });

            Configure<BlogFileOptions>(options =>
            {
                options.FileUploadLocalFolder = Path.Combine(AppContext.BaseDirectory, "files");
            });

            context.Services.AddAlwaysAllowAuthorization();
        }
    }
}