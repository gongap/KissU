using System;
using System.Runtime.CompilerServices;
using KissU.Core.Utilities;
using KissU.Surging.Codec.MessagePack.Utilities;
using MessagePack;
using Newtonsoft.Json;

namespace KissU.Surging.Codec.MessagePack.Messages
{
    /// <summary>
    /// DynamicItem.
    /// </summary>
    [MessagePackObject]
    public class DynamicItem
    {
        #region Public Method

        /// <summary>
        /// Gets this instance.
        /// </summary>
        /// <returns>System.Object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DynamicItem(object value)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value));

            var valueType = value.GetType();
            var code = Type.GetTypeCode(valueType);

            if (code != TypeCode.Object && valueType.BaseType != typeof(Enum))
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
        [Key(0)]
        public string TypeName { get; set; }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [Key(1)]
        public byte[] Content { get; set; }

        #endregion Property
    }
}