using System.Threading.Tasks;
using KissU.Core.Parameters;

namespace KissU.Util.Biz.Payments.Wechatpay.Configs
{
    /// <summary>
    /// 微信支付配置提供器
    /// </summary>
    public interface IWechatpayConfigProvider
    {
        /// <summary>
        /// 获取配置
        /// </summary>
        /// <param name="parameters">参数服务</param>
        /// <returns>Task&lt;WechatpayConfig&gt;.</returns>
        Task<WechatpayConfig> GetConfigAsync(IParameterManager parameters = null);
    }
}