using KissU.Util.Biz.Payments.Properties;
using KissU.Util.Exceptions;
using KissU.Util.Validations;

namespace KissU.Util.Biz.Payments.Alipay.Parameters.Requests
{
    /// <summary>
    /// 支付宝交易撤消参数
    /// </summary>
    public class AlipayCancelRequest : IValidation
    {
        /// <summary>
        /// 支付宝交易流水号
        /// </summary>
        public string TradeId { get; set; }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId { get; set; }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns>ValidationResultCollection.</returns>
        /// <exception cref="Warning"></exception>
        public ValidationResultCollection Validate()
        {
            if (TradeId.IsEmpty() && OrderId.IsEmpty())
                throw new Warning(PayResource.AlipayCancelParamIsEmpty);
            return ValidationResultCollection.Success;
        }
    }
}