using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Convertibles;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.CPlatform.Runtime.Client;

namespace KissU.Surging.CPlatform.Support.Implementation
{
    /// <summary>
    /// 故障转移移交调用者.
    /// Implements the <see cref="IClusterInvoker" />
    /// </summary>
    /// <seealso cref="IClusterInvoker" />
    public class FailoverHandoverInvoker : IClusterInvoker
    {
        private readonly IBreakeRemoteInvokeService _breakeRemoteInvokeService;
        private readonly IServiceCommandProvider _commandProvider;
        private readonly IRemoteInvokeService _remoteInvokeService;
        private readonly ITypeConvertibleService _typeConvertibleService;

        /// <summary>
        /// Initializes a new instance of the <see cref="FailoverHandoverInvoker" /> class.
        /// </summary>
        /// <param name="remoteInvokeService">The remote invoke service.</param>
        /// <param name="commandProvider">The command provider.</param>
        /// <param name="typeConvertibleService">The type convertible service.</param>
        /// <param name="breakeRemoteInvokeService">The breake remote invoke service.</param>
        public FailoverHandoverInvoker(IRemoteInvokeService remoteInvokeService,
            IServiceCommandProvider commandProvider, ITypeConvertibleService typeConvertibleService,
            IBreakeRemoteInvokeService breakeRemoteInvokeService)
        {
            _remoteInvokeService = remoteInvokeService;
            _typeConvertibleService = typeConvertibleService;
            _breakeRemoteInvokeService = breakeRemoteInvokeService;
            _commandProvider = commandProvider;
        }

        /// <summary>
        /// 调用.
        /// </summary>
        /// <typeparam name="T">The result type</typeparam>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="_serviceKey">The service key.</param>
        /// <param name="decodeJOject">if set to <c>true</c> [decode j oject].</param>
        /// <returns>Task&lt;T&gt;.</returns>
        public async Task<T> Invoke<T>(IDictionary<string, object> parameters, string serviceId, string _serviceKey,
            bool decodeJOject)
        {
            var time = 0;
            T result = default;
            RemoteInvokeResultMessage message = null;
            var vtCommand = _commandProvider.GetCommand(serviceId);
            var command = vtCommand.IsCompletedSuccessfully ? vtCommand.Result : await vtCommand;
            do
            {
                message = await _breakeRemoteInvokeService.InvokeAsync(parameters, serviceId, _serviceKey,
                    decodeJOject);
                if (message != null && message.Result != null)
                {
                    result = (T) _typeConvertibleService.Convert(message.Result, typeof(T));
                }
            } while (message == null && ++time < command.FailoverCluster);

            return result;
        }

        /// <summary>
        /// Invokes the specified parameters.
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <param name="serviceId">The service identifier.</param>
        /// <param name="_serviceKey">The service key.</param>
        /// <param name="decodeJOject">if set to <c>true</c> [decode j oject].</param>
        /// <returns>A <see cref="Task" /> representing the asynchronous operation.</returns>
        public async Task Invoke(IDictionary<string, object> parameters, string serviceId, string _serviceKey,
            bool decodeJOject)
        {
            var time = 0;
            var vtCommand = _commandProvider.GetCommand(serviceId);
            var command = vtCommand.IsCompletedSuccessfully ? vtCommand.Result : await vtCommand;
            while (await _breakeRemoteInvokeService.InvokeAsync(parameters, serviceId, _serviceKey, decodeJOject) ==
                   null && ++time < command.FailoverCluster)
            {
            }
        }
    }
}