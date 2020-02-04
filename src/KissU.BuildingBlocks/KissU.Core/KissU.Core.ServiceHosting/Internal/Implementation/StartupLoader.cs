using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Autofac;
using KissU.Core.ServiceHosting.Startup.Implementation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace KissU.Core.ServiceHosting.Internal.Implementation
{
    /// <summary>
    /// 启动加载器
    /// </summary>
    public class StartupLoader
    {
        /// <summary>
        /// 加载方法
        /// </summary>
        /// <param name="hostingServiceProvider">服务提供程序</param>
        /// <param name="config">配置构建器</param>
        /// <param name="startupType">启动类型</param>
        /// <param name="environmentName">环境名</param>
        /// <returns>启动方法</returns>
        public static StartupMethods LoadMethods(IServiceProvider hostingServiceProvider, IConfigurationBuilder config,
            Type startupType, string environmentName)
        {
            ConfigureBuilder configureMethod = FindConfigureDelegate(startupType, environmentName);
            ConfigureServicesBuilder servicesMethod = FindConfigureServicesDelegate(startupType, environmentName);
            ConfigureContainerBuilder configureContainerMethod = FindConfigureContainerDelegate(startupType, environmentName);

            object instance = null;
            if (!configureMethod.MethodInfo.IsStatic || servicesMethod != null && !servicesMethod.MethodInfo.IsStatic)
            {
                instance = ActivatorUtilities.CreateInstance(hostingServiceProvider, startupType, config);
            }

            Func<ContainerBuilder, IContainer> configureServicesCallback = servicesMethod?.Build(instance);
            Action<object> configureContainerCallback = configureContainerMethod.Build(instance);

            Func<ContainerBuilder, IContainer> configureServices = services =>
            {
                IContainer applicationServiceProvider = configureServicesCallback.Invoke(services);
                if (applicationServiceProvider != null)
                {
                    return applicationServiceProvider;
                }

                if (configureContainerMethod.MethodInfo != null)
                {
                    Type serviceProviderFactoryType =
                        typeof(IServiceProviderFactory<>).MakeGenericType(configureContainerMethod.GetContainerType());
                    object serviceProviderFactory = hostingServiceProvider.GetRequiredService(serviceProviderFactoryType);
                    object builder = serviceProviderFactoryType
                        .GetMethod(nameof(DefaultServiceProviderFactory.CreateBuilder))
                        ?.Invoke(serviceProviderFactory, new object[] { services });
                    configureContainerCallback.Invoke(builder);
                    applicationServiceProvider = (IContainer)serviceProviderFactoryType
                        .GetMethod(nameof(DefaultServiceProviderFactory.CreateServiceProvider))
                        ?.Invoke(serviceProviderFactory, new[] { builder });
                }

                return applicationServiceProvider;
            };

            return new StartupMethods(instance, configureMethod.Build(instance), configureServices);
        }

        /// <summary>
        /// 查找启动类型
        /// </summary>
        /// <param name="startupAssemblyName">启动类型程序集</param>
        /// <param name="environmentName">环境名</param>
        /// <returns>启动类型</returns>
        /// <exception cref="ArgumentException">startupAssemblyName</exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="InvalidOperationException">startupAssemblyName</exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static Type FindStartupType(string startupAssemblyName, string environmentName)
        {
            if (string.IsNullOrEmpty(startupAssemblyName))
            {
                throw new ArgumentException(string.Format("'{0}' 不能为空.", nameof(startupAssemblyName)),
                    nameof(startupAssemblyName));
            }

            Assembly assembly = Assembly.Load(new AssemblyName(startupAssemblyName));
            if (assembly == null)
            {
                throw new InvalidOperationException(string.Format("程序集 '{0}' 错误不能加载", startupAssemblyName));
            }

            string startupNameWithEnv = "Startup" + environmentName;
            string startupNameWithoutEnv = "Startup";
            Type type =
                assembly.GetType(startupNameWithEnv) ??
                assembly.GetType(startupAssemblyName + "." + startupNameWithEnv) ??
                assembly.GetType(startupNameWithoutEnv) ??
                assembly.GetType(startupAssemblyName + "." + startupNameWithoutEnv);

            if (type == null)
            {
                System.Collections.Generic.List<TypeInfo> definedTypes = assembly.DefinedTypes.ToList();
                System.Collections.Generic.IEnumerable<TypeInfo> startupType1 = definedTypes.Where(info =>
                    info.Name.Equals(startupNameWithEnv, StringComparison.OrdinalIgnoreCase));
                System.Collections.Generic.IEnumerable<TypeInfo> startupType2 = definedTypes.Where(info =>
                    info.Name.Equals(startupNameWithoutEnv, StringComparison.OrdinalIgnoreCase));
                TypeInfo typeInfo = startupType1.Concat(startupType2).FirstOrDefault();
                if (typeInfo != null)
                {
                    type = typeInfo.AsType();
                }
            }

            if (type == null)
            {
                throw new InvalidOperationException(string.Format("类型 '{0}' 或者 '{1}' 不能从程序集 '{2}'找到.",
                    startupNameWithEnv,
                    startupNameWithoutEnv,
                    startupAssemblyName));
            }

            return type;
        }

        private static ConfigureBuilder FindConfigureDelegate(Type startupType, string environmentName)
        {
            MethodInfo configureMethod = FindMethod(startupType, "Configure{0}", environmentName, typeof(void));
            return new ConfigureBuilder(configureMethod);
        }

        private static ConfigureContainerBuilder FindConfigureContainerDelegate(Type startupType,
            string environmentName)
        {
            MethodInfo configureMethod =
                FindMethod(startupType, "Configure{0}Container", environmentName, typeof(void), false);
            return new ConfigureContainerBuilder(configureMethod);
        }

        private static ConfigureServicesBuilder FindConfigureServicesDelegate(Type startupType, string environmentName)
        {
            MethodInfo servicesMethod =
                FindMethod(startupType, "Configure{0}Services", environmentName, typeof(IContainer), false)
                ?? FindMethod(startupType, "Configure{0}Services", environmentName, typeof(void), false);
            return new ConfigureServicesBuilder(servicesMethod);
        }

        private static MethodInfo FindMethod(Type startupType, string methodName, string environmentName,
            Type returnType = null, bool required = true)
        {
            string methodNameWithEnv = string.Format(CultureInfo.InvariantCulture, methodName, environmentName);
            string methodNameWithNoEnv = string.Format(CultureInfo.InvariantCulture, methodName, "");

            MethodInfo[] methods = startupType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
            System.Collections.Generic.List<MethodInfo> selectedMethods = methods
                .Where(method => method.Name.Equals(methodNameWithEnv, StringComparison.OrdinalIgnoreCase)).ToList();
            if (selectedMethods.Count > 1)
            {
                throw new InvalidOperationException(string.Format("多个重载方法  '{0}' 不支持.", methodNameWithEnv));
            }

            if (selectedMethods.Count == 0)
            {
                selectedMethods = methods.Where(method =>
                    method.Name.Equals(methodNameWithNoEnv, StringComparison.OrdinalIgnoreCase)).ToList();
                if (selectedMethods.Count > 1)
                {
                    throw new InvalidOperationException(string.Format("多个重载方法  '{0}' 不支持.", methodNameWithNoEnv));
                }
            }

            MethodInfo methodInfo = selectedMethods.FirstOrDefault();
            if (methodInfo == null)
            {
                if (required)
                {
                    throw new InvalidOperationException(string.Format(
                        "公共方法名称必须为'{0}' 或者 '{1}' 找不到 '{2}' 类型.",
                        methodNameWithEnv,
                        methodNameWithNoEnv,
                        startupType.FullName));
                }

                return null;
            }

            if (returnType != null && methodInfo.ReturnType != returnType)
            {
                if (required)
                {
                    throw new InvalidOperationException(string.Format(
                        " '{0}'的方法在类型 '{1}' 必须有返回类型 '{2}'.",
                        methodInfo.Name,
                        startupType.FullName,
                        returnType.Name));
                }

                return null;
            }

            return methodInfo;
        }
    }
}