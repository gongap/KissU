using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using KissU.Surging.CPlatform.Convertibles;
using KissU.Surging.CPlatform.DependencyResolution;
using KissU.Surging.CPlatform.Filters.Implementation;
using KissU.Surging.CPlatform.Ids;
using KissU.Surging.CPlatform.Routing.Template;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.Surging.CPlatform.Validation;
using static KissU.Surging.CPlatform.Utilities.FastInvoke;

namespace KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Implementation
{
    /// <summary>
    /// Clr������Ŀ������
    /// </summary>
    public class ClrServiceEntryFactory : IClrServiceEntryFactory
    {
        private readonly IServiceIdGenerator _serviceIdGenerator;
        private readonly CPlatformContainer _serviceProvider;
        private readonly ITypeConvertibleService _typeConvertibleService;
        private readonly IValidationProcessor _validationProcessor;

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrServiceEntryFactory" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="serviceIdGenerator">The service identifier generator.</param>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        /// <param name="validationProcessor">The validation processor.</param>
        public ClrServiceEntryFactory(CPlatformContainer serviceProvider, IServiceIdGenerator serviceIdGenerator,
            ITypeConvertibleService typeConvertibleService, IValidationProcessor validationProcessor)
        {
            _serviceProvider = serviceProvider;
            _serviceIdGenerator = serviceIdGenerator;
            _typeConvertibleService = typeConvertibleService;
            _validationProcessor = validationProcessor;
        }

        /// <summary>
        /// ����������Ŀ��
        /// </summary>
        /// <param name="service">�������͡�</param>
        /// <returns>������Ŀ���ϡ�</returns>
        public IEnumerable<ServiceEntry> CreateServiceEntry(Type service)
        {
            var routeTemplate = service.GetCustomAttribute<ServiceBundleAttribute>();
            foreach (var methodInfo in service.GetTypeInfo().GetMethods())
            {
                var serviceRoute = methodInfo.GetCustomAttribute<ServiceRouteAttribute>();
                var routeTemplateVal = routeTemplate.RouteTemplate;
                if (!routeTemplate.IsPrefix && serviceRoute != null)
                {
                    routeTemplateVal = serviceRoute.Template;
                }
                else if (routeTemplate.IsPrefix && serviceRoute != null)
                {
                    routeTemplateVal = $"{routeTemplate.RouteTemplate}/{serviceRoute.Template}";
                }

                yield return Create(methodInfo, service.Name, routeTemplateVal);
            }
        }

        /// <summary>
        /// ����������Ŀ.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="routeTemplate">The route template.</param>
        /// <returns>ServiceEntry.</returns>
        private ServiceEntry Create(MethodInfo method, string serviceName, string routeTemplate)
        {
            var serviceId = _serviceIdGenerator.GenerateServiceId(method);
            var attributes = method.GetCustomAttributes().ToList();
            var serviceDescriptor = new ServiceDescriptor
            {
                Id = serviceId,
                RoutePath = RoutePatternParser.Parse(routeTemplate, serviceName, method.Name)
            };
            var descriptorAttributes = method.GetCustomAttributes<ServiceDescriptorAttribute>();
            foreach (var descriptorAttribute in descriptorAttributes)
            {
                descriptorAttribute.Apply(serviceDescriptor);
            }

            var httpMethodAttributes = attributes.Where(p => p is HttpMethodAttribute)
                .Select(p => p as HttpMethodAttribute).ToList();
            var httpMethods = new List<string>();
            var httpMethod = new StringBuilder();
            foreach (var attribute in httpMethodAttributes)
            {
                httpMethods.AddRange(attribute.HttpMethods);
                if (attribute.IsRegisterMetadata)
                {
                    httpMethod.AppendJoin(',', attribute.HttpMethods).Append(",");
                }
            }

            if (httpMethod.Length > 0)
            {
                httpMethod.Length = httpMethod.Length - 1;
                serviceDescriptor.HttpMethod(httpMethod.ToString());
            }

            var authorization = attributes.Where(p => p is AuthorizationFilterAttribute).FirstOrDefault();
            if (authorization != null)
            {
                serviceDescriptor.EnableAuthorization(true);
            }

            if (authorization != null)
            {
                serviceDescriptor.AuthType((authorization as AuthorizationAttribute)?.AuthType ??
                                           AuthorizationType.AppSecret);
            }

            var fastInvoker = GetHandler(serviceId, method);

            var methodValidateAttribute =
                attributes.Where(p => p is ValidateAttribute).Cast<ValidateAttribute>().FirstOrDefault();

            return new ServiceEntry
            {
                Descriptor = serviceDescriptor,
                RoutePath = serviceDescriptor.RoutePath,
                Methods = httpMethods,
                MethodName = method.Name,
                Type = method.DeclaringType,
                Attributes = attributes,
                Func = (key, parameters) =>
                {
                    object instance = null;
                    if (AppConfig.ServerOptions.IsModulePerLifetimeScope)
                    {
                        instance = _serviceProvider.GetInstancePerLifetimeScope(key, method.DeclaringType);
                    }
                    else
                    {
                        instance = _serviceProvider.GetInstances(key, method.DeclaringType);
                    }

                    var list = new List<object>();

                    foreach (var parameterInfo in method.GetParameters())
                    {
                        // �����Ƿ���Ĭ��ֵ���жϣ���Ĭ��ֵ�������û�û����ȡĬ��ֵ
                        if (parameterInfo.HasDefaultValue && !parameters.ContainsKey(parameterInfo.Name))
                        {
                            list.Add(parameterInfo.DefaultValue);
                            continue;
                        }

                        var value = parameters[parameterInfo.Name];

                        if (methodValidateAttribute != null)
                        {
                            _validationProcessor.Validate(parameterInfo, value);
                        }

                        var parameterType = parameterInfo.ParameterType;
                        var parameter = _typeConvertibleService.Convert(value, parameterType);
                        list.Add(parameter);
                    }

                    var result = fastInvoker(instance, list.ToArray());
                    return Task.FromResult(result);
                }
            };
        }

        /// <summary>
        /// ��ȡ��������.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="method">The method.</param>
        /// <returns>FastInvokeHandler.</returns>
        private FastInvokeHandler GetHandler(string key, MethodInfo method)
        {
            var objInstance = ServiceResolver.Current.GetService(null, key);
            if (objInstance == null)
            {
                objInstance = GetMethodInvoker(method);
                ServiceResolver.Current.Register(key, objInstance, null);
            }

            return objInstance as FastInvokeHandler;
        }
    }
}