using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Alipay.Parameters.Requests;

namespace KissU.Util.Biz.Payments.Alipay.Abstractions
{
    /// <summary>
    /// 支付宝二维码支付
    /// </summary>
    public interface IAlipayQrCodePayService
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> PayAsync(AlipayPrecreateRequest request);
    }
}