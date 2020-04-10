using System;
using MessagePack;
using MessagePack.Resolvers;

namespace KissU.Surging.Codec.MessagePack.Utilities
{
    /// <summary>
    /// SerializerUtilitys.
    /// </summary>
    public class SerializerUtilitys
    {
        static SerializerUtilitys()
        {
            CompositeResolver.RegisterAndSetAsDefault(NativeDateTimeResolver.Instance,
                ContractlessStandardResolverAllowPrivate.Instance);
        }

        /// <summary>
        /// Serializes the specified instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="instance">The instance.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Serialize<T>(T instance)
        {
            return MessagePackSerializer.Serialize(instance);
        }

        /// <summary>
        /// Serializes the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Serialize(object instance, Type type)
        {
            return MessagePackSerializer.Serialize(instance);
        }

        /// <summary>
        /// Deserializes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public static object Deserialize(byte[] data, Type type)
        {
            return data == null ? null : MessagePackSerializer.NonGeneric.Deserialize(type, data);
        }

        /// <summary>
        /// Deserializes the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns>T.</returns>
        public static T Deserialize<T>(byte[] data)
        {
            return data == null ? default : MessagePackSerializer.Deserialize<T>(data);
        }
    }
}