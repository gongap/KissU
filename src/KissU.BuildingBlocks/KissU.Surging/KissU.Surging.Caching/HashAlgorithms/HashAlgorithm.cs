using System.Text;

namespace KissU.Surging.Caching.HashAlgorithms
{
    /// <summary>
    /// 一致性哈希算法
    /// </summary>
    /// <remarks>
    ///     <para>创建：范亮</para>
    ///     <para>日期：2016/4/2</para>
    /// </remarks>
    public class HashAlgorithm : IHashAlgorithm
    {
        #region 构造函数

        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <param name="item">字符串</param>
        /// <returns>返回哈希值</returns>
        /// <remarks>
        ///     <para>创建：范亮</para>
        ///     <para>日期：2016/4/2</para>
        /// </remarks>
        public int Hash(string item)
        {
            var hash = Hash(Encoding.ASCII.GetBytes(item));
            return (int) hash;
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// Hashes the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="seed">The seed.</param>
        /// <returns>UInt32.</returns>
        public static uint Hash(byte[] data, uint seed = 0xc58f1a7b)
        {
            var length = data.Length;
            if (length == 0)
                return 0;

            var h = seed ^ (uint) length;
            var c = 0;
            while (length >= 4)
            {
                var k = (uint) (
                    data[c++]
                    | (data[c++] << 8)
                    | (data[c++] << 16)
                    | (data[c++] << 24));
                k *= m;
                k ^= k >> r;
                k *= m;
                h *= m;
                h ^= k;
                length -= 4;
            }

            switch (length)
            {
                case 3:
                    h ^= (ushort) (data[c++] | (data[c++] << 8));
                    h ^= (uint) (data[c] << 16);
                    h *= m;
                    break;
                case 2:
                    h ^= (ushort) (data[c++] | (data[c] << 8));
                    h *= m;
                    break;
                case 1:
                    h ^= data[c];
                    h *= m;
                    break;
            }

            h ^= h >> 13;
            h *= m;
            h ^= h >> 15;
            return h;
        }

        #endregion

        #region 常量

        private const uint m = 0x5bd1e995;
        private const int r = 24;

        #endregion
    }
}