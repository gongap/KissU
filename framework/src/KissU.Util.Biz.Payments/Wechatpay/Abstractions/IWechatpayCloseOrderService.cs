using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Wechatpay.Parameters.Requests;
using KissU.Util.Biz.Payments.Wechatpay.Results;

namespace KissU.Util.Biz.Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信支付关闭订单服务
    /// </summary>
    public interface IWechatpayCloseOrderService
    {
        /// <summary>
        /// 关闭订单
        /// </summary>
        /// <param name="request">关闭订单参数</param>
        Task<WechatpayCloseOrderResult> CloseOrderAsync(WechatpayCloseOrderRequest request);
    }
}