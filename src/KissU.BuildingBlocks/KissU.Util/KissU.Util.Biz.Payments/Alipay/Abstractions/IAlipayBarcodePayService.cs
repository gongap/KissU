using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Alipay.Parameters.Requests;
using KissU.Util.Biz.Payments.Core;

namespace KissU.Util.Biz.Payments.Alipay.Abstractions
{
    /// <summary>
    /// 支付宝条码支付服务
    /// </summary>
    public interface IAlipayBarcodePayService
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">条码支付参数</param>
        /// <returns>Task&lt;PayResult&gt;.</returns>
        Task<PayResult> PayAsync(AlipayBarcodePayRequest request);
    }
}