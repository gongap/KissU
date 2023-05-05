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
using Tags = KissU.CPlatform.Diagnostics.Tags;

namespace KissU.DotNetty.Mqtt.Diagnostics
{
    /// <summary>
    /// MqttTransportDiagnosticProcessor.
    /// Implements the <see cref="ITracingDiagnosticProcessor" />
    /// </summary>
    /// <seealso cref="ITracingDiagnosticProcessor" />
    public class MqttTransportDiagnosticProcessor : ITracingDiagnosticProcessor
    {
        private readonly ISerializer<string> _serializer;
        private readonly ITracingContext _tracingContext;
        private readonly TracingConfig _tracingConfig;
        private readonly ConcurrentDictionary<string, SegmentContext> _resultDictionary = new ConcurrentDictionary<string, SegmentContext>();

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttTransportDiagnosticProcessor" /> class.
        /// </summary>
        /// <param name="tracingContext">The tracing context.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="contextAccessor">The context accessor.</param>
        public MqttTransportDiagnosticProcessor(ITracingContext tracingContext, IConfigAccessor configAccessor,ISerializer<string> serializer)
        {
            _tracingContext = tracingContext;
            _serializer = serializer;
            _tracingConfig = configAccessor.Get<TracingConfig>();
        }

        /// <summary>
        /// Gets the name of the listener.
        /// </summary>
        public string ListenerName => string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Mqtt);

        /// <summary>
        /// Transports the before.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.StartMqttTransport)]
        public void TransportStart([Object] TransportEventData eventData)
        {
            var host = eventData.RemoteAddress ?? "[::1]";
            var message = eventData.Message.GetContent<RemoteInvokeMessage>();
            var operationName = $"Mqtt-Hosting :: {eventData.Message.MessageName}";
            var context = _tracingContext.CreateEntrySegmentContext(operationName, new MqttTransportCarrierHeaderCollection(eventData.Headers));
            context.Span.AddLog(LogEvent.Message($"Worker running at: {DateTime.Now}"));
            context.Span.SpanLayer = SpanLayer.RPC_FRAMEWORK;
            context.Span.AddTag(Tags.MQTT_CLIENT_ID, context.TraceId);
            context.Span.AddTag(Tags.MQTT_METHOD, eventData.Method);
            context.Span.AddTag(Tags.REST_PARAMETERS, _serializer.Serialize(message.Parameters));
            context.Span.AddTag(Tags.MQTT_BROKER_ADDRESS, AppConfig.GetHostAddress().ToString());
            _resultDictionary.TryAdd(eventData.OperationId.ToString(), context);
        }

        /// <summary>
        /// Transports the before.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.BeforeMqttTransport)]
        public void TransportBefore([Object] TransportEventData eventData)
        {
            var host = eventData.RemoteAddress ?? "[::1]";
            var message = eventData.Message.GetContent<RemoteInvokeMessage>();
            var operationName = $"{host} :: {eventData.Message.MessageName}";
            var carrierHeader = new MqttTransportCarrierHeaderCollection(eventData.Headers);
            var context = _tracingContext.CreateExitSegmentContext(operationName, host, carrierHeader);
            context.Span.AddLog(LogEvent.Message($"Worker running at: {DateTime.Now}"));
            context.Span.SpanLayer = SpanLayer.RPC_FRAMEWORK;
            context.Span.Component = new StringOrIntValue(28, "ServiceComb");
            context.Span.AddTag(Tags.MQTT_CLIENT_ID, context.TraceId);
            context.Span.AddTag(Tags.MQTT_METHOD, eventData.Method);
            context.Span.AddTag(Tags.REST_PARAMETERS, _serializer.Serialize(message.Parameters));
            context.Span.AddTag(Tags.MQTT_BROKER_ADDRESS, AppConfig.GetHostAddress().ToString());
            _resultDictionary.TryAdd(eventData.OperationId.ToString(), context);

            var parameters = RpcContext.GetContext().GetContextParameters();
            parameters.AddOrUpdate("TracingHeaders",carrierHeader.TracingHeaders, (_, _) => carrierHeader.TracingHeaders);
            RpcContext.GetContext().SetContextParameters(parameters);
        }

        /// <summary>
        /// Transports the after.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.AfterMqttTransport)]
        public void TransportAfter([Object] ReceiveEventData eventData)
        {
            _resultDictionary.TryRemove(eventData.OperationId.ToString(), out var context);
            //var context = _segmentContextAccessor.Context;
            if (context != null)
            {
                context.Span?.AddLog(LogEvent.Event("Mqtt EndRequest"), LogEvent.Message("Request finished "));
                _tracingContext.Release(context);
            }
        }

        /// <summary>
        /// Transports the error.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.ErrorMqttTransport)]
        public void TransportError([Object] TransportErrorEventData eventData)
        {
            _resultDictionary.TryRemove(eventData.OperationId.ToString(), out var context);
            //var context = _segmentContextAccessor.Context;
            if (context != null)
            {
                context.Span?.ErrorOccurred(eventData.Exception,_tracingConfig);
                _tracingContext.Release(context);
            }
        }
    }
}