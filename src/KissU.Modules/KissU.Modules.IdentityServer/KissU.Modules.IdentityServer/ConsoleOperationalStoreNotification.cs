using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Modules.IdentityServer.Domain.Models;

namespace KissU.Modules.IdentityServer
{
    /// <summary>
    /// 凭证清理通知
    /// </summary>
    public class ConsoleOperationalStoreNotification : IOperationalStoreNotification
    {
        /// <summary>
        /// cleaned
        /// </summary>
        /// <param name="persistedGrants"></param>
        /// <returns></returns>
        public Task PersistedGrantsRemovedAsync(IEnumerable<PersistedGrant> persistedGrants)
        {
            foreach (var grant in persistedGrants) Console.WriteLine("cleaned: " + grant.Type);
            return Task.CompletedTask;
        }
    }
}