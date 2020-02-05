using KissU.Util.AspNetCore.Parameters;
using KissU.Util.Helpers;
using KissU.Util.Signatures;

namespace KissU.Util.AspNetCore.Signatures
{
    /// <summary>
    /// 签名服务
    /// </summary>
    public class SignManager : ISignManager
    {
        /// <summary>
        /// Url参数生成器
        /// </summary>
        private readonly UrlParameterBuilder _builder;

        /// <summary>
        /// 签名密钥
        /// </summary>
        private readonly ISignKey _key;

        /// <summary>
        /// 初始化签名服务
        /// </summary>
        /// <param name="key">签名密钥</param>
        /// <param name="builder">Url参数生成器</param>
        public SignManager(ISignKey key, UrlParameterBuilder builder = null)
        {
            key.CheckNull(nameof(key));
            _key = key;
            _builder = builder == null ? new UrlParameterBuilder() : new UrlParameterBuilder(builder);
        }

        /// <summary>
        /// 添加参数
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <returns>ISignManager.</returns>
        public ISignManager Add(string key, object value)
        {
            _builder.Add(key, value);
            return this;
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <returns>System.String.</returns>
        public string Sign()
        {
            return Encrypt.Rsa2Sign(_builder.Result(true), _key.GetKey());
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="sign">签名</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Verify(string sign)
        {
            return Encrypt.Rsa2Verify(_builder.Result(true), _key.GetPublicKey(), sign);
        }
    }
}