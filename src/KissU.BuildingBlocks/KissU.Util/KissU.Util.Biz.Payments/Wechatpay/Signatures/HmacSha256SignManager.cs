using KissU.Core;
using KissU.Core.Helpers;
using KissU.Core.Parameters;
using KissU.Core.Signatures;
using KissU.Util.AspNetCore.Parameters;

namespace KissU.Util.Biz.Payments.Wechatpay.Signatures
{
    /// <summary>
    /// 微信支付HMACSha256签名服务
    /// </summary>
    public class HmacSha256SignManager : ISignManager
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
        /// 初始化微信支付HMACSha256签名服务
        /// </summary>
        /// <param name="key">签名密钥</param>
        /// <param name="builder">参数生成器</param>
        public HmacSha256SignManager(ISignKey key, ParameterBuilder builder = null)
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
            var value = $"{_builder.Result(true)}&key={_key.GetKey()}";
            return Encrypt.HmacSha256(value, _key.GetKey()).ToUpper();
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="sign">签名</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool Verify(string sign)
        {
            if (sign.IsEmpty())
                return false;
            return sign == Sign();
        }
    }
}