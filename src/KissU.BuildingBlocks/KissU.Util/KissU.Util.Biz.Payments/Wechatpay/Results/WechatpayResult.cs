using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KissU.Util.Biz.Payments.Wechatpay.Configs;
using KissU.Util.Biz.Payments.Wechatpay.Parameters;
using KissU.Util.Biz.Payments.Wechatpay.Signatures;
using KissU.Util.Helpers;
using KissU.Util.Logs;
using KissU.Util.Parameters;
using KissU.Util.Validations;

namespace KissU.Util.Biz.Payments.Wechatpay.Results
{
    /// <summary>
    /// 微信支付结果
    /// </summary>
    public class WechatpayResult
    {
        /// <summary>
        /// 响应结果
        /// </summary>
        private readonly ParameterBuilder _builder;

        /// <summary>
        /// 签名
        /// </summary>
        private string _sign;

        /// <summary>
        /// 初始化微信支付结果
        /// </summary>
        /// <param name="configProvider">配置提供器</param>
        /// <param name="response">xml响应消息</param>
        /// <param name="config">配置</param>
        /// <param name="parameterBuilder">参数生成器</param>
        public WechatpayResult(IWechatpayConfigProvider configProvider, string response, WechatpayConfig config = null,
            WechatpayParameterBuilder parameterBuilder = null)
        {
            configProvider.CheckNull(nameof(configProvider));
            ConfigProvider = configProvider;
            Raw = response;
            Config = config;
            Builder = parameterBuilder;
            _builder = new ParameterBuilder();
            Resolve(response);
        }

        /// <summary>
        /// 微信支付原始响应
        /// </summary>
        public string Raw { get; }

        /// <summary>
        /// 配置提供器
        /// </summary>
        public IWechatpayConfigProvider ConfigProvider { get; }

        /// <summary>
        /// 配置
        /// </summary>
        public WechatpayConfig Config { get; }

        /// <summary>
        /// 参数生成器
        /// </summary>
        public WechatpayParameterBuilder Builder { get; }

        /// <summary>
        /// 解析响应
        /// </summary>
        private void Resolve(string response)
        {
            if (response.IsEmpty())
                return;
            var elements = Xml.ToElements(response);
            elements.ForEach(node =>
            {
                if (node.Name == WechatpayConst.Sign)
                {
                    _sign = node.Value;
                    return;
                }

                _builder.Add(node.Name.LocalName, node.Value);
            });
            WriteLog();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        protected virtual void WriteLog()
        {
            var log = GetLog();
            if (log.IsTraceEnabled == false)
                return;
            log.Class(GetType().FullName)
                .Caption("微信支付返回结果")
                .Content("参数:")
                .Content(GetParams())
                .Content()
                .Content("原始响应:")
                .Content(Raw)
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        /// <returns>ILog.</returns>
        protected ILog GetLog()
        {
            try
            {
                return Log.GetLog(WechatpayConst.TraceLogName);
            }
            catch
            {
                return Log.Null;
            }
        }

        /// <summary>
        /// 获取参数
        /// </summary>
        /// <param name="name">xml节点名称</param>
        /// <returns>System.String.</returns>
        public string GetParam(string name)
        {
            return _builder.GetValue(name).SafeString();
        }

        /// <summary>
        /// 获取返回状态码
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetReturnCode()
        {
            return GetParam(WechatpayConst.ReturnCode);
        }

        /// <summary>
        /// 获取业务结果代码
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetResultCode()
        {
            return GetParam(WechatpayConst.ResultCode);
        }

        /// <summary>
        /// 获取返回消息
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetReturnMessage()
        {
            return GetParam(WechatpayConst.ReturnMessage);
        }

        /// <summary>
        /// 获取应用标识
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetAppId()
        {
            return GetParam(WechatpayConst.AppId);
        }

        /// <summary>
        /// 获取商户号
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetMerchantId()
        {
            return GetParam(WechatpayConst.MerchantId);
        }

        /// <summary>
        /// 获取随机字符串
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetNonce()
        {
            return GetParam("nonce_str");
        }

        /// <summary>
        /// 获取预支付标识
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetPrepayId()
        {
            return GetParam("prepay_id");
        }

        /// <summary>
        /// 获取微信退款单号
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetRefundId()
        {
            return GetParam("refund_id");
        }

        /// <summary>
        /// 获取交易类型
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetTradeType()
        {
            return GetParam(WechatpayConst.TradeType);
        }

        /// <summary>
        /// 获取错误码
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetErrorCode()
        {
            return GetParam(WechatpayConst.ErrorCode);
        }

        /// <summary>
        /// 获取错误码和描述
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetErrorCodeDescription()
        {
            return GetParam(WechatpayConst.ErrorCodeDescription);
        }

        /// <summary>
        /// 获取签名
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetSign()
        {
            return _sign;
        }

        /// <summary>
        /// 获取参数列表
        /// </summary>
        /// <returns>IDictionary&lt;System.String, System.String&gt;.</returns>
        public IDictionary<string, string> GetParams()
        {
            var builder = new ParameterBuilder(_builder);
            builder.Add(WechatpayConst.Sign, _sign);
            return builder.GetDictionary().ToDictionary(t => t.Key, t => t.Value.SafeString());
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <returns>Task&lt;ValidationResultCollection&gt;.</returns>
        public async Task<ValidationResultCollection> ValidateAsync()
        {
            if (GetReturnCode() != WechatpayConst.Success || GetResultCode() != WechatpayConst.Success)
                return new ValidationResultCollection(GetErrorCodeDescription());
            var isValid = await VerifySign();
            if (isValid == false)
                return new ValidationResultCollection("签名失败");
            return ValidationResultCollection.Success;
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <returns>Task&lt;System.Boolean&gt;.</returns>
        public async Task<bool> VerifySign()
        {
            var config = await ConfigProvider.GetConfigAsync(_builder);
            return SignManagerFactory.Create(config, _builder).Verify(GetSign());
        }
    }
}