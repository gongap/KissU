using System;
using System.Collections.Concurrent;
using KissU.CPlatform.Diagnostics;
using KissU.CPlatform.Messages;
using KissU.Serialization;
using SkyApm;
using SkyApm.Common;
using SkyApm.Config;
using SkyApm.Diagnostics;
using SkyApm.Tracing;
using SkyApm.Tracing.Segments;

namespace KissU.AspNetCore.Kestrel.Diagnostics
{
    /// <summary>
    /// RestTransportDiagnosticProcessor.
    /// Implements the <see cref="ITracingDiagnosticProcessor" />
    /// </summary>
    /// <seealso cref="ITracingDiagnosticProcessor" />
    public class RestTransportDiagnosticProcessor : ITracingDiagnosticProcessor
    {
        private readonly ISerializer<string> _serializer;
        private readonly ITracingContext _tracingContext;
        private readonly TracingConfig _tracingConfig;
        private readonly ConcurrentDictionary<string, SegmentContext> _resultDictionary = new ConcurrentDictionary<string, SegmentContext>();

        /// <summary>
        /// Initializes a new instance of the <see cref="RestTransportDiagnosticProcessor" /> class.
        /// </summary>
        /// <param name="tracingContext">The tracing context.</param>
        /// <param name="configAccessor"></param>
        /// <param name="serializer">The serializer.</param>
        public RestTransportDiagnosticProcessor(ITracingContext tracingContext, IConfigAccessor configAccessor, ISerializer<string> serializer)
        {
            _tracingContext = tracingContext;
            _tracingConfig = configAccessor.Get<TracingConfig>();
            _serializer = serializer;
        }

        /// <summary>
        /// Gets the name of the listener.
        /// </summary>
        public string ListenerName => string.Format(DiagnosticListenerExtensions.DiagnosticListenerName, TransportType.Rest);

        /// <summary>
        /// Transports the before.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.StartRestTransport)]
        public void TransportStart([Object] TransportEventData eventData)
        {
            var host = eventData.RemoteAddress ?? "[::1]";
            var message = eventData.Message.GetContent<HttpRequestMessage>();
            var operationName = $"Rest-Hosting :: {eventData.Message.MessageName}";
            var context = _tracingContext.CreateEntrySegmentContext(operationName, new RestTransportCarrierHeaderCollection(eventData.Headers));
            context.Span.AddLog(LogEvent.Message($"Worker running at: {DateTime.Now}"));
            context.Span.SpanLayer = SpanLayer.HTTP;
            context.Span.Peer = new StringOrIntValue(host);
            context.Span.Component = Components.ASPNETCORE;
            context.Span.AddTag(CPlatform.Diagnostics.Tags.REST_METHOD, eventData.Method);
            context.Span.AddTag(CPlatform.Diagnostics.Tags.REST_PARAMETERS, _serializer.Serialize(message.Parameters));
            context.Span.AddTag(CPlatform.Diagnostics.Tags.REST_LOCAL_ADDRESS, CPlatform.AppConfig.GetHostAddress().ToString());
            _resultDictionary.TryAdd(eventData.OperationId.ToString(), context);
        }

        /// <summary>
        /// Transports the after.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.AfterRestTransport)]
        public void TransportAfter([Object] ReceiveEventData eventData)
        {
            _resultDictionary.TryRemove(eventData.OperationId.ToString(), out var context);
            //var context = _contextAccessor.Context;
            if (context != null)
            {
                context.Span?.AddLog(LogEvent.Event("Rest EndRequest"), LogEvent.Message("Request finished "));
                _tracingContext.Release(context);
            }
        }

        /// <summary>
        /// Transports the error.
        /// </summary>
        /// <param name="eventData">The event data.</param>
        [DiagnosticName(DiagnosticListenerExtensions.ErrorRestTransport)]
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