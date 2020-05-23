using System;
using System.Threading.Tasks;
using KissU.Core.Dependency;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Surging.ProxyGenerator;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace KissU.Modules.Identity.Service.Implements
{
    [ModuleName("IdentityUserLookup")]
    public class IdentityUserLookupService : ProxyServiceBase, IIdentityUserLookupService
    {
        public IdentityUserLookupService(IIdentityUserLookupAppService lookupAppService)
        {
            LookupAppService = lookupAppService;
        }

        protected IIdentityUserLookupAppService LookupAppService { get; }

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