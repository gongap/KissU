using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using KissU.Convertibles;
using KissU.Dependency;
using KissU.CPlatform.Filters.Implementation;
using KissU.CPlatform.Ids;
using KissU.CPlatform.Routing.Template;
using KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;
using KissU.CPlatform.Ioc;
using KissU.CPlatform.Messages;
using KissU.Exceptions;
using KissUtil.Exceptions;
using KissUtil.Helpers;
using KissUtil.TaskSources;

namespace KissU.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Implementation
{
    /// <summary>
    /// Clr������Ŀ������
    /// </summary>
    public class ClrServiceEntryFactory : IClrServiceEntryFactory
    {
        private readonly IServiceIdGenerator _serviceIdGenerator;
        private readonly CPlatformContainer _serviceProvider;
        private readonly ITypeConvertibleService _typeConvertibleService;
        private readonly ConcurrentDictionary<string, ManualResetValueTaskSource<TransportMessage>> _resultDictionary =
            new ConcurrentDictionary<string, ManualResetValueTaskSource<TransportMessage>>();

        /// <summary>
        /// Initializes a new instance of the <see cref="ClrServiceEntryFactory" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="serviceIdGenerator">The service identifier generator.</param>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        public ClrServiceEntryFactory(CPlatformContainer serviceProvider, IServiceIdGenerator serviceIdGenerator,
            ITypeConvertibleService typeConvertibleService)
        {
            _serviceProvider = serviceProvider;
            _serviceIdGenerator = serviceIdGenerator;
            _typeConvertibleService = typeConvertibleService;
        }

        /// <summary>
        /// ����������Ŀ��
        /// </summary>
        /// <param name="service">�������͡�</param>
        /// <returns>������Ŀ���ϡ�</returns>
        public IEnumerable<ServiceEntry> CreateServiceEntry(Type service, string defaultRouteTemplate= "api/{Service}/{Async}",  Func<MethodInfo, bool> disableNetwork = null, Func<MethodInfo, bool> enableAuthorization = null)
        {
            var routeTemplate = service.GetCustomAttribute<ServiceBundleAttribute>() ?? new ServiceBundleAttribute(defaultRouteTemplate);
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

                var isDisableNetwork = disableNetwork?.Invoke(methodInfo) ?? false;
                var isAuthorization = enableAuthorization?.Invoke(methodInfo) ?? false;
                yield return Create(methodInfo, service.Name, routeTemplateVal, isDisableNetwork, isAuthorization);
            }
        }

        /// <summary>
        /// ����������Ŀ.
        /// </summary>
        /// <param name="method">The method.</param>
        /// <param name="serviceName">Name of the service.</param>
        /// <param name="routeTemplate">The route template.</param>
        /// <returns>ServiceEntry.</returns>
        private ServiceEntry Create(MethodInfo method, string serviceName, string routeTemplate,  bool disableNetwork = false, bool isAuthorization = false)
        {
            var serviceId = _serviceIdGenerator.GenerateServiceId(method);
            var attributes = method.GetCustomAttributes().ToList();
            var serviceDescriptor = new ServiceDescriptor
            {
                Id = serviceId,
                RoutePath = RoutePatternParser.Parse(routeTemplate, serviceName, method.Name),
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

            if (disableNetwork)
            {
                serviceDescriptor.DisableNetwork(true);
            }

            var authorization = attributes.FirstOrDefault(p => p is AuthorizationFilterAttribute);
            if (authorization != null || isAuthorization)
            {
                serviceDescriptor.EnableAuthorization(true);
            }

            if (authorization != null)
            {
                serviceDescriptor.AuthType((authorization as AuthorizationAttribute)?.AuthType ?? AuthorizationType.JWTBearer);
            }

            var fastInvoker = GetHandler(serviceId, method);
            var isReactive = attributes.Any(p => p is ReactiveAttribute);
            return new ServiceEntry
            {
                Descriptor = serviceDescriptor,
                RoutePath = serviceDescriptor.RoutePath,
                Methods = httpMethods,
                MethodName = method.Name,
                Parameters = method.GetParameters(),
                Type = method.DeclaringType,
                Attributes = attributes,
                Func = async (key, parameters) =>
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

                    var methodParameters = method.GetParameters();
                    foreach (var parameterInfo in methodParameters)
                    {
                        GetInvokerParameters(parameterInfo, parameters, list);
                    }

                    if (list.Count == 0 && methodParameters.Length == 1)
                    {
                        var parameterInfo = methodParameters.First();
                        var parameter = _typeConvertibleService.Convert(parameters, parameterInfo.ParameterType);
                        if (parameter != null)
                        {
                            list.Add(parameter);
                        }
                        else
                        {
                            throw new Warning($"参数名不匹配：{parameterInfo.Name?.ToLower()}");
                        }
                    }

                    var invokerParameters = new object[methodParameters.Length];
                    Array.Copy(list.ToArray(), invokerParameters, list.Count);
                    if (!isReactive)
                    {
                        var result = fastInvoker(instance, invokerParameters);
                        return await Task.FromResult(result);
                    }
                    else
                    {
                        var serviceBehavior = instance as IServiceBehavior;
                        var callbackTask = RegisterResultCallbackAsync(serviceBehavior.MessageId, Task.Factory.CancellationToken);
                        serviceBehavior.Received += MessageListener_Received;
                        var result = fastInvoker(instance, invokerParameters);
                        return await callbackTask;
                    }
                }
            };
        }

        private void GetInvokerParameters(ParameterInfo parameterInfo, IDictionary<string, object> parameters, List<object> list)
        {
            if (parameterInfo.Name != null)
            {
                var parameterInfoName = parameterInfo.Name.ToLower();
                //加入是否有默认值的判断，有默认值，并且用户没传，取默认值
                if (parameterInfo.HasDefaultValue && parameters.Keys.All(x => x.ToLower() != parameterInfoName))
                {
                    list.Add(parameterInfo.DefaultValue);
                    return;
                }
                else if (parameterInfo.ParameterType == typeof(CancellationToken))
                {
                    list.Add(new CancellationToken());
                    return;
                }

                var parameterName = parameters.Keys.FirstOrDefault(x => x.ToLower() == parameterInfoName);
                if (parameterName != null && parameters.ContainsKey(parameterName))
                {
                    var value = parameters[parameterName];
                    var parameterType = parameterInfo.ParameterType;
                    var parameter = _typeConvertibleService.Convert(value, parameterType);
                    list.Add(parameter);
                }
                //else
                //{
                //    throw new Warning($"参数名不匹配：{parameterInfoName}");
                //}
            }
        }

        /// <summary>
        /// ��ȡ��������.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="method">The method.</param>
        /// <returns>FastInvokeHandler.</returns>
        private FastInvoke.FastInvokeHandler GetHandler(string key, MethodInfo method)
        {
            var objInstance = ServiceResolver.Current.GetService(null, key);
            if (objInstance == null)
            {
                objInstance = FastInvoke.GetMethodInvoker(method);
                ServiceResolver.Current.Register(key, objInstance, null);
            }

            return objInstance as FastInvoke.FastInvokeHandler;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task<object> RegisterResultCallbackAsync(string id, CancellationToken cancellationToken)
        {

            var task = new ManualResetValueTaskSource<TransportMessage>();
            _resultDictionary.TryAdd(id, task);
            try
            {
                var result = await task.AwaitValue(cancellationToken);
                return result.GetContent<ReactiveResultMessage>()?.Result;
            }
            finally
            {
                //删除回调任务
                ManualResetValueTaskSource<TransportMessage> value;
                _resultDictionary.TryRemove(id, out value);
                value.SetCanceled();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private async Task MessageListener_Received(TransportMessage message)
        {
            ManualResetValueTaskSource<TransportMessage> task;
            if (!_resultDictionary.TryGetValue(message.Id, out task))
                return;

            if (message.IsReactiveMessage())
            {
                var content = message.GetContent<ReactiveResultMessage>();
                if (!string.IsNullOrEmpty(content.ExceptionMessage))
                {
                    task.SetException(new CPlatformCommunicationException(content.ExceptionMessage, statusCode: content.StatusCode));
                }
                else
                {
                    task.SetResult(message);
                }
            }
        }
    }
}
