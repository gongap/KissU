namespace KissU.Module
{
    /// <summary>
    /// 系统模块基类
    /// </summary>
    public class SystemModule : AbstractModule
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
        /// 注册组件
        /// </summary>
        /// <param name="builder">构建器包装</param>
        internal override void RegisterComponents(ContainerBuilderWrapper builder)
        {
            base.RegisterComponents(builder);
        }
    }
}