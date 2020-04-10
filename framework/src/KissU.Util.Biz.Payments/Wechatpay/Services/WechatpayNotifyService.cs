using System.Collections.Generic;
using System.Threading.Tasks;
using KissU.Core;
using KissU.Core.Helpers;
using KissU.Core.Validations;
using KissU.Util.AspNetCore.Helpers;
using KissU.Util.Biz.Payments.Properties;
using KissU.Util.Biz.Payments.Wechatpay.Abstractions;
using KissU.Util.Biz.Payments.Wechatpay.Configs;
using KissU.Util.Biz.Payments.Wechatpay.Results;

namespace KissU.Util.Biz.Payments.Wechatpay.Services
{
    /// <summary>
    /// 微信支付通知服务
    /// </summary>
    public class WechatpayNotifyService : IWechatpayNotifyService
    {
        /// <summary>
        /// 配置提供器
        /// </summary>
        private readonly IWechatpayConfigProvider _configProvider;

        /// <summary>
        /// 是否已加载
        /// </summary>
        private bool _isLoad;

        /// <summary>
        /// 微信支付结果
        /// </summary>
        private WechatpayResult _result;

        /// <summary>
        /// 初始化微信支付通知服务
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        public WechatpayNotifyService(IWechatpayConfigProvider configProvider)
        {
            configProvider.CheckNull(nameof(configProvider));
            _configProvider = configProvider;
            _isLoad = false;
        }

        /// <summary>
        /// 获取参数集合
        /// </summary>
        public IDictionary<string, string> GetParams()
        {
            Init();
            return _result.GetParams();
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        public T GetParam<T>(string name)
        {
            return Convert.To<T>(GetParam(name));
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">参数名</param>
        public string GetParam(string name)
        {
            Init();
            return _result.GetParam(name);
        }

        /// <summary>
        /// 验证
        /// </summary>
        public async Task<ValidationResultCollection> ValidateAsync()
        {
            Init();
            if (Money <= 0)
                return new ValidationResultCollection(PayResource.InvalidMoney);
            return await _result.ValidateAsync();
        }

        /// <summary>
        /// 返回成功消息
        /// </summary>
        public string Success()
        {
            return Return(WechatpayConst.Success, WechatpayConst.Ok);
        }

        /// <summary>
        /// 返回失败消息
        /// </summary>
        public string Fail()
        {
            return Return(WechatpayConst.Fail, WechatpayConst.Fail);
        }

        /// <summary>
        /// 商户订单号
        /// </summary>
        public string OrderId => GetParam(WechatpayConst.OutTradeNo);

        /// <summary>
        /// 支付订单号
        /// </summary>
        public string TradeNo => GetParam(WechatpayConst.TransactionId);

        /// <summary>
        /// 支付金额
        /// </summary>
        public decimal Money => GetParam(WechatpayConst.TotalFee).ToDecimal() / 100M;

        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            if (_isLoad)
                return;
            InitResult();
            _isLoad = true;
        }

        /// <summary>
        /// 初始化支付结果
        /// </summary>
        private void InitResult()
        {
            _result = new WechatpayResult(_configProvider, Web.Body);
        }

        /// <summary>
        /// 返回消息
        /// </summary>
        private string Return(string code, string message)
        {
            var xml = new Xml();
            xml.AddCDataNode(code, WechatpayConst.ReturnCode);
            xml.AddCDataNode(message, WechatpayConst.ReturnMessage);
            return xml.ToString();
        }
    }
}