using System.Threading.Tasks;
using KissU.Extensions;
using KissU.Modules.Identity.Service.Contracts;
using KissU.ServiceProxy;
using Volo.Abp.Identity;
using Volo.Abp.Users;

namespace KissU.Modules.Identity.Service.Implements
{
    /// <summary>
    /// Class UserLookupService.
    /// Implements the <see cref="ProxyServiceBase" />
    /// Implements the <see cref="IUserLookupService" />
    /// </summary>
    /// <seealso cref="ProxyServiceBase" />
    /// <seealso cref="IUserLookupService" />
    public class UserLookupService : ProxyServiceBase, IUserLookupService
    {
        private readonly IIdentityUserLookupAppService _lookupAppService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLookupService"/> class.
        /// </summary>
        /// <param name="lookupAppService">The lookup application service.</param>
        public UserLookupService(IIdentityUserLookupAppService lookupAppService)
        {
            _lookupAppService = lookupAppService;
        }

        /// <inheritdoc/>
        public virtual Task<UserData> FindById(string id)
        {
            return _lookupAppService.FindByIdAsync(id.ToGuid());
        }

        /// <inheritdoc/>
        public virtual Task<UserData> FindByUserName(string userName)
        {
            return _lookupAppService.FindByUserNameAsync(userName);
        }
    }
}