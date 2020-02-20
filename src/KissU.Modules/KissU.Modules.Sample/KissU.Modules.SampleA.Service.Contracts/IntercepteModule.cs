using KissU.Core.CPlatform.Module;

namespace KissU.Modules.SampleA.Service.Contracts
{
    /// <summary>
    /// IntercepteModule.
    /// Implements the <see cref="KissU.Core.CPlatform.Module.SystemModule" />
    /// </summary>
    /// <seealso cref="KissU.Core.CPlatform.Module.SystemModule" />
    public class IntercepteModule : SystemModule
    {
        /// <summary>
        /// 初始化.
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
            //builder.AddClientIntercepted(typeof(CacheProviderInterceptor));
            //builder.AddClientIntercepted(typeof(LogProviderInterceptor));
        }
    }
}