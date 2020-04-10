namespace KissU.Core.Module
{
    /// <summary>
    /// 引擎零件模块
    /// </summary>
    public class EnginePartModule : AbstractModule
    {
        /// <summary>
        /// Initializes the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public override void Dispose()
        {
            base.Dispose();
        }

        /// <summary>
        /// Registers the service builder.
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected virtual void RegisterServiceBuilder(IServiceBuilder builder)
        {
        }

        /// <summary>
        /// 注册组件
        /// </summary>
        /// <param name="builder">构建器包装</param>
        internal override void RegisterComponents(ContainerBuilderWrapper builder)
        {
            base.RegisterComponents(builder);
        }
    }
}