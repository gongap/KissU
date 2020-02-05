using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KissU.Util.Biz.Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信退款回调服务
    /// </summary>
    public interface IWechatpayRefundNotifyService
    {
        /// <summary>
        /// 返回成功消息
        /// </summary>
        /// <returns>System.String.</returns>
        string Success();

        /// <summary>
        /// 返回失败消息
        /// </summary>
        /// <returns>System.String.</returns>
        string Fail();

        /// <summary>
        /// 退款是否成功
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        Task<bool> IsSuccessAsync();

        /// <summary>
        /// 获取参数集合
        /// </summary>
        /// <returns>Task&lt;IDictionary&lt;System.String, System.String&gt;&gt;.</returns>
        Task<IDictionary<string, string>> GetParamsAsync();

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name">参数名</param>
        /// <returns>Task&lt;T&gt;.</returns>
        Task<T> GetParamAsync<T>(string name);

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetParamAsync(string name);

        /// <summary>
        /// 获取返回状态码
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetReturnCodeAsync();

        /// <summary>
        /// 获取返回消息
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetReturnMessageAsync();

        /// <summary>
        /// 获取应用标识
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetAppIdAsync();

        /// <summary>
        /// 获取商户号
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetMerchantIdAsync();

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetNonceAsync();

        /// <summary>
        /// 获取微信订单号
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetTransactionIdAsync();

        /// <summary>
        /// 商户订单号
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetOrderIdAsync();

        /// <summary>
        /// 获取微信退款单号
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetRefundIdAsync();

        /// <summary>
        /// 获取商户退款单号
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetRefundNo();

        /// <summary>
        /// 获取订单金额
        /// </summary>
        /// <returns>Task&lt;System.Decimal&gt;.</returns>
        Task<decimal> GetTotalFeeAsync();

        /// <summary>
        /// 获取应结订单金额
        /// </summary>
        /// <returns>Task&lt;System.Decimal&gt;.</returns>
        Task<decimal> GetSettlementTotalFeeAsync();

        /// <summary>
        /// 获取申请退款金额
        /// </summary>
        /// <returns>Task&lt;System.Decimal&gt;.</returns>
        Task<decimal> GetRefundFeeAsync();

        /// <summary>
        /// 获取退款金额
        /// </summary>
        /// <returns>Task&lt;System.Decimal&gt;.</returns>
        Task<decimal> GetSettlementRefundFeeAsync();

        /// <summary>
        /// 获取退款状态
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetRefundStatusAsync();

        /// <summary>
        /// 获取退款成功时间
        /// </summary>
        /// <returns>Task&lt;DateTime&gt;.</returns>
        Task<DateTime> GetSuccessTimeAsync();

        /// <summary>
        /// 获取退款入账账户
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetRefundReceiveAccoutAsync();

        /// <summary>
        /// 获取退款来源账户
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetRefundAccountAsync();

        /// <summary>
        /// 获取退款发起来源
        /// </summary>
        /// <returns>Task&lt;System.String&gt;.</returns>
        Task<string> GetRefundRequestSourceAsync();
    }
}