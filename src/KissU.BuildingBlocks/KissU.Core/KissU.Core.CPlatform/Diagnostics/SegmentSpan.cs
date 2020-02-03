/*
 * Licensed to the SkyAPM under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The SkyAPM licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace KissU.Core.CPlatform.Diagnostics
{
    /// <summary>
    /// SegmentSpan.
    /// </summary>
    public class SegmentSpan
    {
        /// <summary>
        /// Gets the span identifier.
        /// </summary>
        public int SpanId { get; } = 0;

        /// <summary>
        /// Gets the parent span identifier.
        /// </summary>
        public int ParentSpanId { get; } = -1;

        /// <summary>
        /// Gets the start time.
        /// </summary>
        public long StartTime { get; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        /// Gets the end time.
        /// </summary>
        public long EndTime { get; private set; }

        /// <summary>
        /// Gets the name of the operation.
        /// </summary>
        public StringOrIntValue OperationName { get; }

        /// <summary>
        /// Gets or sets the peer.
        /// </summary>
        public StringOrIntValue Peer { get; set; }

        /// <summary>
        /// Gets the type of the span.
        /// </summary>
        public SpanType SpanType { get; }

        /// <summary>
        /// Gets or sets the span layer.
        /// </summary>
        public SpanLayer SpanLayer { get; set; }

        /// <summary>
        /// Limiting values. Please see <see cref="Components" /> or see <seealso href="https://github.com/apache/incubator-skywalking/blob/master/oap-server/server-starter/src/main/resources/component-libraries.yml" />
        /// </summary>
        public StringOrIntValue Component { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is error.
        /// </summary>
        public bool IsError { get; set; }
        /// <summary>
        /// Gets the tags.
        /// </summary>
        public TagCollection Tags { get; } = new TagCollection();

        /// <summary>
        /// Gets the logs.
        /// </summary>
        public LogCollection Logs { get; } = new LogCollection();

        /// <summary>
        /// Initializes a new instance of the <see cref="SegmentSpan"/> class.
        /// </summary>
        /// <param name="operationName">Name of the operation.</param>
        /// <param name="spanType">Type of the span.</param>
        public SegmentSpan(string operationName, SpanType spanType)
        {
            OperationName = new StringOrIntValue(operationName);
            SpanType = spanType;
        }

        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>SegmentSpan.</returns>
        public SegmentSpan AddTag(string key, string value)
        {
            Tags.AddTag(key, value);
            return this;
        }

        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        /// <returns>SegmentSpan.</returns>
        public SegmentSpan AddTag(string key, long value)
        {
            Tags.AddTag(key, value.ToString());
            return this;
        }

        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">if set to <c>true</c> [value].</param>
        /// <returns>SegmentSpan.</returns>
        public SegmentSpan AddTag(string key, bool value)
        {
            Tags.AddTag(key, value.ToString());
            return this;
        }

        /// <summary>
        /// Adds the log.
        /// </summary>
        /// <param name="events">The events.</param>
        public void AddLog(params LogEvent[] events)
        {
            var log = new SpanLog(DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(), events);
            Logs.AddLog(log);
        }

        /// <summary>
        /// Finishes this instance.
        /// </summary>
        public void Finish()
        {
            EndTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
        }
    }

    /// <summary>
    /// TagCollection.
    /// Implements the <see cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String, System.String}}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{System.Collections.Generic.KeyValuePair{System.String, System.String}}" />
    public class TagCollection : IEnumerable<KeyValuePair<string, string>>
    {
        private readonly Dictionary<string, string> tags = new Dictionary<string, string>();

        /// <summary>
        /// Adds the tag.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        internal void AddTag(string key, string value)
        {
            tags[key] = value;
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return tags.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return tags.GetEnumerator();
        }
    }

    /// <summary>
    /// Enum SpanType
    /// </summary>
    public enum SpanType
    {
        /// <summary>
        /// The entry
        /// </summary>
        Entry = 0,
        /// <summary>
        /// The exit
        /// </summary>
        Exit = 1,
        /// <summary>
        /// The local
        /// </summary>
        Local = 2,
    }

    /// <summary>
    /// Enum SpanLayer
    /// </summary>
    public enum SpanLayer
    {
        /// <summary>
        /// The database
        /// </summary>
        DB = 1,
        /// <summary>
        /// The RPC framework
        /// </summary>
        RPC_FRAMEWORK = 2,
        /// <summary>
        /// The HTTP
        /// </summary>
        HTTP = 3,
        /// <summary>
        /// The mq
        /// </summary>
        MQ = 4,
        /// <summary>
        /// The cache
        /// </summary>
        CACHE = 5,
    }

    /// <summary>
    /// LogCollection.
    /// Implements the <see cref="System.Collections.Generic.IEnumerable{KissU.Core.CPlatform.Diagnostics.SpanLog}" />
    /// </summary>
    /// <seealso cref="System.Collections.Generic.IEnumerable{KissU.Core.CPlatform.Diagnostics.SpanLog}" />
    public class LogCollection : IEnumerable<SpanLog>
    {
        private readonly List<SpanLog> _logs = new List<SpanLog>();

        /// <summary>
        /// Adds the log.
        /// </summary>
        /// <param name="log">The log.</param>
        internal void AddLog(SpanLog log)
        {
            _logs.Add(log);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<SpanLog> GetEnumerator()
        {
            return _logs.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _logs.GetEnumerator();
        } 
    }

    /// <summary>
    /// SpanLog.
    /// </summary>
    public class SpanLog
    {
        private static readonly Dictionary<string, string> Empty = new Dictionary<string, string>();
        /// <summary>
        /// Gets the timestamp.
        /// </summary>
        public long Timestamp { get; }

        /// <summary>
        /// Gets the data.
        /// </summary>
        public IReadOnlyDictionary<string, string> Data { get; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SpanLog"/> class.
        /// </summary>
        /// <param name="timestamp">The timestamp.</param>
        /// <param name="events">The events.</param>
        public SpanLog(long timestamp, params LogEvent[] events)
        {
            Timestamp = timestamp;
            Data = events?.ToDictionary(x => x.Key, x => x.Value) ?? Empty;
        }
    }

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
