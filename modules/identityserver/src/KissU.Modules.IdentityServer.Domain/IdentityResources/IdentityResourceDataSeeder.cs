using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Guids;

namespace KissU.Modules.IdentityServer.Domain.IdentityResources
{
    public class IdentityResourceDataSeeder : IIdentityResourceDataSeeder, ITransientDependency
    {
        protected IIdentityResourceRepository IdentityResourceRepository { get; }
        protected IGuidGenerator GuidGenerator { get; }

        public IdentityResourceDataSeeder(
            IIdentityResourceRepository identityResourceRepository,
            IGuidGenerator guidGenerator)
        {
            IdentityResourceRepository = identityResourceRepository;
            GuidGenerator = guidGenerator;
        }

        public virtual async Task CreateStandardResourcesAsync()
        {
            var resources = IdentityResource.GetStandardResources();

            foreach (var resource in resources)
            {
                await AddIdentityResourceIfNotExistsAsync(resource);
            }
        }

        protected virtual async Task AddIdentityResourceIfNotExistsAsync(IdentityServer4.Models.IdentityResource resource)
        {
            if (await IdentityResourceRepository.CheckNameExistAsync(resource.Name))
            {
                return;
            }

            await IdentityResourceRepository.InsertAsync(
                new IdentityResource(
                    GuidGenerator.Create(),
                    resource
                )
            );
        }
    }
}
