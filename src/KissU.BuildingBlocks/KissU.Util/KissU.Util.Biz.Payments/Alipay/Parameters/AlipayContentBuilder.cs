﻿using KissU.Core.Parameters;
using KissU.Util.AspNetCore.Parameters.Formats;
using KissU.Util.Biz.Payments.Alipay.Configs;
using KissU.Util.Biz.Payments.Core;

namespace KissU.Util.Biz.Payments.Alipay.Parameters
{
    /// <summary>
    /// 支付宝内容参数生成器
    /// </summary>
    public class AlipayContentBuilder : ParameterBuilder
    {
        /// <summary>
        /// 初始化支付参数
        /// </summary>
        /// <param name="param">支付参数</param>
        /// <returns>AlipayContentBuilder.</returns>
        public AlipayContentBuilder Init(PayParam param)
        {
            if (param == null)
                return this;
            return OutTradeNo(param.OrderId)
                .Subject(param.Subject)
                .TotalAmount(param.Money)
                .TimeoutExpress(param.Timeout);
        }

        /// <summary>
        /// 设置支付宝交易号
        /// </summary>
        /// <param name="tradeId">支付宝交易号</param>
        /// <returns>AlipayContentBuilder.</returns>
        public AlipayContentBuilder TradeNo(string tradeId)
        {
            Add(AlipayConst.TradeNo, tradeId);
            return this;
        }

        /// <summary>
        /// 设置商户订单号
        /// </summary>
        /// <param name="orderId">商户订单号</param>
        /// <returns>AlipayContentBuilder.</returns>
        public AlipayContentBuilder OutTradeNo(string orderId)
        {
            Add(AlipayConst.OutTradeNo, orderId);
            return this;
        }

        /// <summary>
        /// 设置场景
        /// </summary>
        /// <param name="scene">场景</param>
        /// <returns>AlipayContentBuilder.</returns>
        public AlipayContentBuilder Scene(string scene)
        {
            Add(AlipayConst.Scene, scene);
            return this;
        }

        /// <summary>
        /// 设置用户付款授权码
        /// </summary>
        /// <param name="code">用户付款授权码</param>
        /// <returns>AlipayContentBuilder.</returns>
        public AlipayContentBuilder AuthCode(string code)
        {
            Add(AlipayConst.AuthCode, code);
            return this;
        }

        /// <summary>
        /// 设置订单标题
        /// </summary>
        /// <param name="subject">订单标题</param>
        /// <returns>AlipayContentBuilder.</returns>
        public AlipayContentBuilder Subject(string subject)
        {
            Add(AlipayConst.Subject, subject);
            return this;
        }

        /// <summary>
        /// 设置支付超时
        /// </summary>
        /// <param name="timeout">支付超时间隔，单位：分钟</param>
        /// <returns>AlipayContentBuilder.</returns>
        public AlipayContentBuilder TimeoutExpress(int timeout)
        {
            Add(AlipayConst.TimeoutExpress, $"{timeout}m");
            return this;
        }

        /// <summary>
        /// 设置金额
        /// </summary>
        /// <param name="amount">支付金额</param>
        /// <returns>AlipayContentBuilder.</returns>
        public AlipayContentBuilder TotalAmount(decimal amount)
        {
            Add(AlipayConst.TotalAmount, amount);
            return this;
        }

        /// <summary>
        /// 输出结果
        /// </summary>
        /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
        public override string ToString()
        {
            return Result(UrlParameterFormat.Instance);
        }
    }
}