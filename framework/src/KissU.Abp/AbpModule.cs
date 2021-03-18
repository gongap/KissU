﻿using Autofac;
using KissU.Exceptions.Handling;
using KissU.Modularity;

namespace KissU.Abp
{
    public class AbpModule : SystemModule
    {
        protected override void ConfigureContainer(ContainerBuilderWrapper builder)
        {
            builder.RegisterType(typeof(AbpExceptionToErrorInfoConverter)).AsImplementedInterfaces()
                .Named("Abp", typeof(IExceptionToErrorInfoConverter)).SingleInstance();
        }
    }
}