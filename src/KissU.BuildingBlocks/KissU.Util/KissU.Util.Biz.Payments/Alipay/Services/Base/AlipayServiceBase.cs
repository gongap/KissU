﻿using System.Threading.Tasks;
using KissU.Util.AspNetCore.Helpers;
using KissU.Util.Biz.Payments.Alipay.Configs;
using KissU.Util.Biz.Payments.Alipay.Parameters;
using KissU.Util.Biz.Payments.Alipay.Results;
using KissU.Util.Logs;
using KissU.Util.Validations;

namespace KissU.Util.Biz.Payments.Alipay.Services.Base
{
    /// <summary>
    /// 支付宝服务
    /// </summary>
    /// <typeparam name="TRequest">请求参数类型</typeparam>
    public abstract class AlipayServiceBase<TRequest> where TRequest : IValidation
    {
        /// <summary>
        /// 配置提供器
        /// </summary>
        protected readonly IAlipayConfigProvider ConfigProvider;

        /// <summary>
        /// 初始化支付宝服务
        /// </summary>
        /// <param name="provider">支付宝配置提供器</param>
        protected AlipayServiceBase(IAlipayConfigProvider provider)
        {
            provider.CheckNull(nameof(provider));
            ConfigProvider = provider;
        }

        /// <summary>
        /// 是否发送请求
        /// </summary>
        public bool IsSend { get; set; } = true;

        /// <summary>
        /// 请求
        /// </summary>
        /// <param name="param">请求参数</param>
        /// <returns>Task&lt;AlipayResult&gt;.</returns>
        protected async Task<AlipayResult> Request(TRequest param)
        {
            var config = await ConfigProvider.GetConfigAsync();
            Validate(config, param);
            var builder = new AlipayParameterBuilder(config);
            ConfigBuilder(builder, param);
            return await RequstResult(config, builder);
        }

        /// <summary>
        /// 验证
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="param">The parameter.</param>
        protected void Validate(AlipayConfig config, TRequest param)
        {
            config.CheckNull(nameof(config));
            param.CheckNull(nameof(param));
            config.Validate();
            param.Validate();
            ValidateParam(param);
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="param">请求参数</param>
        protected virtual void ValidateParam(TRequest param)
        {
        }

        /// <summary>
        /// 配置参数生成器
        /// </summary>
        /// <param name="builder">支付宝参数生成器</param>
        /// <param name="param">请求参数</param>
        protected void ConfigBuilder(AlipayParameterBuilder builder, TRequest param)
        {
            builder.Init();
            builder.Method(GetMethod());
            InitBuilder(builder, param);
            InitContentBuilder(builder.Content, param);
        }

        /// <summary>
        /// 获取请求方法
        /// </summary>
        /// <returns>System.String.</returns>
        protected abstract string GetMethod();

        /// <summary>
        /// 初始化参数生成器
        /// </summary>
        /// <param name="builder">支付宝参数生成器</param>
        /// <param name="param">请求参数</param>
        protected virtual void InitBuilder(AlipayParameterBuilder builder, TRequest param)
        {
        }

        /// <summary>
        /// 初始化内容生成器
        /// </summary>
        /// <param name="builder">内容参数生成器</param>
        /// <param name="param">请求参数</param>
        protected virtual void InitContentBuilder(AlipayContentBuilder builder, TRequest param)
        {
        }

        /// <summary>
        /// 请求结果
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>Task&lt;AlipayResult&gt;.</returns>
        protected virtual async Task<AlipayResult> RequstResult(AlipayConfig config, AlipayParameterBuilder builder)
        {
            var response = await SendRequest(config, builder);
            var result = new AlipayResult(response, builder);
            WriteLog(config, builder, result);
            return result;
        }

        /// <summary>
        /// 发送请求
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="builder">The builder.</param>
        /// <returns>Task&lt;System.String&gt;.</returns>
        protected virtual async Task<string> SendRequest(AlipayConfig config, AlipayParameterBuilder builder)
        {
            if (IsSend == false)
                return string.Empty;
            return await Web.Client()
                .Post(config.GetGatewayUrl())
                .Data(builder.GetDictionary())
                .ResultAsync();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="result">The result.</param>
        protected void WriteLog(AlipayConfig config, AlipayParameterBuilder builder, AlipayResult result)
        {
            var log = GetLog();
            if (log.IsTraceEnabled == false)
                return;
            log.Class(GetType().FullName)
                .Caption("支付宝支付")
                .Content($"请求方法 : {GetMethod()}")
                .Content($"支付网关 : {config.GetGatewayUrl()}")
                .Content("请求参数:")
                .Content(builder.GetDictionary())
                .Content()
                .Content("返回结果:")
                .Content(result.GetDictionary())
                .Content()
                .Content("原始请求:")
                .Content(builder.ToString())
                .Content()
                .Content("原始响应: ")
                .Content(result.Raw)
                .Trace();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <param name="builder">The builder.</param>
        /// <param name="content">The content.</param>
        protected void WriteLog(AlipayConfig config, AlipayParameterBuilder builder, string content)
        {
            var log = GetLog();
            if (log.IsTraceEnabled == false)
                return;
            log.Class(GetType().FullName)
                .Caption("支付宝支付")
                .Content($"请求方法 : {GetMethod()}")
                .Content($"支付网关 : {config.GetGatewayUrl()}")
                .Content("请求参数:")
                .Content(builder.GetDictionary())
                .Content()
                .Content("原始请求:")
                .Content(builder.ToString())
                .Content()
                .Content("内容: ")
                .Content(content)
                .Trace();
        }

        /// <summary>
        /// 获取日志操作
        /// </summary>
        private ILog GetLog()
        {
            try
            {
                return Log.GetLog(AlipayConst.TraceLogName);
            }
            catch
            {
                return Log.Null;
            }
        }
    }
}