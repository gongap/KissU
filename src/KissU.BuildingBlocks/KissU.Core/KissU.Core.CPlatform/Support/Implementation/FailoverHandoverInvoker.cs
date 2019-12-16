using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core.CPlatform.Convertibles;
using KissU.Core.CPlatform.Messages;
using KissU.Core.CPlatform.Runtime.Client;

namespace KissU.Core.CPlatform.Support.Implementation
{
    public class FailoverHandoverInvoker: IClusterInvoker
    {
        #region Field
        private readonly IRemoteInvokeService _remoteInvokeService;
        private readonly ITypeConvertibleService _typeConvertibleService;
        private readonly IBreakeRemoteInvokeService _breakeRemoteInvokeService;
        private readonly IServiceCommandProvider _commandProvider;
        #endregion Field

        #region Constructor

        public FailoverHandoverInvoker(IRemoteInvokeService remoteInvokeService, IServiceCommandProvider commandProvider,
            ITypeConvertibleService typeConvertibleService, IBreakeRemoteInvokeService breakeRemoteInvokeService)
        {
            _remoteInvokeService = remoteInvokeService;
            _typeConvertibleService = typeConvertibleService;
            _breakeRemoteInvokeService = breakeRemoteInvokeService;
            _commandProvider = commandProvider;
        }

        #endregion Constructor

        public async Task<T> Invoke<T>(IDictionary<string, object> parameters, string serviceId, string _serviceKey, bool decodeJOject)
        {
            var time = 0;
            T result = default(T);
            RemoteInvokeResultMessage message = null;
            var vtCommand = _commandProvider.GetCommand(serviceId);
            var command = vtCommand.IsCompletedSuccessfully ? vtCommand.Result : await vtCommand;
            do
            {
                message = await _breakeRemoteInvokeService.InvokeAsync(parameters, serviceId, _serviceKey, decodeJOject);
                if (message != null && message.Result != null)
                    result = (T)_typeConvertibleService.Convert(message.Result, typeof(T));
            }
            while (message == null && ++time < command.FailoverCluster);
            return result;
        }

        public async Task Invoke(IDictionary<string, object> parameters, string serviceId, string _serviceKey, bool decodeJOject)
        {
            var time = 0;
            var vtCommand = _commandProvider.GetCommand(serviceId);
            var command = vtCommand.IsCompletedSuccessfully ? vtCommand.Result : await vtCommand;
            while (await _breakeRemoteInvokeService.InvokeAsync(parameters, serviceId, _serviceKey, decodeJOject) == null && ++time < command.FailoverCluster) ;
        }
    }

}
