using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Alipay.Parameters.Requests;

namespace KissU.Util.Biz.Payments.Alipay.Abstractions
{
    /// <summary>
    /// 支付宝电脑网站支付服务
    /// </summary>
    public interface IAlipayPagePayService
    {
        /// <summary>
        /// 支付,返回表单html
        /// </summary>
        /// <param name="request">电脑网站支付参数</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> PayAsync(AlipayPagePayRequest request);

        /// <summary>
        /// 跳转到支付宝收银台
        /// </summary>
        /// <param name="request">电脑网站支付参数</param>
        /// <returns>Task.</returns>
        Task RedirectAsync(AlipayPagePayRequest request);
    }
}