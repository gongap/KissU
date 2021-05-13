using System;
using System.Threading.Tasks;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Transport;
using KissU.DotNetty.Udp.Extensions;
using KissU.DotNetty.Udp.Runtime;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.Udp
{
    /// <summary>
    /// UdpServiceExecutor.
    /// Implements the <see cref="KissU.CPlatform.Runtime.Server.IServiceExecutor" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Runtime.Server.IServiceExecutor" />
    public class UdpServiceExecutor : IServiceExecutor
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="UdpServiceExecutor" /> class.
        /// </summary>
        /// <param name="dnsServiceEntryProvider">The DNS service entry provider.</param>
        /// <param name="logger">The logger.</param>
        public UdpServiceExecutor(IUdpServiceEntryProvider dnsServiceEntryProvider,
            ILogger<UdpServiceExecutor> logger)
        {
            _udpServiceEntryProvider = dnsServiceEntryProvider;
            _logger = logger;
        }

        #endregion Constructor

        #region Implementation of IServiceExecutor

        /// <summary>
        /// 执行。
        /// </summary>
        /// <param name="sender">消息发送者。</param>
        /// <param name="message">调用消息。</param>
        public async Task ExecuteAsync(IMessageSender sender, TransportMessage message)
        {
            if (_logger.IsEnabled(LogLevel.Trace))
                _logger.LogTrace("服务提供者接收到消息。");


            byte[] udpMessage = null;
            try
            {
                if (message.IsUdpDispatchMessage())
                    udpMessage = message.GetContent<byte[]>();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"将接收到的消息反序列化成 TransportMessage<byte[]> 时发送了错误：{exception.StackTrace}");
                return;
            }

            var entry = _udpServiceEntryProvider.GetEntry();
            if (entry == null)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError("未实现UdpBehavior实例。");
                return;
            }

            if (udpMessage != null)
                await LocalExecuteAsync(entry, udpMessage);

            await SendRemoteInvokeResult(sender, udpMessage);
        }

        #endregion Implementation of IServiceExecutor

        #region Field

        private readonly IUdpServiceEntryProvider _udpServiceEntryProvider;
        private readonly ILogger<UdpServiceExecutor> _logger;

        #endregion Field

        #region Private Method

        private async Task LocalExecuteAsync(UdpServiceEntry entry, byte[] bytes)
        {
            var resultMessage = new HttpResultMessage<object>();
            try
            {
                await entry.Behavior.Dispatch(bytes);
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                {
                    _logger.LogError(exception, $"执行远程调用逻辑时候发生了错误：Message：{exception.Message}，StackTrace：{exception.StackTrace}");
                }
            }
        }

        private async Task SendRemoteInvokeResult(IMessageSender sender, byte[] resultMessage)
        {
            try
            {
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace("准备发送响应消息。");

                await sender.SendAndFlushAsync(new TransportMessage(resultMessage));
                if (_logger.IsEnabled(LogLevel.Trace))
                    _logger.LogTrace("响应消息发送成功。");
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError(exception, $"发送响应消息时候发生了异常：{exception.StackTrace}");
            }
        }

        #endregion Private Method
    }
}