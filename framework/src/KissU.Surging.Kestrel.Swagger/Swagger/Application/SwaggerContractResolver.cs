using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace KissU.Surging.Kestrel.Swagger.Swagger.Application
{
    /// <summary>
    /// SwaggerContractResolver.
    /// Implements the <see cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
    /// </summary>
    /// <seealso cref="Newtonsoft.Json.Serialization.DefaultContractResolver" />
    public class SwaggerContractResolver : DefaultContractResolver
    {
        private readonly JsonConverter _applicationTypeConverter;

        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerContractResolver" /> class.
        /// </summary>
        /// <param name="applicationSerializerSettings">The application serializer settings.</param>
        public SwaggerContractResolver(JsonSerializerSettings applicationSerializerSettings)
        {
            NamingStrategy = new CamelCaseNamingStrategy {ProcessDictionaryKeys = false};
            _applicationTypeConverter = new ApplicationTypeConverter(applicationSerializerSettings);
        }

        /// <summary>
        /// Creates a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given
        /// <see cref="T:System.Reflection.MemberInfo" />.
        /// </summary>
        /// <param name="member">The member to create a <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for.</param>
        /// <param name="memberSerialization">The member's parent <see cref="T:Newtonsoft.Json.MemberSerialization" />.</param>
        /// <returns>
        /// A created <see cref="T:Newtonsoft.Json.Serialization.JsonProperty" /> for the given
        /// <see cref="T:System.Reflection.MemberInfo" />.
        /// </returns>
        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var jsonProperty = base.CreateProperty(member, memberSerialization);

            if (member.Name == "Example" || member.Name == "Examples" || member.Name == "Default")
                jsonProperty.Converter = _applicationTypeConverter;

            return jsonProperty;
        }

        /// <summary>
        /// ApplicationTypeConverter.
        /// Implements the <see cref="Newtonsoft.Json.JsonConverter" />
        /// </summary>
        /// <seealso cref="Newtonsoft.Json.JsonConverter" />
        private class ApplicationTypeConverter : JsonConverter
        {
            private readonly JsonSerializer _applicationTypeSerializer;

            /// <summary>
            /// Initializes a new instance of the <see cref="ApplicationTypeConverter" /> class.
            /// </summary>
            /// <param name="applicationSerializerSettings">The application serializer settings.</param>
            public ApplicationTypeConverter(JsonSerializerSettings applicationSerializerSettings)
            {
                _applicationTypeSerializer = JsonSerializer.Create(applicationSerializerSettings);
            }

            /// <summary>
            /// Determines whether this instance can convert the specified object type.
            /// </summary>
            /// <param name="objectType">Type of the object.</param>
            /// <returns><c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.</returns>
            public override bool CanConvert(Type objectType)
            {
                return true;
            }

            /// <summary>
            /// Reads the JSON representation of the object.
            /// </summary>
            /// <param name="reader">The <see cref="T:Newtonsoft.Json.JsonReader" /> to read from.</param>
            /// <param name="objectType">Type of the object.</param>
            /// <param name="existingValue">The existing value of object being read.</param>
            /// <param name="serializer">The calling serializer.</param>
            /// <returns>The object value.</returns>
            /// <exception cref="NotImplementedException"></exception>
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
                JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }

            /// <summary>
            /// Writes the json.
            /// </summary>
            /// <param name="writer">The writer.</param>
            /// <param name="value">The value.</param>
            /// <param name="serializer">The serializer.</param>
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                _applicationTypeSerializer.Serialize(writer, value);
            }
        }
    }
}