using KissU.Util.Biz.Payments.Alipay.Abstractions;
using KissU.Util.Biz.Payments.Core;
using KissU.Util.Biz.Payments.Wechatpay.Abstractions;

namespace KissU.Util.Biz.Payments
{
    /// <summary>
    /// 支付工厂
    /// </summary>
    public interface IPayFactory
    {
        /// <summary>
        /// 创建支付服务
        /// </summary>
        /// <param name="way">支付方式</param>
        /// <returns>IPayService.</returns>
        IPayService CreatePayService(PayWay way);

        /// <summary>
        /// 创建支付宝回调通知服务
        /// </summary>
        /// <returns>IAlipayNotifyService.</returns>
        IAlipayNotifyService CreateAlipayNotifyService();

        /// <summary>
        /// 创建支付宝返回服务
        /// </summary>
        /// <returns>IAlipayReturnService.</returns>
        IAlipayReturnService CreateAlipayReturnService();

        /// <summary>
        /// 创建支付宝交易撤消服务
        /// </summary>
        /// <returns>IAlipayCancelService.</returns>
        IAlipayCancelService CreateAlipayCancelService();

        /// <summary>
        /// 创建支付宝条码支付服务
        /// </summary>
        /// <returns>IAlipayBarcodePayService.</returns>
        IAlipayBarcodePayService CreateAlipayBarcodePayService();

        /// <summary>
        /// 创建支付宝二维码支付服务
        /// </summary>
        /// <returns>IAlipayQrCodePayService.</returns>
        IAlipayQrCodePayService CreateAlipayQrCodePayService();

        /// <summary>
        /// 创建支付宝电脑网站支付服务
        /// </summary>
        /// <returns>IAlipayPagePayService.</returns>
        IAlipayPagePayService CreateAlipayPagePayService();

        /// <summary>
        /// 创建支付宝手机网站支付服务
        /// </summary>
        /// <returns>IAlipayWapPayService.</returns>
        IAlipayWapPayService CreateAlipayWapPayService();

        /// <summary>
        /// 创建支付宝App支付服务
        /// </summary>
        /// <returns>IAlipayAppPayService.</returns>
        IAlipayAppPayService CreateAlipayAppPayService();

        /// <summary>
        /// 创建微信回调通知服务
        /// </summary>
        /// <returns>IWechatpayNotifyService.</returns>
        IWechatpayNotifyService CreateWechatpayNotifyService();

        /// <summary>
        /// 创建微信退款服务
        /// </summary>
        /// <returns>IWechatpayRefundService.</returns>
        IWechatpayRefundService CreateWechatpayRefundService();

        /// <summary>
        /// 创建微信关闭订单服务
        /// </summary>
        /// <returns>IWechatpayCloseOrderService.</returns>
        IWechatpayCloseOrderService CreateWechatpayCloseOrderService();

        /// <summary>
        /// 创建微信App支付服务
        /// </summary>
        /// <returns>IWechatpayAppPayService.</returns>
        IWechatpayAppPayService CreateWechatpayAppPayService();

        /// <summary>
        /// 创建微信小程序支付服务
        /// </summary>
        /// <returns>IWechatpayMiniProgramPayService.</returns>
        IWechatpayMiniProgramPayService CreateWechatpayMiniProgramPayService();

        /// <summary>
        /// 创建微信JsApi支付服务
        /// </summary>
        /// <returns>IWechatpayJsApiPayService.</returns>
        IWechatpayJsApiPayService CreateWechatpayJsApiPayService();

        /// <summary>
        /// 创建微信扫码支付服务
        /// </summary>
        /// <returns>IWechatpayNativePayService.</returns>
        IWechatpayNativePayService CreateWechatpayNativePayService();
    }
}