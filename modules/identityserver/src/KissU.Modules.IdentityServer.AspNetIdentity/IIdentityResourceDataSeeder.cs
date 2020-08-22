using System.Threading.Tasks;

namespace KissU.Modules.IdentityServer.AspNetIdentity
{
    public interface IIdentityResourceDataSeeder
    {
        Task CreateStandardResourcesAsync();
    }
}