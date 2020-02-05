using System.Threading.Tasks;

namespace KissU.Util.Biz.Payments.Core
{
    /// <summary>
    /// 支付服务
    /// </summary>
    public interface IPayService
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        /// <returns>Task&lt;PayResult&gt;.</returns>
        Task<PayResult> PayAsync(PayParam param);
    }
}