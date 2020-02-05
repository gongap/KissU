using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Core;
using KissU.Util.Biz.Payments.Wechatpay.Abstractions;
using KissU.Util.Biz.Payments.Wechatpay.Configs;
using KissU.Util.Biz.Payments.Wechatpay.Parameters.Requests;
using KissU.Util.Biz.Payments.Wechatpay.Results;
using KissU.Util.Biz.Payments.Wechatpay.Services.Base;

namespace KissU.Util.Biz.Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信扫码支付服务
    /// </summary>
    public class WechatpayNativePayService : WechatpayPayServiceBase, IWechatpayNativePayService
    {
        /// <summary>
        /// 初始化微信扫码支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayNativePayService(IWechatpayConfigProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        /// <returns>Task&lt;PayResult&gt;.</returns>
        public async Task<PayResult> PayAsync(WechatpayNativePayRequest request)
        {
            return await PayAsync(request.ToParam());
        }

        /// <summary>
        /// 获取交易类型
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetTradeType()
        {
            return "NATIVE";
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="result">支付结果</param>
        /// <returns>System.String.</returns>
        protected override string GetResult(WechatpayResult result)
        {
            return result.GetParam("code_url");
        }
    }
}