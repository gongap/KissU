namespace KissU.Caching.HashAlgorithms
{
    /// <summary>
    /// 一致性哈希的抽象接口
    /// </summary>
    public interface IHashAlgorithm
    {
        /// <summary>
        /// 获取哈希值
        /// </summary>
        /// <param name="item">字符串</param>
        /// <returns>返回哈希值</returns>
        int Hash(string item);
    }
}