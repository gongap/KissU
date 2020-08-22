using KissU.Modules.AuditLogging.Domain;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace KissU.Modules.AuditLogging.EntityFrameworkCore
{
    [DependsOn(typeof(AbpAuditLoggingDomainModule))]
    [DependsOn(typeof(AbpEntityFrameworkCoreModule))]
    public class AbpAuditLoggingEntityFrameworkCoreModule : AbpModule
    {
        public override void ConfigureServices(ServiceConfigurationContext context)
        {
            context.Services.AddAbpDbContext<AbpAuditLoggingDbContext>(options =>
            {
                options.AddRepository<AuditLog, EfCoreAuditLogRepository>();
            });
        }
    }
}
