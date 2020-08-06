﻿using System.Threading.Tasks;
using KissU.Modules.SampleB.Service.Contracts;
using KissU.ServiceProxy;

namespace KissU.Modules.SampleB.Service.Implements
{
    /// <summary>
    /// ManagerService.
    /// Implements the <see cref="ProxyServiceBase" />
    /// Implements the <see cref="IManagerService" />
    /// </summary>
    /// <seealso cref="ProxyServiceBase" />
    /// <seealso cref="IManagerService" />
    public class ManagerService : ProxyServiceBase, IManagerService
    {
        /// <summary>
        /// Says the hello.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        public Task<string> SayHello(string name)
        {
            return Task.FromResult($"{name} say:hello");
        }
    }
}