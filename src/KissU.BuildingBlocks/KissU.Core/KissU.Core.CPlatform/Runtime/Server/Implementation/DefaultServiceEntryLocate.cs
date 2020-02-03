using System;
using System.Linq;
using System.Runtime.CompilerServices;
using KissU.Core.CPlatform.Messages;

namespace KissU.Core.CPlatform.Runtime.Server.Implementation
{
    /// <summary>
    /// 默认的服务条目定位器。
    /// </summary>
    public class DefaultServiceEntryLocate : IServiceEntryLocate
    {
        private readonly IServiceEntryManager _serviceEntryManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="DefaultServiceEntryLocate" /> class.
        /// </summary>
        /// <param name="serviceEntryManager">The service entry manager.</param>
        public DefaultServiceEntryLocate(IServiceEntryManager serviceEntryManager)
        {
            _serviceEntryManager = serviceEntryManager;
        }

        /// <summary>
        /// 定位服务条目。
        /// </summary>
        /// <param name="invokeMessage">远程调用消息。</param>
        /// <returns>服务条目。</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ServiceEntry Locate(RemoteInvokeMessage invokeMessage)
        {
            var serviceEntries = _serviceEntryManager.GetEntries();
            return serviceEntries.SingleOrDefault(i => i.Descriptor.Id == invokeMessage.ServiceId);
        }

        /// <summary>
        /// 定位服务条目.
        /// </summary>
        /// <param name="httpMessage">The HTTP message.</param>
        /// <returns>ServiceEntry.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ServiceEntry Locate(HttpRequestMessage httpMessage)
        {
            var routePath = httpMessage.RoutePath;
            if (httpMessage.RoutePath.AsSpan().IndexOf("/") == -1)
            {
                routePath = $"/{routePath}";
            }

            var serviceEntries = _serviceEntryManager.GetAllEntries();
            return serviceEntries.SingleOrDefault(i =>
                i.RoutePath == routePath && !i.Descriptor.GetMetadata<bool>("IsOverload"));
        }
    }
}