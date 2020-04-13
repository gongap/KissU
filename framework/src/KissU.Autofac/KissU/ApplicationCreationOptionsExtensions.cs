using Autofac;
using KissU.Autofac;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace KissU
{
    public static class ApplicationCreationOptionsExtensions
    {
        public static void UseAutofac(this AbpApplicationCreationOptions options)
        {
            var builder = new ContainerBuilder();
            options.Services.AddObjectAccessor(builder);
            options.Services.AddSingleton((IServiceProviderFactory<ContainerBuilder>) new AutofacServiceProviderFactory(builder));
        }
    }
}
