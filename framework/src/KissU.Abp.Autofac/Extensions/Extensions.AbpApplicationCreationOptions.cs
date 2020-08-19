using System;
using Autofac;
using KissU.Abp.Autofac.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;

namespace KissU.Abp.Autofac.Extensions
{
    /// <summary>
    /// 系统扩展 - AbpApplicationCreationOptions
    /// </summary>
    public static partial class Extensions
    {
        public static void UseAutofac(this AbpApplicationCreationOptions options, Action<IContainer> configureDelegates)
        {
            UseAutofac(options, null, configureDelegates);
        }

        public static void UseAutofac(this AbpApplicationCreationOptions options, Action<ContainerBuilder> configurationAction = null, Action<IContainer> configureDelegates = null)
        {
            var builder = new ContainerBuilder();
            options.Services.AddObjectAccessor(builder);
            options.Services.AddSingleton((IServiceProviderFactory<ContainerBuilder>) new AutofacServiceProviderFactory(builder, configurationAction, configureDelegates));
        }
    }
}
