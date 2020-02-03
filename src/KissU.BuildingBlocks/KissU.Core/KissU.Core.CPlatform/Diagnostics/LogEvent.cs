namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// LogEvent.
    /// </summary>
    public class LogEvent
    {
        /// <summary>
        /// Gets the key.
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// Gets the value.
        /// </summary>
        public string Value { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LogEvent"/> class.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        public LogEvent(string key, string value)
        {
            Key = key;
            Value = value;
        }

        /// <summary>
        /// Events the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>LogEvent.</returns>
        public static LogEvent Event(string value)
        {
            return new LogEvent("event", value);
        }

        /// <summary>
        /// Messages the specified value.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>LogEvent.</returns>
        public static LogEvent Message(string value)
        {
            return new LogEvent("message", value);
        }

        /// <summary>
        /// Errors the kind.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>LogEvent.</returns>
        public static LogEvent ErrorKind(string value)
        {
            return new LogEvent("error.kind", value);
        }

        /// <summary>
        /// Errors the stack.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>LogEvent.</returns>
        public static LogEvent ErrorStack(string value)
        {
            return new LogEvent("stack", value);
        }
    }
}