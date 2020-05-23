using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using KissU.Core.Serialization;
using KissU.Surging.CPlatform;
using KissU.Surging.CPlatform.Diagnostics;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.CPlatform.Transport;
using KissU.Surging.KestrelHttpServer.Abstractions;
using Microsoft.AspNetCore.Http;

namespace KissU.Surging.KestrelHttpServer
{
    /// <summary>
    /// HttpServerMessageSender.
    /// Implements the <see cref="KissU.Surging.CPlatform.Transport.IMessageSender" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Transport.IMessageSender" />
    public class HttpServerMessageSender : IMessageSender
    {
        private readonly HttpContext _context;
        private readonly ISerializer<string> _serializer;
        private readonly DiagnosticListener _diagnosticListener;

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpServerMessageSender" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        /// <param name="httpContext">The HTTP context.</param>
        public HttpServerMessageSender(ISerializer<string> serializer, HttpContext httpContext)
        {
            _serializer = serializer;
            _context = httpContext;
            _diagnosticListener = new DiagnosticListener(DiagnosticListenerExtensions.DiagnosticListenerName);
        }

        internal HttpServerMessageSender(ISerializer<string> serializer, HttpContext httpContext, DiagnosticListener diagnosticListener)
        {
            _serializer = serializer;
            _context = httpContext;
            _diagnosticListener = diagnosticListener;
        }

        /// <summary>
        /// send and flush as an asynchronous operation.
        /// </summary>
        /// <param name="message">消息内容。</param>
        /// <returns>一个任务。</returns>
        public async Task SendAndFlushAsync(TransportMessage message)
        {
            var httpMessage = message.GetContent<HttpResultMessage<object>>();
            var actionResult = httpMessage.Data as IActionResult;
            WirteDiagnostic(message);
            if (actionResult == null)
            {
                var text = _serializer.Serialize(message.Content);
                var data = Encoding.UTF8.GetBytes(text);
                var contentLength = data.Length;
                _context.Response.Headers.Add("Content-Type", "application/json;charset=utf-8");
                _context.Response.Headers.Add("Content-Length", contentLength.ToString());
                await _context.Response.WriteAsync(text);
            }
            else
            {
                await actionResult.ExecuteResultAsync(new ActionContext
                {
                    HttpContext = _context,
                    Message = message
                });
            }
        }

        /// <summary>
        /// send as an asynchronous operation.
        /// </summary>
        /// <param name="message">The message.</param>
        public async Task SendAsync(TransportMessage message)
        {
            await SendAndFlushAsync(message);
        }

        private void WirteDiagnostic(TransportMessage message)
        {
            if (!AppConfig.ServerOptions.DisableDiagnostic)
            {
                var diagnosticListener = new DiagnosticListener(DiagnosticListenerExtensions.DiagnosticListenerName);
                var remoteInvokeResultMessage = message.GetContent<HttpResultMessage>();
                if (remoteInvokeResultMessage.IsSucceed)
                {
                    _diagnosticListener.WriteTransportAfter(TransportType.Rest, new ReceiveEventData(new DiagnosticMessage
                        {
                            Content = message.Content,
                            ContentType = message.ContentType,
                            Id = message.Id
                        }));
                }
                else
                {
                    _diagnosticListener.WriteTransportError(TransportType.Rest, new TransportErrorEventData(new DiagnosticMessage
                    {
                            Content = message.Content,
                            ContentType = message.ContentType,
                            Id = message.Id
                        }, new Exception(remoteInvokeResultMessage.Message)));
                }
            }
        }
    }
}