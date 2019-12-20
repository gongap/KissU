using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Domain.Models.PersistedGrantAggregate;

namespace KissU.Modules.IdentityServer.Services
{
    /// <summary>
    /// Interface to model notifications from the TokenCleanup feature.
    /// </summary>
    public interface IOperationalStoreNotification
    {
        /// <summary>
        /// Notification for persisted grants being removed.
        /// </summary>
        /// <param name="persistedGrants"></param>
        /// <returns></returns>
        Task PersistedGrantsRemovedAsync(IEnumerable<PersistedGrant> persistedGrants);
    }
}