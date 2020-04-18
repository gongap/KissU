using System;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Users;

namespace Volo.Abp.Identity
{
    [ModuleName("IdentityUserLookup")]
    public class IdentityUserLookupService : ProxyServiceBase, IIdentityUserLookupService
    {
        protected IIdentityUserLookupAppService LookupAppService { get; }

        public IdentityUserLookupService(IIdentityUserLookupAppService lookupAppService)
        {
            LookupAppService = lookupAppService;
        }

        public virtual Task<UserData> FindByIdAsync(Guid id)
        {
            return LookupAppService.FindByIdAsync(id);
        }

        public virtual Task<UserData> FindByUserNameAsync(string userName)
        {
            return LookupAppService.FindByUserNameAsync(userName);
        }
    }
}
