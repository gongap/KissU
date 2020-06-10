using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace KissU.Modules.Identity.Domain
{
    public class IdentityDataSeedContributor : IDataSeedContributor, ITransientDependency
    {
        protected IIdentityDataSeeder IdentityDataSeeder { get; }

        public IdentityDataSeedContributor(IIdentityDataSeeder identityDataSeeder)
        {
            IdentityDataSeeder = identityDataSeeder;
        }

        public virtual Task SeedAsync(DataSeedContext context)
        {
            return IdentityDataSeeder.SeedAsync(
                context["AdminEmail"] as string ?? "admin@abp.io",
                context["AdminPassword"] as string ?? "adminP@ss123",
                context.TenantId
            );
        }
    }
}
