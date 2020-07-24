using System;
using System.IO;
using KissU.Abp;
using KissU.Abp.Autofac;
using KissU.Modules.Blogging.Application;
using KissU.Modules.Blogging.Application.Files;
using KissU.Modules.Blogging.EntityFrameworkCore.EntityFrameworkCore;
using KissU.Services.Blogging.Contract;
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
    public class BloggingServiceModule : AbpModule, IAbpStartupModule
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