﻿using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Services.SampleA.Contract;
using KissU.Surging.Protocol.Udp.Runtime;

namespace KissU.Modules.SampleA.Service.Implements
{
    /// <summary>
    /// UdpService.
    /// Implements the <see cref="KissU.Surging.Protocol.Udp.Runtime.UdpBehavior" />
    /// Implements the <see cref="IUdpService" />
    /// </summary>
    /// <seealso cref="KissU.Surging.Protocol.Udp.Runtime.UdpBehavior" />
    /// <seealso cref="IUdpService" />
    public class UdpService : UdpBehavior, IUdpService
    {
        /// <summary>
        /// Dispatches the specified bytes.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public override async Task<bool> Dispatch(IEnumerable<byte> bytes)
        {
            await GetService<IMediaService>().Push(bytes);
            return await Task.FromResult(true);
        }
    }
}