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
        private readonly IIdentityUserLookupAppService _lookupAppService;

        public IdentityUserLookupService(IIdentityUserLookupAppService lookupAppService)
        {
            _lookupAppService = lookupAppService;
        }

        public virtual Task<UserData> FindByIdAsync(Guid id)
        {
            return _lookupAppService.FindByIdAsync(id);
        }

        public virtual Task<UserData> FindByUserNameAsync(string userName)
        {
            return _lookupAppService.FindByUserNameAsync(userName);
        }
    }
}