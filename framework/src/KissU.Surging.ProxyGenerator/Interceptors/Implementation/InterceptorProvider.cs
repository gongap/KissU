using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using KissU.Surging.CPlatform.Runtime.Server;

namespace KissU.Surging.ProxyGenerator.Interceptors.Implementation
{
    /// <summary>
    /// InterceptorProvider.
    /// Implements the <see cref="KissU.Surging.ProxyGenerator.Interceptors.IInterceptorProvider" />
    /// </summary>
    /// <seealso cref="KissU.Surging.ProxyGenerator.Interceptors.IInterceptorProvider" />
    public class InterceptorProvider : IInterceptorProvider
    {
        private readonly IServiceEntryManager _serviceEntryManager;

        private readonly ConcurrentDictionary<Tuple<Type, Type>, bool> _derivedTypes =
            new ConcurrentDictionary<Tuple<Type, Type>, bool>();

        /// <summary>
        /// Initializes a new instance of the <see cref="InterceptorProvider" /> class.
        /// </summary>
        /// <param name="serviceEntryManager">The service entry manager.</param>
        public InterceptorProvider(IServiceEntryManager serviceEntryManager)
        {
            _serviceEntryManager = serviceEntryManager;
        }

        /// <summary>
        /// Gets the invocation.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <returns>IInvocation.</returns>
        public IInvocation GetInvocation(object proxy, IDictionary<string, object> parameters,
            string serviceId, Type returnType)
        {
            var constructor = InvocationMethods.CompositionInvocationConstructor;
            return constructor.Invoke(new[]
            {
                parameters,
                serviceId,
                null,
                null,
                returnType,
                proxy
            }) as IInvocation;
        }

        /// <summary>
        /// Gets the cache invocation.
        /// </summary>
        /// <param name="proxy">The proxy.</param>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="returnType">Type of the return.</param>
        /// <returns>IInvocation.</returns>
        public IInvocation GetCacheInvocation(object proxy, IDictionary<string, object> parameters,
            string serviceId, Type returnType)
        {
            var entry = (from q in _serviceEntryManager.GetAllEntries()
                let k = q.Attributes
                where q.Descriptor.Id == serviceId
                select q).FirstOrDefault();
            var constructor = InvocationMethods.CompositionInvocationConstructor;
            return constructor.Invoke(new[]
            {
                parameters,
                serviceId,
                GetKey(parameters),
                entry.Attributes,
                returnType,
                proxy
            }) as IInvocation;
        }

        public string[] GetCacheKeyVaule(IDictionary<string, object> parameterValue)
        {
            return this.GetKey(parameterValue);
        }

        private string[] GetKey(IDictionary<string, object> parameterValue)
        {
            var param = parameterValue.Values.FirstOrDefault();
            var reuslt = default(string[]);
            if (parameterValue.Count() > 0)
            {
                reuslt = new[] {param.ToString()};
                if (!(param is IEnumerable))
                {
                    var runtimeProperties = param.GetType().GetRuntimeProperties();
                    var properties = (from q in runtimeProperties
                        let k = q.GetCustomAttribute<KeyAttribute>()
                        where k != null
                        orderby k.SortIndex
                        select q).ToList();

                    reuslt = properties.Count() > 0
                        ? properties.Select(p => p.GetValue(parameterValue.Values.FirstOrDefault()).ToString())
                            .ToArray()
                        : reuslt;
                }
            }

            return reuslt;
        }

        private bool IsKeyAttributeDerivedType(Type baseType, Type derivedType)
        {
            var result = false;
            var key = Tuple.Create(baseType, derivedType);
            if (!_derivedTypes.ContainsKey(key))
            {
                result = _derivedTypes.GetOrAdd(key, derivedType.IsSubclassOf(baseType) || derivedType == baseType);
            }
            else
            {
                _derivedTypes.TryGetValue(key, out result);
            }

            return result;
        }
    }
}