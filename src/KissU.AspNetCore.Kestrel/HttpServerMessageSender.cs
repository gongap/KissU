﻿using System;
using System.Diagnostics;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using KissU.AspNetCore.Abstractions;
using KissU.AspNetCore.Kestrel.Internal;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport;
using KissU.Serialization;
using KissUtil.Extensions;
using Microsoft.AspNetCore.Http;

namespace KissU.AspNetCore.Kestrel
{
    /// <summary>
    /// HttpServerMessageSender.
    /// Implements the <see cref="IMessageSender" />
    /// </summary>
    /// <seealso cref="IMessageSender" />
    public class HttpServerMessageSender : IMessageSender
    {
        private readonly HttpContext _context;
        private readonly ISerializer<string> _serializer;
        private readonly DiagnosticListener _diagnosticListener;

        public EndPoint RemoteAddress => new IPEndPoint(_context.Connection.RemoteIpAddress, _context.Connection.RemotePort);

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpServerMessageSender" /> class.
        /// </summary>
        /// <param name="serializer">The serializer.</param>
        /// <param name="httpContext">The HTTP context.</param>
        public HttpServerMessageSender(ISerializer<string> serializer, HttpContext httpContext)
        {
            _serializer = serializer;
            _context = httpContext;
            _diagnosticListener = new DiagnosticListener(string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Rest));
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
            var actionResult = httpMessage.Result as IActionResult;
            WirteDiagnostic(message);
            if (actionResult == null)
            {
                var result = httpMessage.Result;
                var isJson = result is string && JsonTool.IsJson(result.SafeString());
                if (isJson)
                {
                    httpMessage.Result = null;
                }

                var text = _serializer.Serialize(httpMessage);
                if (isJson)
                {
                    text = text.Replace("\"result\":null", $"\"result\":{result}");
                }

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
            if (!CPlatform.AppConfig.ServerOptions.DisableDiagnostic)
            {
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