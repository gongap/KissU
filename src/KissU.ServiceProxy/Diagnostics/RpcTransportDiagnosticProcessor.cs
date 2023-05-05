using System;
using System.Collections.Concurrent;
using KissU.CPlatform;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Messages;
using KissU.CPlatform.Transport.Implementation;
using KissU.Serialization;
using SkyApm;
using SkyApm.Common;
using SkyApm.Config;
using SkyApm.Diagnostics;
using SkyApm.Tracing;
using SkyApm.Tracing.Segments;

namespace KissU.ServiceProxy.Diagnostics
{
    /// <summary>
    /// RpcTransportDiagnosticProcessor.
    /// Implements the <see cref="ITracingDiagnosticProcessor" />
    /// </summary>
    /// <seealso cref="ITracingDiagnosticProcessor" />
    public class RpcTransportDiagnosticProcessor : ITracingDiagnosticProcessor
    {
        private readonly ISerializer<string> _serializer;
        private readonly ITracingContext _tracingContext;
        private readonly TracingConfig _tracingConfig;
        private readonly ConcurrentDictionary<string, SegmentContext> _resultDictionary = new ConcurrentDictionary<string, SegmentContext>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RpcTransportDiagnosticProcessor" /> class.
        /// </summary>
        /// <param name="tracingContext">The tracing context.</param>
        /// <param name="configAccessor"></param>
        /// <param name="serializer">The serializer.</param>
        public RpcTransportDiagnosticProcessor(ITracingContext tracingContext, IConfigAccessor configAccessor, ISerializer<string> serializer)
        {
            _tracingContext = tracingContext;
            _tracingConfig = configAccessor.Get<TracingConfig>();
            _serializer = serializer;
        }

        /// <summary>
        /// Gets the name of the listener.
        /// </summary>
        public string ListenerName => string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Rpc);

        /// <summary>
        /// Transports the before.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.StartRpcTransport)]
        public void TransportStart([Object] TransportEventData eventData)
        {
            var host = eventData.RemoteAddress ?? "[::1]";
            var message = eventData.Message.GetContent<RemoteInvokeMessage>();
            var operationName = $"Rpc-Hosting :: {eventData.Message.MessageName}";
            var context = _tracingContext.CreateEntrySegmentContext(operationName,new RpcTransportCarrierHeaderCollection(eventData.Headers));
            context.Span.AddLog(LogEvent.Message($"Worker running at: {DateTime.Now}"));
            context.Span.SpanLayer = SpanLayer.RPC_FRAMEWORK;
            context.Span.Component = new StringOrIntValue(28, "ServiceComb");
            context.Span.Peer = new StringOrIntValue(host);
            context.Span.AddTag(CPlatform.Diagnostics.Tags.RPC_METHOD, eventData.Method);
            context.Span.AddTag(CPlatform.Diagnostics.Tags.RPC_PARAMETERS, _serializer.Serialize(message.Parameters));
            context.Span.AddTag(CPlatform.Diagnostics.Tags.RPC_LOCAL_ADDRESS, AppConfig.GetHostAddress().ToString());
            _resultDictionary.TryAdd(eventData.OperationId.ToString(), context);
        }

        /// <summary>
        /// Transports the before.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.BeforeRpcTransport)]
        public void TransportBefore([Object] TransportEventData eventData)
        {
            var host = eventData.RemoteAddress ?? "[::1]";
            var message = eventData.Message.GetContent<RemoteInvokeMessage>();
            var operationName = $"{host} :: {eventData.Message.MessageName}";
            var carrierHeader = new RpcTransportCarrierHeaderCollection(eventData.Headers);
            var context = _tracingContext.CreateExitSegmentContext(operationName, host, carrierHeader);
            context.Span.AddLog(LogEvent.Message($"Worker running at: {DateTime.Now}"));
            context.Span.SpanLayer = SpanLayer.RPC_FRAMEWORK;
            context.Span.Component = new StringOrIntValue(28, "ServiceComb");
            context.Span.Peer = new StringOrIntValue(host);
            context.Span.AddTag(CPlatform.Diagnostics.Tags.RPC_METHOD, eventData.Method);
            context.Span.AddTag(CPlatform.Diagnostics.Tags.RPC_PARAMETERS, _serializer.Serialize(message.Parameters));
            context.Span.AddTag(CPlatform.Diagnostics.Tags.RPC_LOCAL_ADDRESS, AppConfig.GetHostAddress().ToString());
            _resultDictionary.TryAdd(eventData.OperationId.ToString(), context);

            var parameters = RpcContext.GetContext().GetContextParameters();
            parameters.AddOrUpdate("TracingHeaders",carrierHeader.TracingHeaders, (_, _) => carrierHeader.TracingHeaders);
            RpcContext.GetContext().SetContextParameters(parameters);
        }

        /// <summary>
        /// Transports the after.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.AfterRpcTransport)]
        public void TransportAfter([Object] ReceiveEventData eventData)
        {
            _resultDictionary.TryRemove(eventData.OperationId.ToString(), out var context);
            //var context = _contextAccessor.Context;
            if (context != null)
            {
                context.Span?.AddLog(LogEvent.Event("RPC EndRequest"), LogEvent.Message("Request finished "));
                _tracingContext.Release(context);
            }
        }

        /// <summary>
        /// Transports the error.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.ErrorRpcTransport)]
        public void TransportError([Object] TransportErrorEventData eventData)
        {
            _resultDictionary.TryRemove(eventData.OperationId.ToString(), out var context);
            //var context = _contextAccessor.Context;
            if (context != null)
            {
                context.Span?.ErrorOccurred(eventData.Exception,_tracingConfig);
                _tracingContext.Release(context);
            }
        }
    }
}
