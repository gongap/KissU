namespace KissU.CPlatform.Runtime.Server
{
    /// <summary>
    /// 服务令牌生成器
    /// </summary>
    public interface IServiceTokenGenerator
    {
        /// <summary>
        /// 生成令牌.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>System.String.</returns>
        string GeneratorToken(string code);

        /// <summary>
        /// 获取令牌.
        /// </summary>
        /// <returns>System.String.</returns>
        string GetToken();
    }
}