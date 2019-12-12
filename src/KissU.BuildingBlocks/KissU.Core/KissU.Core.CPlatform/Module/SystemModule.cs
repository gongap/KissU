namespace KissU.Core.CPlatform.Module
{
    /// <summary>
    /// 系统模块基类
    /// </summary>
   public class SystemModule : AbstractModule
    {
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }
        
        internal override void RegisterComponents(ContainerBuilderWrapper builder)
        {
            base.RegisterComponents(builder);
        }
    }
}

