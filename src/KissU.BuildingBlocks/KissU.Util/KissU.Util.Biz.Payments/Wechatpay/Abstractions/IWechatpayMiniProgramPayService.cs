﻿using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Core;
using KissU.Util.Biz.Payments.Wechatpay.Parameters.Requests;

namespace KissU.Util.Biz.Payments.Wechatpay.Abstractions
{
    /// <summary>
    /// 微信小程序支付服务
    /// </summary>
    public interface IWechatpayMiniProgramPayService
    {
        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="request">支付参数</param>
        /// <returns>Task&lt;PayResult&gt;.</returns>
        Task<PayResult> PayAsync(WechatpayMiniProgramPayRequest request);
    }
}