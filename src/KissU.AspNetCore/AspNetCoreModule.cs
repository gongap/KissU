using KissU.AspNetCore.Internal;
using KissU.Modularity;

namespace KissU.AspNetCore
{
    /// <summary>
    /// AspNetCoreKestrelModule
    /// </summary>
    public class AspNetCoreModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="context">The builder.</param>
        public virtual void Configure(ApplicationInitializationContext context)
        {
        }

        /// <summary>
        /// Registers the builder.
        /// </summary>
        /// <param name="context">The context.</param>
        public virtual void ConfigureWebHost(WebHostContext context)
        {
        }
    }
}
