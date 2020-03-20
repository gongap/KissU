using System;
using KissU.Core;
using KissU.Util.Biz.Payments.Alipay.Abstractions;
using KissU.Util.Biz.Payments.Alipay.Configs;
using KissU.Util.Biz.Payments.Alipay.Services;
using KissU.Util.Biz.Payments.Core;
using KissU.Util.Biz.Payments.Wechatpay.Abstractions;
using KissU.Util.Biz.Payments.Wechatpay.Configs;
using KissU.Util.Biz.Payments.Wechatpay.Services;

namespace KissU.Util.Biz.Payments.Factories
{
    /// <summary>
    /// 支付工厂
    /// </summary>
    public class PayFactory : IPayFactory
    {
        /// <summary>
        /// 支付宝配置提供器
        /// </summary>
        private readonly IAlipayConfigProvider _alipayConfigProvider;

        /// <summary>
        /// 微信支付配置提供器
        /// </summary>
        private readonly IWechatpayConfigProvider _wechatpayConfigProvider;

        /// <summary>
        /// 初始化支付工厂
        /// </summary>
        /// <param name="alipayConfigProvider">支付宝配置提供器</param>
        /// <param name="wechatpayConfigProvider">微信支付配置提供器</param>
        public PayFactory(IAlipayConfigProvider alipayConfigProvider, IWechatpayConfigProvider wechatpayConfigProvider)
        {
            _alipayConfigProvider = alipayConfigProvider;
            _wechatpayConfigProvider = wechatpayConfigProvider;
        }

        /// <summary>
        /// 创建支付服务
        /// </summary>
        /// <param name="way">支付方式</param>
        /// <returns>IPayService.</returns>
        /// <exception cref="NotImplementedException"></exception>
        public IPayService CreatePayService(PayWay way)
        {
            switch (way)
            {
                case PayWay.AlipayBarcodePay:
                    return new AlipayBarcodePayService(_alipayConfigProvider);
                case PayWay.AlipayQrCodePay:
                    return new AlipayQrCodePayService(_alipayConfigProvider);
                case PayWay.AlipayPagePay:
                    return new AlipayPagePayService(_alipayConfigProvider);
                case PayWay.AlipayWapPay:
                    return new AlipayWapPayService(_alipayConfigProvider);
                case PayWay.AlipayAppPay:
                    return new AlipayAppPayService(_alipayConfigProvider);
                case PayWay.WechatpayAppPay:
                    return new WechatpayAppPayService(_wechatpayConfigProvider);
                case PayWay.WechatpayMiniProgramPay:
                    return new WechatpayMiniProgramPayService(_wechatpayConfigProvider);
                case PayWay.WechatpayJsApiPay:
                    return new WechatpayJsApiPayService(_wechatpayConfigProvider);
                case PayWay.WechatpayNativePay:
                    return new WechatpayNativePayService(_wechatpayConfigProvider);
            }

            throw new NotImplementedException(way.Description());
        }

        /// <summary>
        /// 创建支付宝回调通知服务
        /// </summary>
        /// <returns>IAlipayNotifyService.</returns>
        public IAlipayNotifyService CreateAlipayNotifyService()
        {
            return new AlipayNotifyService(_alipayConfigProvider);
        }

        /// <summary>
        /// 创建支付宝返回服务
        /// </summary>
        /// <returns>IAlipayReturnService.</returns>
        public IAlipayReturnService CreateAlipayReturnService()
        {
            return new AlipayReturnService(_alipayConfigProvider);
        }

        /// <summary>
        /// 创建支付宝交易撤消服务
        /// </summary>
        /// <returns>IAlipayCancelService.</returns>
        public IAlipayCancelService CreateAlipayCancelService()
        {
            return new AlipayCancelService(_alipayConfigProvider);
        }

        /// <summary>
        /// 创建支付宝条码支付服务
        /// </summary>
        /// <returns>IAlipayBarcodePayService.</returns>
        public IAlipayBarcodePayService CreateAlipayBarcodePayService()
        {
            return new AlipayBarcodePayService(_alipayConfigProvider);
        }

        /// <summary>
        /// 创建支付宝二维码支付服务
        /// </summary>
        /// <returns>IAlipayQrCodePayService.</returns>
        public IAlipayQrCodePayService CreateAlipayQrCodePayService()
        {
            return new AlipayQrCodePayService(_alipayConfigProvider);
        }

        /// <summary>
        /// 创建支付宝电脑网站支付服务
        /// </summary>
        /// <returns>IAlipayPagePayService.</returns>
        public IAlipayPagePayService CreateAlipayPagePayService()
        {
            return new AlipayPagePayService(_alipayConfigProvider);
        }

        /// <summary>
        /// 创建支付宝手机网站支付服务
        /// </summary>
        /// <returns>IAlipayWapPayService.</returns>
        public IAlipayWapPayService CreateAlipayWapPayService()
        {
            return new AlipayWapPayService(_alipayConfigProvider);
        }

        /// <summary>
        /// 创建支付宝App支付服务
        /// </summary>
        /// <returns>IAlipayAppPayService.</returns>
        public IAlipayAppPayService CreateAlipayAppPayService()
        {
            return new AlipayAppPayService(_alipayConfigProvider);
        }

        /// <summary>
        /// 创建微信回调通知服务
        /// </summary>
        /// <returns>IWechatpayNotifyService.</returns>
        public IWechatpayNotifyService CreateWechatpayNotifyService()
        {
            return new WechatpayNotifyService(_wechatpayConfigProvider);
        }

        /// <summary>
        /// 创建微信退款服务
        /// </summary>
        /// <returns>IWechatpayRefundService.</returns>
        public IWechatpayRefundService CreateWechatpayRefundService()
        {
            return new WechatpayRefundService(_wechatpayConfigProvider);
        }

        /// <summary>
        /// 创建微信关闭订单服务
        /// </summary>
        /// <returns>IWechatpayCloseOrderService.</returns>
        public IWechatpayCloseOrderService CreateWechatpayCloseOrderService()
        {
            return new WechatpayCloseOrderService(_wechatpayConfigProvider);
        }

        /// <summary>
        /// 创建微信App支付服务
        /// </summary>
        /// <returns>IWechatpayAppPayService.</returns>
        public IWechatpayAppPayService CreateWechatpayAppPayService()
        {
            return new WechatpayAppPayService(_wechatpayConfigProvider);
        }

        /// <summary>
        /// 创建微信小程序支付服务
        /// </summary>
        /// <returns>IWechatpayMiniProgramPayService.</returns>
        public IWechatpayMiniProgramPayService CreateWechatpayMiniProgramPayService()
        {
            return new WechatpayMiniProgramPayService(_wechatpayConfigProvider);
        }

        /// <summary>
        /// 创建微信JsApi支付服务
        /// </summary>
        /// <returns>IWechatpayJsApiPayService.</returns>
        public IWechatpayJsApiPayService CreateWechatpayJsApiPayService()
        {
            return new WechatpayJsApiPayService(_wechatpayConfigProvider);
        }

        /// <summary>
        /// 创建微信扫码支付服务
        /// </summary>
        /// <returns>IWechatpayNativePayService.</returns>
        public IWechatpayNativePayService CreateWechatpayNativePayService()
        {
            return new WechatpayNativePayService(_wechatpayConfigProvider);
        }
    }
}