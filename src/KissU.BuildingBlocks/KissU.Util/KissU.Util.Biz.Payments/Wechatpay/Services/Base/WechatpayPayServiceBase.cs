﻿using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Core;
using KissU.Util.Biz.Payments.Wechatpay.Configs;
using KissU.Util.Biz.Payments.Wechatpay.Parameters;
using KissU.Util.Biz.Payments.Wechatpay.Results;

namespace KissU.Util.Biz.Payments.Wechatpay.Services.Base
{
    /// <summary>
    /// 微信支付服务
    /// </summary>
    public abstract class WechatpayPayServiceBase : WechatpayServiceBase<PayParam>, IPayService
    {
        /// <summary>
        /// 初始化微信支付服务
        /// </summary>
        /// <param name="configProvider">微信支付配置提供器</param>
        protected WechatpayPayServiceBase(IWechatpayConfigProvider configProvider) : base(configProvider)
        {
        }

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="param">支付参数</param>
        /// <returns>Task&lt;PayResult&gt;.</returns>
        public virtual async Task<PayResult> PayAsync(PayParam param)
        {
            var result = await Request(param);
            return await CreateResult(result);
        }

        /// <summary>
        /// 配置参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">请求参数</param>
        protected override void ConfigBuilder(WechatpayParameterBuilder builder, PayParam param)
        {
            builder.Init();
            builder.Init(param);
            builder.TradeType(GetTradeType());
            InitBuilder(builder, param);
        }

        /// <summary>
        /// 获取交易类型
        /// </summary>
        /// <returns>System.String.</returns>
        protected abstract string GetTradeType();

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">参数生成器</param>
        /// <param name="param">支付参数</param>
        protected virtual void InitBuilder(WechatpayParameterBuilder builder, PayParam param)
        {
        }

        /// <summary>
        /// 获取接口地址
        /// </summary>
        /// <param name="config">支付配置</param>
        /// <returns>System.String.</returns>
        protected override string GetUrl(WechatpayConfig config)
        {
            return config.GetOrderUrl();
        }

        /// <summary>
        /// 创建支付结果
        /// </summary>
        /// <param name="result">支付结果</param>
        /// <returns>Task&lt;PayResult&gt;.</returns>
        protected virtual async Task<PayResult> CreateResult(WechatpayResult result)
        {
            var success = (await result.ValidateAsync()).IsValid;
            return new PayResult(success, result.GetPrepayId(), result.Raw)
            {
                Parameter = result.Builder.ToString(),
                Message = result.GetReturnMessage(),
                Result = success ? GetResult(result) : null
            };
        }

        /// <summary>
        /// 获取结果
        /// </summary>
        /// <param name="result">支付结果</param>
        /// <returns>System.String.</returns>
        protected virtual string GetResult(WechatpayResult result)
        {
            return result.GetPrepayId();
        }
    }
}