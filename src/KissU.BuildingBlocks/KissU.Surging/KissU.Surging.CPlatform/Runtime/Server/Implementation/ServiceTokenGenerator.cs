using System;

namespace KissU.Surging.CPlatform.Runtime.Server.Implementation
{
    /// <summary>
    /// 服务令牌生成器.
    /// Implements the <see cref="IServiceTokenGenerator" />
    /// </summary>
    /// <seealso cref="IServiceTokenGenerator" />
    public class ServiceTokenGenerator : IServiceTokenGenerator
    {
        /// <summary>
        /// 服务令牌
        /// </summary>
        public string _serviceToken;

        /// <summary>
        /// 生成令牌.
        /// </summary>
        /// <param name="code">The code.</param>
        /// <returns>System.String.</returns>
        public string GeneratorToken(string code)
        {
            bool enableToken;
            if (!bool.TryParse(code, out enableToken))
            {
                _serviceToken = code;
            }
            else
            {
                if (enableToken)
                {
                    _serviceToken = Guid.NewGuid().ToString("N");
                }
                else
                {
                    _serviceToken = null;
                }
            }

            return _serviceToken;
        }

        /// <summary>
        /// 获取令牌.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetToken()
        {
            return _serviceToken;
        }
    }
}