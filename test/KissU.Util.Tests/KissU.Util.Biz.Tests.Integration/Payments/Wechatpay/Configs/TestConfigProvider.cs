using System.Threading.Tasks;
using KissU.Util.AspNetCore.Parameters;
using KissU.Util.Biz.Payments.Wechatpay.Configs;
using KissU.Util.Parameters;

namespace KissU.Util.Biz.Tests.Integration.Payments.Wechatpay.Configs
{
    /// <summary>
    /// 微信支付测试配置提供器
    /// </summary>
    public class TestConfigProvider : IWechatpayConfigProvider
    {
        /// <summary>
        /// 请填写正确的微信支付配置
        /// </summary>
        /// <param name="parameters">The parameters.</param>
        /// <returns>Task&lt;WechatpayConfig&gt;.</returns>
        public Task<WechatpayConfig> GetConfigAsync(IParameterManager parameters = null)
        {
            var config = new WechatpayConfig
            {
                AppId = "",
                MerchantId = "",
                PrivateKey = "",
                NotifyUrl = ""
            };
            return Task.FromResult(config);
        }
    }
}