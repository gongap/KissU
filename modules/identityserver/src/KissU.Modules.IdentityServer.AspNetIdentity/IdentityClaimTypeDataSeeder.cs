using System.Threading.Tasks;
using KissU.Modules.Identity.Domain;
using KissU.Modules.IdentityServer.Domain.IdentityResources;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace KissU.Modules.IdentityServer.AspNetIdentity
{
    public class IdentityClaimTypeDataSeeder : IIdentityClaimTypeDataSeeder, ITransientDependency
    {
        protected IIdentityClaimTypeRepository ClaimTypeRepository { get; }
        protected IGuidGenerator GuidGenerator { get; }

        public IdentityClaimTypeDataSeeder(
            IIdentityClaimTypeRepository claimTypeRepository,
            IGuidGenerator guidGenerator)
        {
            GuidGenerator = guidGenerator;
            ClaimTypeRepository = claimTypeRepository;
        }

        public virtual async Task CreateStandardClaimTypesAsync()
        {
            var resources = IdentityResource.GetStandardResources();

            foreach (var resource in resources)
            {
                foreach (var claimType in resource.UserClaims)
                {
                    await AddClaimTypeIfNotExistsAsync(claimType);
                }
            }
        }

        protected virtual async Task AddClaimTypeIfNotExistsAsync(string claimType)
        {
            if (await ClaimTypeRepository.AnyAsync(claimType))
            {
                return;
            }

            await ClaimTypeRepository.InsertAsync(
                new IdentityClaimType(
                    GuidGenerator.Create(),
                    claimType,
                    isStatic: true
                )
            );
        }
    }
}
