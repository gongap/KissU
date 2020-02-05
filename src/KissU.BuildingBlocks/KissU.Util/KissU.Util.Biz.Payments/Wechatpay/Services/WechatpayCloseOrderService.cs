using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Wechatpay.Abstractions;
using KissU.Util.Biz.Payments.Wechatpay.Configs;
using KissU.Util.Biz.Payments.Wechatpay.Parameters;
using KissU.Util.Biz.Payments.Wechatpay.Parameters.Requests;
using KissU.Util.Biz.Payments.Wechatpay.Results;
using KissU.Util.Biz.Payments.Wechatpay.Services.Base;

namespace KissU.Util.Biz.Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信支付关闭订单服务
    /// </summary>
    public class WechatpayCloseOrderService : WechatpayServiceBase<WechatpayCloseOrderRequest>,
        IWechatpayCloseOrderService
    {
        /// <summary>
        /// 初始化微信支付关闭订单服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        public WechatpayCloseOrderService(IWechatpayConfigProvider configProvider) : base(configProvider)
        {
        }

        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="request">关闭订单参数</param>
        /// <returns>Task&lt;WechatpayCloseOrderResult&gt;.</returns>
        public async Task<WechatpayCloseOrderResult> CloseOrderAsync(WechatpayCloseOrderRequest request)
        {
            var result = await Request(request);
            return await CreateResult(result);
        }

        /// <summary>
        /// 配置参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">请求参数</param>
        protected override void ConfigBuilder(WechatpayParameterBuilder builder, WechatpayCloseOrderRequest param)
        {
            builder.Init();
            builder.OutTradeNo(param.OrderId);
        }

        /// <summary>
        /// 获取接口地址
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <returns>System.String.</returns>
        protected override string GetUrl(WechatpayConfig config)
        {
            return config.GetCloseOrderUrl();
        }

        /// <summary>
        /// 创建关闭订单结果
        /// </summary>
        /// <param name="result">请求结果</param>
        private async Task<WechatpayCloseOrderResult> CreateResult(WechatpayResult result)
        {
            var success = (await result.ValidateAsync()).IsValid;
            return new WechatpayCloseOrderResult(success, result);
        }
    }
}