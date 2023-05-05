using System.Net;
using KissUtil.Helpers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;

namespace KissU.AspNetCore
{
    /// <summary>
    /// WebHostContext.
    /// </summary>
    public class WebHostContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WebHostContext" /> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="options">The options.</param>
        /// <param name="ipAddress">The ip address.</param>
        public WebHostContext(WebHostBuilderContext context, KestrelServerOptions options, IPAddress ipAddress)
        {
            WebHostBuilderContext = CheckHelper.NotNull(context, nameof(context));
            KestrelOptions = CheckHelper.NotNull(options, nameof(options));
            Address = ipAddress;
        }

        /// <summary>
        /// Gets the web host builder context.
        /// </summary>
        public WebHostBuilderContext WebHostBuilderContext { get; }

        /// <summary>
        /// Gets the kestrel options.
        /// </summary>
        public KestrelServerOptions KestrelOptions { get; }

        /// <summary>
        /// Gets the address.
        /// </summary>
        public IPAddress Address { get; }
    }
}