using System;
using KissU.Helpers.Utilities;
using KissU.Surging.Codec.ProtoBuffer.Utilities;
using Newtonsoft.Json;
using ProtoBuf;

namespace KissU.Surging.Codec.ProtoBuffer.Messages
{
    /// <summary>
    /// DynamicItem.
    /// </summary>
    [ProtoContract]
    public class DynamicItem
    {
        #region Public Method

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>System.Object.</returns>
        public object Get()
        {
            if (Content == null || TypeName == null)
                return null;
            var typeName = Type.GetType(TypeName);
            if (typeName == UtilityType.JObjectType || typeName == UtilityType.JArrayType)
            {
                var content = SerializerUtilitys.Deserialize<string>(Content);
                return JsonConvert.DeserializeObject(content, typeName);
            }

            return SerializerUtilitys.Deserialize(Content, typeName);
        }

        #endregion Public Method

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicItem" /> class.
        /// </summary>
        public DynamicItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DynamicItem" /> class.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <exception cref="ArgumentNullException">value</exception>
        public DynamicItem(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var valueType = value.GetType();
            var code = Type.GetTypeCode(valueType);

            if (code != TypeCode.Object)
                TypeName = valueType.FullName;
            else
                TypeName = valueType.AssemblyQualifiedName;
            if (valueType == UtilityType.JObjectType || valueType == UtilityType.JArrayType)
                Content = SerializerUtilitys.Serialize(value.ToString());
            else
                Content = SerializerUtilitys.Serialize(value);
        }

        #endregion Constructor

        #region Property

        /// <summary>
        /// Gets or sets the name of the type.
        /// </summary>
        [ProtoMember(1)]
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [ProtoMember(2)]
        public byte[] Content { get; set; }

        #endregion Property
    }
}