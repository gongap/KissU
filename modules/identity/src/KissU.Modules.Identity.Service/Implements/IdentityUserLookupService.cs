using System;
using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Extensions;
using KissU.Modules.Identity.Application.Contracts;
using KissU.Modules.Identity.Service.Contracts;
using KissU.Modules.Users.Abstractions;
using KissU.ServiceProxy;
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

        public virtual Task<UserData> FindByIdAsync(string id)
        {
            return _lookupAppService.FindByIdAsync(id.ToGuid());
        }

        public virtual Task<UserData> FindByUserNameAsync(string userName)
        {
            return _lookupAppService.FindByUserNameAsync(userName);
        }
    }
}