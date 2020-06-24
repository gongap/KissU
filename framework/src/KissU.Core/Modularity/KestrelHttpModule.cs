using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;

namespace KissU.Modularity
{
    /// <summary>
    /// KestrelHttpModule
    /// </summary>
    public class KestrelHttpModule : AbstractModule
    {
        /// <summary>
        /// Initializes the specified builder.
        /// </summary>
        /// <param name="context">The builder.</param>
        public virtual void Configure(ApplicationInitializationContext context)
        {
        }
    }
}