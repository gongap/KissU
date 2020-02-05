using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Alipay.Abstractions;
using KissU.Util.Biz.Payments.Alipay.Configs;
using KissU.Util.Biz.Payments.Alipay.Parameters;
using KissU.Util.Biz.Payments.Alipay.Parameters.Requests;
using KissU.Util.Biz.Payments.Alipay.Results;
using KissU.Util.Biz.Payments.Alipay.Services.Base;

namespace KissU.Util.Biz.Payments.Alipay.Services
{
    /// <summary>
    /// 支付宝交易撤消服务
    /// </summary>
    public class AlipayCancelService : AlipayServiceBase<AlipayCancelRequest>, IAlipayCancelService
    {
        /// <summary>
        /// 初始化支付宝交易撤消服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        public AlipayCancelService(IAlipayConfigProvider provider) : base(provider)
        {
        }

        /// <summary>
        /// 撤消支付
        /// </summary>
        /// <param name="request">撤消参数</param>
        /// <returns>Task&lt;AlipayCancelResult&gt;.</returns>
        public async Task<AlipayCancelResult> CancelAsync(AlipayCancelRequest request)
        {
            var result = await Request(request);
            return CreateResult(result);
        }

        /// <summary>
        /// 初始化内容生成器
        /// </summary>
        /// <param name="builder">内容参数生成器</param>
        /// <param name="param">请求参数</param>
        protected override void InitContentBuilder(AlipayContentBuilder builder, AlipayCancelRequest param)
        {
            builder.OutTradeNo(param.OrderId).TradeNo(param.TradeId);
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        /// <returns>System.String.</returns>
        protected override string GetMethod()
        {
            return "alipay.trade.cancel";
        }

        /// <summary>
        /// 创建结果
        /// </summary>
        /// <param name="result">The result.</param>
        /// <returns>AlipayCancelResult.</returns>
        protected virtual AlipayCancelResult CreateResult(AlipayResult result)
        {
            return new AlipayCancelResult(result);
        }
    }
}