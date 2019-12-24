using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Core;
using KissU.Util.Biz.Payments.Wechatpay.Abstractions;
using KissU.Util.Biz.Payments.Wechatpay.Configs;
using KissU.Util.Biz.Payments.Wechatpay.Parameters;
using KissU.Util.Biz.Payments.Wechatpay.Parameters.Requests;
using KissU.Util.Biz.Payments.Wechatpay.Results;
using KissU.Util.Biz.Payments.Wechatpay.Services.Base;
using KissU.Util.Helpers;

namespace KissU.Util.Biz.Payments.Wechatpay.Services {
    /// <summary>
    /// 微信App支付服务
    /// </summary>
    public class WechatpayAppPayService : WechatpayPayServiceBase, IWechatpayAppPayService {
        /// <summary>
        /// 初始化微信App支付服务
        /// </summary>
        /// <param name="provider">微信支付配置提供器</param>
        public WechatpayAppPayService( IWechatpayConfigProvider provider ) : base( provider ) {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        public async Task<PayResult> PayAsync( WechatpayAppPayRequest request ) {
            return await PayAsync( request.ToParam() );
        }

        /// <summary>
        /// 获取交易类型
        /// </summary>
        protected override string GetTradeType() {
            return "APP";
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="result">支付结果</param>
        protected override string GetResult( WechatpayResult result ) {
            return new WechatpayParameterBuilder( result.Config )
                .AppId( result.Config.AppId )
                .PartnerId( result.Config.MerchantId )
                .Add( "prepayid", result.GetPrepayId() )
                .Add( "noncestr", Id.Guid() )
                .Timestamp()
                .Package()
                .ToJson();
        }
    }
}
