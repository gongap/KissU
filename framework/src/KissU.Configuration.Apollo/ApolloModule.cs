using KissU.Modularity;
using KissU.Configuration.Apollo.Configurations;

namespace KissU.Configuration.Apollo
{
    /// <summary>
    /// ApolloModule.
    /// Implements the <see cref="EnginePartModule" />
    /// </summary>
    /// <seealso cref="EnginePartModule" />
    public class ApolloModule : EnginePartModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(ModuleInitializationContext context)
        {
            var serviceProvider = context.ServiceProvoider;
            base.Initialize(context);
            serviceProvider.GetInstances<IConfigurationFactory>().Create();
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">构建器包装</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            base.ConfigureContainer(builder);
            builder.RegisterType(typeof(ConfigurationFactory)).As(typeof(IConfigurationFactory));
        }
    }
}