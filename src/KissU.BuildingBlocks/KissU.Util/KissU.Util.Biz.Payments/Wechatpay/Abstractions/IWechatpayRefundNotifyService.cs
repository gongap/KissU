﻿using System;
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
        string Success();

        /// <summary>
        /// 返回失败消息
        /// </summary>
        string Fail();

        /// <summary>
        /// 退款是否成功
        /// </summary>
        Task<bool> IsSuccessAsync();

        /// <summary>
        /// 获取参数集合
        /// </summary>
        Task<IDictionary<string, string>> GetParamsAsync();

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        Task<T> GetParamAsync<T>(string name);

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        Task<string> GetParamAsync(string name);

        /// <summary>
        /// 获取返回状态码
        /// </summary>
        Task<string> GetReturnCodeAsync();

        /// <summary>
        /// 获取返回消息
        /// </summary>
        Task<string> GetReturnMessageAsync();

        /// <summary>
        /// 获取应用标识
        /// </summary>
        Task<string> GetAppIdAsync();

        /// <summary>
        /// 获取商户号
        /// </summary>
        Task<string> GetMerchantIdAsync();

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        Task<string> GetNonceAsync();

        /// <summary>
        /// 获取微信订单号
        /// </summary>
        Task<string> GetTransactionIdAsync();

        /// <summary>
        /// 商户订单号
        /// </summary>
        Task<string> GetOrderIdAsync();

        /// <summary>
        /// 获取微信退款单号
        /// </summary>
        Task<string> GetRefundIdAsync();

        /// <summary>
        /// 获取商户退款单号
        /// </summary>
        Task<string> GetRefundNo();

        /// <summary>
        /// 获取订单金额
        /// </summary>
        Task<decimal> GetTotalFeeAsync();

        /// <summary>
        /// 获取应结订单金额
        /// </summary>
        Task<decimal> GetSettlementTotalFeeAsync();

        /// <summary>
        /// 获取申请退款金额
        /// </summary>
        Task<decimal> GetRefundFeeAsync();

        /// <summary>
        /// 获取退款金额
        /// </summary>
        Task<decimal> GetSettlementRefundFeeAsync();

        /// <summary>
        /// 获取退款状态
        /// </summary>
        Task<string> GetRefundStatusAsync();

        /// <summary>
        /// 获取退款成功时间
        /// </summary>
        Task<DateTime> GetSuccessTimeAsync();

        /// <summary>
        /// 获取退款入账账户
        /// </summary>
        Task<string> GetRefundReceiveAccoutAsync();

        /// <summary>
        /// 获取退款来源账户
        /// </summary>
        Task<string> GetRefundAccountAsync();

        /// <summary>
        /// 获取退款发起来源
        /// </summary>
        Task<string> GetRefundRequestSourceAsync();
    }
}