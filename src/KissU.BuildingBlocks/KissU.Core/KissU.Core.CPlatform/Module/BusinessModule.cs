namespace KissU.Core.CPlatform.Module
{
    /// <summary>
    ///  业务模块基类
    /// </summary>
    public class BusinessModule : AbstractModule
    {
        public override void Initialize(AppModuleContext serviceProvider)
        {
            base.Initialize(serviceProvider);
        }
        
        internal override void RegisterComponents(ContainerBuilderWrapper builder)
        {
            base.RegisterComponents(builder);
        }
    }
}
