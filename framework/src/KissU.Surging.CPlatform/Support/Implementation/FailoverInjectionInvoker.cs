using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Convertibles;
using KissU.Surging.CPlatform.Runtime.Server;

namespace KissU.Surging.CPlatform.Support.Implementation
{
    /// <summary>
    /// 故障转移注入调用者.
    /// Implements the <see cref="IClusterInvoker" />
    /// </summary>
    /// <seealso cref="IClusterInvoker" />
    public class FailoverInjectionInvoker : IClusterInvoker
    {
        /// <summary>
        /// The service command provider
        /// </summary>
        public readonly IServiceCommandProvider _serviceCommandProvider;

        /// <summary>
        /// The service entry manager
        /// </summary>
        public readonly IServiceEntryManager _serviceEntryManager;

        private readonly ITypeConvertibleService _typeConvertibleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FailoverInjectionInvoker" /> class.
        /// </summary>
        /// <param name="serviceCommandProvider">The service command provider.</param>
        /// <param name="serviceEntryManager">The service entry manager.</param>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        public FailoverInjectionInvoker(IServiceCommandProvider serviceCommandProvider,
            IServiceEntryManager serviceEntryManager, ITypeConvertibleService typeConvertibleService)
        {
            _serviceCommandProvider = serviceCommandProvider;
            _serviceEntryManager = serviceEntryManager;
            _typeConvertibleService = typeConvertibleService;
        }

        /// <summary>
        /// 调用.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="decodeJOject">if set to <c>true</c> [decode j oject].</param>
        /// <returns>Task.</returns>
        public async Task Invoke(IDictionary<string, object> parameters, string serviceId, string serviceKey,
            bool decodeJOject)
        {
            var vt = _serviceCommandProvider.GetCommand(serviceId);
            var command = vt.IsCompletedSuccessfully ? vt.Result : await vt;
            var result = await _serviceCommandProvider.Run(command.Injection, command.InjectionNamespaces);
            if (result is bool)
            {
                if ((bool) result)
                {
                    var entries = _serviceEntryManager.GetEntries().ToList();
                    var entry = entries.Where(p => p.Descriptor.Id == serviceId).FirstOrDefault();
                    await entry.Func(serviceKey, parameters);
                }
            }
        }

        /// <summary>
        /// 调用.
        /// </summary>
        /// <typeparam name="T">The result type</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="serviceKey">The service key.</param>
        /// <param name="decodeJOject">if set to <c>true</c> [decode j oject].</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> Invoke<T>(IDictionary<string, object> parameters, string serviceId, string serviceKey,
            bool decodeJOject)
        {
            var vt = _serviceCommandProvider.GetCommand(serviceId);
            var command = vt.IsCompletedSuccessfully ? vt.Result : await vt;
            var injectionResult = await _serviceCommandProvider.Run(command.Injection, command.InjectionNamespaces);
            if (injectionResult is bool)
            {
                if ((bool) injectionResult)
                {
                    var entries = _serviceEntryManager.GetEntries().ToList();
                    var entry = entries.Where(p => p.Descriptor.Id == serviceId).FirstOrDefault();
                    var message = await entry.Func(serviceKey, parameters);
                    object result = default(T);
                    if (message == null && message is Task<T>)
                    {
                        result = _typeConvertibleService.Convert((message as Task<T>).Result, typeof(T));
                    }

                    return (T) result;
                }
            }
            else
            {
                var result = injectionResult;
                if (injectionResult is Task<T>)
                {
                    result = _typeConvertibleService.Convert((injectionResult as Task<T>).Result, typeof(T));
                }

                return (T) result;
            }

            return default;
        }
    }
}