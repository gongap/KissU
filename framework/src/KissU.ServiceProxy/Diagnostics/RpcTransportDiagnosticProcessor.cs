﻿using System;
using System.Collections.Concurrent;
using System.Text;
using KissU.CPlatform;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Messages;
using KissU.Serialization;
using KissUEvents = KissU.CPlatform.Diagnostics.DiagnosticListenerExtensions;

namespace KissU.ServiceProxy.Diagnostics
{
    /// <summary>
    /// RpcTransportDiagnosticProcessor.
    /// Implements the <see cref="KissU.CPlatform.Diagnostics.ITracingDiagnosticProcessor" />
    /// </summary>
    /// <seealso cref="KissU.CPlatform.Diagnostics.ITracingDiagnosticProcessor" />
    public class RpcTransportDiagnosticProcessor : ITracingDiagnosticProcessor
    {
        private readonly ConcurrentDictionary<string, SegmentContext> _resultDictionary =
            new ConcurrentDictionary<string, SegmentContext>();

        private readonly ISerializer<string> _serializer;
        private readonly ITracingContext _tracingContext;
        private Func<TransportEventData, string> _transportOperationNameResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="RpcTransportDiagnosticProcessor" /> class.
        /// </summary>
        /// <param name="tracingContext">The tracing context.</param>
        /// <param name="serializer">The serializer.</param>
        public RpcTransportDiagnosticProcessor(ITracingContext tracingContext, ISerializer<string> serializer)
        {
            _tracingContext = tracingContext;
            _serializer = serializer;
        }

        /// <summary>
        /// Gets or sets the transport operation name resolver.
        /// </summary>
        /// <exception cref="ArgumentNullException">TransportOperationNameResolver</exception>
        public Func<TransportEventData, string> TransportOperationNameResolver
        {
            get
            {
                return _transportOperationNameResolver ??
                       (_transportOperationNameResolver = data => "Rpc-Transport:: " + data.Message.MessageName);
            }
            set => _transportOperationNameResolver =
                value ?? throw new ArgumentNullException(nameof(TransportOperationNameResolver));
        }

        /// <summary>
        /// Gets the name of the listener.
        /// </summary>
        public string ListenerName => KissUEvents.DiagnosticListenerName;

        /// <summary>
        /// Transports the before.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(KissUEvents.BeforeTransport, TransportType.Rpc)]
        public void TransportBefore([Object] TransportEventData eventData)
        {
            var message = eventData.Message.GetContent<RemoteInvokeMessage>();
            var operationName = TransportOperationNameResolver(eventData);
            var context = _tracingContext.CreateEntrySegmentContext(operationName,
                new RpcTransportCarrierHeaderCollection(eventData.Headers));
            if (!string.IsNullOrEmpty(eventData.TraceId))
                context.TraceId = ConvertUniqueId(eventData);
            context.Span.AddLog(LogEvent.Message($"Worker running at: {DateTime.Now}"));
            context.Span.SpanLayer = SpanLayer.RPC_FRAMEWORK;
            context.Span.Peer = new StringOrIntValue(eventData.RemoteAddress);
            context.Span.AddTag(Tags.RPC_METHOD, eventData.Method);
            context.Span.AddTag(Tags.RPC_PARAMETERS, _serializer.Serialize(message.Parameters));
            context.Span.AddTag(Tags.RPC_LOCAL_ADDRESS, AppConfig.GetHostAddress().ToString());
            _resultDictionary.TryAdd(eventData.OperationId.ToString(), context);
        }

        /// <summary>
        /// Transports the after.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(KissUEvents.AfterTransport, TransportType.Rpc)]
        public void TransportAfter([Object] ReceiveEventData eventData)
        {
            _resultDictionary.TryRemove(eventData.OperationId.ToString(), out var context);
            if (context != null)
            {
                _tracingContext.Release(context);
            }
        }

        /// <summary>
        /// Transports the error.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(KissUEvents.ErrorTransport, TransportType.Rpc)]
        public void TransportError([Object] TransportErrorEventData eventData)
        {
            _resultDictionary.TryRemove(eventData.OperationId.ToString(), out var context);
            if (context != null)
            {
                context.Span.ErrorOccurred(eventData.Exception);
                _tracingContext.Release(context);
            }
        }

        /// <summary>
        /// Converts the unique identifier.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        /// <returns>UniqueId.</returns>
        public UniqueId ConvertUniqueId(TransportEventData eventData)
        {
            long part1 = 0, part2 = 0, part3 = 0;
            var uniqueId = new UniqueId();
            var bytes = Encoding.Default.GetBytes(eventData.TraceId);
            part1 = BitConverter.ToInt64(bytes, 0);
            if (eventData.TraceId.Length > 8)
                part2 = BitConverter.ToInt64(bytes, 8);
            if (eventData.TraceId.Length > 16)
                part3 = BitConverter.ToInt64(bytes, 16);
            if (!string.IsNullOrEmpty(eventData.TraceId))
                uniqueId = new UniqueId(part1, part2, part3);
            return uniqueId;
        }
    }
}