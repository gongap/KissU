namespace KissU.Util.Signatures
{
    /// <summary>
    /// 签名密钥
    /// </summary>
    public interface ISignKey
    {
        /// <summary>
        /// 获取私钥
        /// </summary>
        /// <returns>System.String.</returns>
        string GetKey();

        /// <summary>
        /// 获取公钥
        /// </summary>
        /// <returns>System.String.</returns>
        string GetPublicKey();
    }
}
