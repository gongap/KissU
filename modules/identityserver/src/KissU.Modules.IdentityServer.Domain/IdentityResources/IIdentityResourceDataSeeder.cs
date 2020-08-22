using System.Threading.Tasks;

namespace KissU.Modules.IdentityServer.Domain.IdentityResources
{
    public interface IIdentityResourceDataSeeder
    {
        Task CreateStandardResourcesAsync();
    }
}