using System;
using System.Threading.Tasks;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Runtime.Server;
using KissU.CPlatform.Transport;
using KissU.DotNetty.DNS.Extensions;
using KissU.DotNetty.DNS.Runtime;
using Microsoft.Extensions.Logging;

namespace KissU.DotNetty.DNS
{
    /// <summary>
    /// DnsServiceExecutor.
    /// Implements the <see cref="KissU.CPlatform.Runtime.Server.IServiceExecutor" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Runtime.Server.IServiceExecutor" />
    public class DnsServiceExecutor : IServiceExecutor
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DnsServiceExecutor" /> class.
        /// </summary>
        /// <param name="dnsServiceEntryProvider">The DNS service entry provider.</param>
        /// <param name="logger">The logger.</param>
        public DnsServiceExecutor(IDnsServiceEntryProvider dnsServiceEntryProvider,
            ILogger<DnsServiceExecutor> logger)
        {
            _dnsServiceEntryProvider = dnsServiceEntryProvider;
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

            if (!message.IsDnsResultMessage())
                return;
            DnsTransportMessage dnsTransportMessage;
            try
            {
                dnsTransportMessage = message.GetContent<DnsTransportMessage>();
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, $"将接收到的消息反序列化成 TransportMessage<DnsTransportMessage> 时发送了错误。错误信息：{exception.Message}");
                return;
            }

            var entry = _dnsServiceEntryProvider.GetEntry();
            if (entry == null)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError("未实现DnsBehavior实例。");
                return;
            }

            await LocalExecuteAsync(entry, dnsTransportMessage);
            await SendRemoteInvokeResult(sender, dnsTransportMessage);
        }

        #endregion Implementation of IServiceExecutor

        #region Field

        private readonly IDnsServiceEntryProvider _dnsServiceEntryProvider;
        private readonly ILogger<DnsServiceExecutor> _logger;

        #endregion Field

        #region Private Method

        private async Task<DnsTransportMessage> LocalExecuteAsync(DnsServiceEntry entry, DnsTransportMessage message)
        {
            var resultMessage = new HttpResultMessage<object>();
            try
            {
                var dnsQuestion = message.DnsQuestion;
                message.Address = await entry.Behavior.DomainResolve(dnsQuestion.Name);
            }
            catch (Exception exception)
            {
                if (_logger.IsEnabled(LogLevel.Error))
                    _logger.LogError(exception, $"执行本地逻辑时候发生了错误：{exception.StackTrace}");
            }

            return message;
        }

        private async Task SendRemoteInvokeResult(IMessageSender sender, DnsTransportMessage resultMessage)
        {
            try
            {
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug("准备发送响应消息。");

                await sender.SendAndFlushAsync(new TransportMessage(resultMessage));
                if (_logger.IsEnabled(LogLevel.Debug))
                    _logger.LogDebug("响应消息发送成功。");
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