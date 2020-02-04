using System;
using System.Collections.Generic;
using System.Reflection;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Features.GeneratedFactories;
using Autofac.Features.LightweightAdapters;
using Autofac.Features.OpenGenerics;
using Autofac.Features.Scanning;

namespace KissU.Core.System.Module
{
    /// <summary>
    /// RegistrationExtensions.
    /// </summary>
    public static class RegistrationExtensions
    {
        /// <summary>
        /// Registers the specified delegate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="delegate">The delegate.</param>
        /// <returns>IRegistrationBuilder&lt;T, SimpleActivatorData, SingleRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> Register<T>(this ContainerBuilderWrapper builder, Func<IComponentContext, T> @delegate)
        {
            return builder.ContainerBuilder.Register(@delegate);
        }

        /// <summary>
        /// Registers the specified delegate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="delegate">The delegate.</param>
        /// <returns>IRegistrationBuilder&lt;T, SimpleActivatorData, SingleRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> Register<T>(this ContainerBuilderWrapper builder, Func<IComponentContext, IEnumerable<Parameter>, T> @delegate)
        {
            return builder.ContainerBuilder.Register(@delegate);
        }

        /// <summary>
        /// Registers the module.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="module">The module.</param>
        public static void RegisterModule(this ContainerBuilderWrapper builder, IModule module)
        {
            builder.ContainerBuilder.RegisterModule(module);
        }

        /// <summary>
        /// Registers the module.
        /// </summary>
        /// <typeparam name="TModule">The type of the t module.</typeparam>
        /// <param name="builder">The builder.</param>
        public static void RegisterModule<TModule>(this ContainerBuilderWrapper builder)
            where TModule : IModule, new()
        {
            builder.ContainerBuilder.RegisterModule<TModule>();
        }

        /// <summary>
        /// Registers the instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="instance">The instance.</param>
        /// <returns>IRegistrationBuilder&lt;T, SimpleActivatorData, SingleRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<T, SimpleActivatorData, SingleRegistrationStyle> RegisterInstance<T>(this ContainerBuilderWrapper builder, T instance)
            where T : class
        {
            return builder.ContainerBuilder.RegisterInstance(instance);
        }

        /// <summary>
        /// Registers the type.
        /// </summary>
        /// <typeparam name="TImplementor">The type of the t implementor.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <returns>IRegistrationBuilder&lt;TImplementor, ConcreteReflectionActivatorData, SingleRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<TImplementor, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType<TImplementor>(this ContainerBuilderWrapper builder)
        {
            return builder.ContainerBuilder.RegisterType<TImplementor>();
        }

        /// <summary>
        /// Registers the type.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="implementationType">Type of the implementation.</param>
        /// <returns>IRegistrationBuilder&lt;System.Object, ConcreteReflectionActivatorData, SingleRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<object, ConcreteReflectionActivatorData, SingleRegistrationStyle> RegisterType(this ContainerBuilderWrapper builder, Type implementationType)
        {
            return builder.ContainerBuilder.RegisterType(implementationType);
        }

        /// <summary>
        /// Registers the assembly types.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="assemblies">The assemblies.</param>
        /// <returns>IRegistrationBuilder&lt;System.Object, ScanningActivatorData, DynamicRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterAssemblyTypes(this ContainerBuilderWrapper builder, params Assembly[] assemblies)
        {
            return builder.ContainerBuilder.RegisterAssemblyTypes(assemblies);
        }

        /// <summary>
        /// Registers the generic.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="implementor">The implementor.</param>
        /// <returns>IRegistrationBuilder&lt;System.Object, ReflectionActivatorData, DynamicRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<object, ReflectionActivatorData, DynamicRegistrationStyle> RegisterGeneric(this ContainerBuilderWrapper builder, Type implementor)
        {
            return builder.ContainerBuilder.RegisterGeneric(implementor);
        }

        /// <summary>
        /// Registers the adapter.
        /// </summary>
        /// <typeparam name="TFrom">The type of the t from.</typeparam>
        /// <typeparam name="TTo">The type of the t to.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="adapter">The adapter.</param>
        /// <returns>IRegistrationBuilder&lt;TTo, LightweightAdapterActivatorData, DynamicRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<TTo, LightweightAdapterActivatorData, DynamicRegistrationStyle> RegisterAdapter<TFrom, TTo>(this ContainerBuilderWrapper builder, Func<TFrom, TTo> adapter)
        {
            return builder.ContainerBuilder.RegisterAdapter(adapter);
        }

        /// <summary>
        /// Registers the generic decorator.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="decoratorType">Type of the decorator.</param>
        /// <param name="decoratedServiceType">Type of the decorated service.</param>
        /// <param name="fromKey">From key.</param>
        /// <param name="toKey">To key.</param>
        /// <returns>IRegistrationBuilder&lt;System.Object, OpenGenericDecoratorActivatorData, DynamicRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<object, OpenGenericDecoratorActivatorData, DynamicRegistrationStyle> RegisterGenericDecorator(this ContainerBuilderWrapper builder, Type decoratorType, Type decoratedServiceType, object fromKey, object toKey = null)
        {
            return builder.ContainerBuilder.RegisterGenericDecorator(decoratorType, decoratedServiceType, fromKey, toKey);
        }

        /// <summary>
        /// Registers the decorator.
        /// </summary>
        /// <typeparam name="TService">The type of the t service.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <param name="decorator">The decorator.</param>
        /// <param name="fromKey">From key.</param>
        /// <param name="toKey">To key.</param>
        /// <returns>IRegistrationBuilder&lt;TService, LightweightAdapterActivatorData, DynamicRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<TService, LightweightAdapterActivatorData, DynamicRegistrationStyle> RegisterDecorator<TService>(this ContainerBuilderWrapper builder, Func<TService, TService> decorator, object fromKey, object toKey = null)
        {
            return builder.ContainerBuilder.RegisterDecorator(decorator, fromKey, toKey);
        }


        /// <summary>
        /// Registers the generated factory.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="delegateType">Type of the delegate.</param>
        /// <returns>IRegistrationBuilder&lt;Delegate, GeneratedFactoryActivatorData, SingleRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<Delegate, GeneratedFactoryActivatorData, SingleRegistrationStyle> RegisterGeneratedFactory(this ContainerBuilderWrapper builder, Type delegateType)
        {
            return builder.ContainerBuilder.RegisterGeneratedFactory(delegateType);
        }

        /// <summary>
        /// Registers the generated factory.
        /// </summary>
        /// <typeparam name="TDelegate">The type of the t delegate.</typeparam>
        /// <param name="builder">The builder.</param>
        /// <returns>IRegistrationBuilder&lt;TDelegate, GeneratedFactoryActivatorData, SingleRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<TDelegate, GeneratedFactoryActivatorData, SingleRegistrationStyle> RegisterGeneratedFactory<TDelegate>(this ContainerBuilderWrapper builder)
            where TDelegate : class
        {
            return builder.ContainerBuilder.RegisterGeneratedFactory<TDelegate>();
        }

        /// <summary>
        /// Registers the repositories.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="repositoriesAssemblies">The repositories assemblies.</param>
        /// <returns>IRegistrationBuilder&lt;System.Object, ScanningActivatorData, DynamicRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterRepositories(this ContainerBuilderWrapper builder, params Assembly[] repositoriesAssemblies)
        {
            return builder.RegisterAssemblyTypes(repositoriesAssemblies)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsInheritedClasses()
                .AsImplementedInterfaces();
        }

        /// <summary>
        /// Registers the services.
        /// </summary>
        /// <param name="builder">The builder.</param>
        /// <param name="serviceAssemblies">The service assemblies.</param>
        /// <returns>IRegistrationBuilder&lt;System.Object, ScanningActivatorData, DynamicRegistrationStyle&gt;.</returns>
        public static IRegistrationBuilder<object, ScanningActivatorData, DynamicRegistrationStyle> RegisterServices(this ContainerBuilderWrapper builder, params Assembly[] serviceAssemblies)
        {
            return builder.RegisterAssemblyTypes(serviceAssemblies)
                .Where(t => t.Name.EndsWith("Service"))
                .AsInheritedClasses()
                .AsImplementedInterfaces();
        }

        /// <summary>
        /// Ases the inherited classes.
        /// </summary>
        /// <typeparam name="TLimit">The type of the t limit.</typeparam>
        /// <param name="registration">The registration.</param>
        /// <returns>IRegistrationBuilder&lt;TLimit, ScanningActivatorData, DynamicRegistrationStyle&gt;.</returns>
        /// <exception cref="ArgumentNullException">registration</exception>
        public static IRegistrationBuilder<TLimit, ScanningActivatorData, DynamicRegistrationStyle> AsInheritedClasses<TLimit>(this IRegistrationBuilder<TLimit, ScanningActivatorData, DynamicRegistrationStyle> registration)
        {
            if (registration == null) throw new ArgumentNullException("registration");
            return registration.As(t => GetInheritedClasses(t));
        }

        private static List<Type> GetInheritedClasses(Type type)
        {
            List<Type> types = new List<Type>();

            Func<Type, Type> GetBaseType = (t) =>
            {
                if (t.GetTypeInfo().BaseType != null && t.GetTypeInfo().BaseType != typeof(object))
                {
                    types.Add(t.GetTypeInfo().BaseType);
                    return t.GetTypeInfo().BaseType;
                }

                return null;
            };

            Type baseType = type;

            do
            {
                baseType = GetBaseType(baseType);
            }
            while (baseType != null);

            return types;
        }
    }
}
