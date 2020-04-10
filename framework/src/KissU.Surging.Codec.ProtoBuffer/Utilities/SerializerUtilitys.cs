using System;
using System.IO;
using ProtoBuf;

namespace KissU.Surging.Codec.ProtoBuffer.Utilities
{
    /// <summary>
    /// SerializerUtilitys.
    /// </summary>
    public static class SerializerUtilitys
    {
        /// <summary>
        /// Serializes the specified instance.
        /// </summary>
        /// <param name="instance">The instance.</param>
        /// <returns>System.Byte[].</returns>
        public static byte[] Serialize(object instance)
        {
            using (var stream = new MemoryStream())
            {
                Serializer.Serialize(stream, instance);
                return stream.ToArray();
            }
        }

        /// <summary>
        /// Deserializes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="type">The type.</param>
        /// <returns>System.Object.</returns>
        public static object Deserialize(byte[] data, Type type)
        {
            if (data == null)
                return null;
            using (var stream = new MemoryStream(data))
            {
                return Serializer.Deserialize(type, stream);
            }
        }

        /// <summary>
        /// Deserializes the specified data.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data">The data.</param>
        /// <returns>T.</returns>
        public static T Deserialize<T>(byte[] data)
        {
            if (data == null)
                return default;
            using (var stream = new MemoryStream(data))
            {
                return Serializer.Deserialize<T>(stream);
            }
        }
    }
}