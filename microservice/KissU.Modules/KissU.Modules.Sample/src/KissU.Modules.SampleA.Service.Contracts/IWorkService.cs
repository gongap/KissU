﻿using System.Threading.Tasks;
using KissU.Dependency;
using KissU.Modules.SampleA.Service.Contracts.Dtos;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// Interface IWorkService
    /// Implements the <see cref="IServiceKey" />
    /// </summary>
    /// <seealso cref="IServiceKey" />
    [ServiceBundle("Background/{Service}")]
    public interface IWorkService : IServiceKey
    {
        /// <summary>
        /// Adds the work.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> AddWork(Message message);

        /// <summary>
        /// Starts the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task StartAsync();

        /// <summary>
        /// Stops the asynchronous.
        /// </summary>
        /// <returns>Task.</returns>
        Task StopAsync();
    }
}