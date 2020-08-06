using System;

namespace KissU.CPlatform.Diagnostics
{
    /// <summary>
    /// SegmentSpanExtensions.
    /// </summary>
    public static class SegmentSpanExtensions
    {
        /// <summary>
        /// Errors the occurred.
        /// </summary>
        /// <param name="span">The span.</param>
        /// <param name="exception">The exception.</param>
        public static void ErrorOccurred(this SegmentSpan span, Exception exception = null)
        {
            if (span == null)
            {
                return;
            }

            span.IsError = true;
            if (exception != null)
            {
                span.AddLog(LogEvent.Event("error"),
                    LogEvent.ErrorKind(exception.GetType().FullName),
                    LogEvent.Message(exception.Message),
                    LogEvent.ErrorStack(exception.StackTrace));
            }
        }
    }
}