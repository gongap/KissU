using Autofac;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace KissU.Autofac.Extensions
{
    /// <summary>
    /// 系统扩展 - AbpApplicationCreationOptions
    /// </summary>
    public static partial class Extensions
    {
        public static void UseAutofac(this AbpApplicationCreationOptions options)
        {
            var builder = new ContainerBuilder();
            options.Services.AddObjectAccessor(builder);
            options.Services.AddSingleton((IServiceProviderFactory<ContainerBuilder>) new AppAutofacServiceProviderFactory(builder));
        }
    }
}
