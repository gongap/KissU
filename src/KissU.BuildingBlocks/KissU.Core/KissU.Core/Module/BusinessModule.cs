namespace KissU.Surging.CPlatform.Module
{
    /// <summary>
    /// 业务模块基类
    /// </summary>
    public class BusinessModule : AbstractModule
    {
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        public override void Initialize(AppModuleContext serviceProvider)
        {
            base.Initialize(serviceProvider);
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