namespace KissU.Util.Signatures
{
    /// <summary>
    /// 签名服务
    /// </summary>
    public interface ISignManager
    {
        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>ISignManager.</returns>
        ISignManager Add(string key, object value);

        /// <summary>
        /// 签名
        /// </summary>
        /// <returns>System.String.</returns>
        string Sign();

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="sign">签名</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        bool Verify(string sign);
    }
}