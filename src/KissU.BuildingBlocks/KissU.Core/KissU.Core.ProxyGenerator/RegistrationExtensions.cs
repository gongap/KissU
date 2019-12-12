using System;
using KissU.Core.CPlatform.Module;
using KissU.Core.ProxyGenerator.Interceptors;
using KissU.Core.ProxyGenerator.Interceptors.Implementation;

namespace KissU.Core.ProxyGenerator
{
    public static class  RegistrationExtensions
    {
        public static void AddClientIntercepted(this ContainerBuilderWrapper builder,  Type interceptorServiceType)
        { 
            builder.RegisterType(interceptorServiceType).As<IInterceptor>().SingleInstance();
            builder.RegisterType<InterceptorProvider>().As<IInterceptorProvider>().SingleInstance();
        }

        public static void AddClientIntercepted(this ContainerBuilderWrapper builder, params Type[] interceptorServiceTypes)
        { 
            builder.RegisterTypes(interceptorServiceTypes).As<IInterceptor>().SingleInstance();
            builder.RegisterType<InterceptorProvider>().As<IInterceptorProvider>().SingleInstance();
     
        }
    }
}
