using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace KissU.Core.CPlatform.Serialization.JsonConverters
{
    /// <summary>
    /// 日期JsonConverter.
    /// Implements the <see cref="JsonConverter{T}" />
    /// </summary>
    /// <seealso cref="JsonConverter{DateTime}" />
    public class DateTimeJsonConverter : JsonConverter<DateTime>
    {
        private readonly string _dateFormatString;

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeJsonConverter" /> class.
        /// </summary>
        public DateTimeJsonConverter()
        {
            _dateFormatString = "yyyy-MM-dd HH:mm:ss";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DateTimeJsonConverter" /> class.
        /// </summary>
        /// <param name="dateFormatString">The date format string.</param>
        public DateTimeJsonConverter(string dateFormatString)
        {
            _dateFormatString = dateFormatString;
        }

        /// <summary>
        /// Reads and converts the JSON to type <typeparamref name="T" />.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="typeToConvert">The type to convert.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        /// <returns>The converted value.</returns>
        public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateTime.Parse(reader.GetString());
        }

        /// <summary>
        /// Writes a specified value as JSON.
        /// </summary>
        /// <param name="writer">The writer to write to.</param>
        /// <param name="value">The value to convert to JSON.</param>
        /// <param name="options">An object that specifies serialization options to use.</param>
        public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToUniversalTime().ToString(_dateFormatString));
        }
    }
}