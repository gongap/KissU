using KissU.Core.Module;
using KissU.Surging.CPlatform.Module;
using KissU.Surging.System.MongoProvider.Repositories;

namespace KissU.Surging.System.MongoProvider
{
    /// <summary>
    /// MongoModule.
    /// Implements the <see cref="SystemModule" />
    /// </summary>
    /// <seealso cref="SystemModule" />
    public class MongoModule : SystemModule
    {
        /// <summary>
        /// Function module initialization,trigger when the module starts loading
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        /// <summary>
        /// Inject dependent third-party components
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void RegisterBuilder(ContainerBuilderWrapper builder)
        {
            base.RegisterBuilder(builder);
            builder.RegisterGeneric(typeof(MongoRepository<>)).As(typeof(IMongoRepository<>)).SingleInstance();
        }
    }
}