using System;
using System.Text;
using KissU.Serialization;
using KissU.Surging.CPlatform.Diagnostics;
using KissU.Surging.CPlatform.Messages;
using KissU.Surging.CPlatform.Utilities;
using KissUEvents = KissU.Surging.CPlatform.Diagnostics.DiagnosticListenerExtensions;

namespace KissU.Surging.Protocol.Mqtt.Diagnostics
{
    /// <summary>
    /// MqttTransportDiagnosticProcessor.
    /// Implements the <see cref="KissU.Surging.CPlatform.Diagnostics.ITracingDiagnosticProcessor" />
    /// </summary>
    /// <seealso cref="KissU.Surging.CPlatform.Diagnostics.ITracingDiagnosticProcessor" />
    public class MqttTransportDiagnosticProcessor : ITracingDiagnosticProcessor
    {
        private readonly IEntrySegmentContextAccessor _segmentContextAccessor;


        private readonly ISerializer<string> _serializer;
        private readonly ITracingContext _tracingContext;
        private Func<TransportEventData, string> _transportOperationNameResolver;

        /// <summary>
        /// Initializes a new instance of the <see cref="MqttTransportDiagnosticProcessor" /> class.
        /// </summary>
        /// <param name="tracingContext">The tracing context.</param>
        /// <param name="serializer">The serializer.</param>
        /// <param name="contextAccessor">The context accessor.</param>
        public MqttTransportDiagnosticProcessor(ITracingContext tracingContext, ISerializer<string> serializer,
            IEntrySegmentContextAccessor contextAccessor)
        {
            _tracingContext = tracingContext;
            _serializer = serializer;
            _segmentContextAccessor = contextAccessor;
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
                       (_transportOperationNameResolver = data => "Mqtt-Transport:: " + data.Message.MessageName);
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
        [DiagnosticName(KissUEvents.BeforeTransport, TransportType.Mqtt)]
        public void TransportBefore([Object] TransportEventData eventData)
        {
            var message = eventData.Message.GetContent<RemoteInvokeMessage>();
            var operationName = TransportOperationNameResolver(eventData);
            var context = _tracingContext.CreateEntrySegmentContext(operationName,
                new MqttTransportCarrierHeaderCollection(eventData.Headers));
            if (!string.IsNullOrEmpty(eventData.TraceId))
                context.TraceId = ConvertUniqueId(eventData);
            context.Span.AddLog(LogEvent.Message($"Worker running at: {DateTime.Now}"));
            context.Span.SpanLayer = SpanLayer.RPC_FRAMEWORK;
            context.Span.AddTag(Tags.MQTT_CLIENT_ID, eventData.TraceId);
            context.Span.AddTag(Tags.MQTT_METHOD, eventData.Method);
            context.Span.AddTag(Tags.REST_PARAMETERS, _serializer.Serialize(message.Parameters));
            context.Span.AddTag(Tags.MQTT_BROKER_ADDRESS, NetUtils.GetHostAddress().ToString());
        }

        /// <summary>
        /// Transports the after.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(KissUEvents.AfterTransport, TransportType.Mqtt)]
        public void TransportAfter([Object] ReceiveEventData eventData)
        {
            var context = _segmentContextAccessor.Context;
            if (context != null)
            {
                _tracingContext.Release(context);
            }
        }

        /// <summary>
        /// Transports the error.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(KissUEvents.ErrorTransport, TransportType.Mqtt)]
        public void TransportError([Object] TransportErrorEventData eventData)
        {
            var context = _segmentContextAccessor.Context;
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
            var bytes = Encoding.Default.GetBytes($"{eventData.TraceId}-{nameof(MqttTransportDiagnosticProcessor)}");
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