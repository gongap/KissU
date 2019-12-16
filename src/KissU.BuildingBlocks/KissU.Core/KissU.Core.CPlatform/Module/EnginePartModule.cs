namespace KissU.Core.CPlatform.Module
{
    /// <summary>
    /// 引擎零件模块
    /// </summary>
    public class EnginePartModule : AbstractModule
    {
        public override void Initialize(AppModuleContext context)
        {
            base.Initialize(context);
        }

        public override void Dispose()
        {
            base.Dispose();
        }


        protected virtual void RegisterServiceBuilder(IServiceBuilder builder)
        {
        }


        internal override void RegisterComponents(ContainerBuilderWrapper builder)
        {
            base.RegisterComponents(builder);
          
        }
        
    }

}
