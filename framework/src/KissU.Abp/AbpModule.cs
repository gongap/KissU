using KissU.Abp.Business.Exceptions;
using KissU.Exceptions.Handling;
using KissU.Modularity;

namespace KissU.Abp.Business
{
    public class AbpModule : SystemModule
    {
        /// <summary>
        /// 注册第三方组件
        /// </summary>
        /// <param name="builder">容器构建器</param>
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            builder.RegisterType<AbpExceptionToErrorInfoConverter>().As<IExceptionToErrorInfoConverter>().SingleInstance();
        }
    }
}