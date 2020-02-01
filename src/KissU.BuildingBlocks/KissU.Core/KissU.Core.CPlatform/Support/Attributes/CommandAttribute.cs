using System;
using KissU.Core.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation;

namespace KissU.Core.CPlatform.Support.Attributes
{

    /// <summary>
    /// 命令属性.
    /// Implements the <see cref="Attribute" />
    /// </summary>
    /// <seealso cref="Attribute" />
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true, Inherited = false)]
    public class CommandAttribute : Attribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandAttribute"/> class.
        /// </summary>
        public CommandAttribute()
        {
            if (AppConfig.ServerOptions != null)
            {
                FailoverCluster = AppConfig.ServerOptions.FailoverCluster;
                CircuitBreakerForceOpen = AppConfig.ServerOptions.CircuitBreakerForceOpen;
                Strategy = AppConfig.ServerOptions.Strategy;
                ExecutionTimeoutInMilliseconds = AppConfig.ServerOptions.ExecutionTimeoutInMilliseconds;
                RequestCacheEnabled = AppConfig.ServerOptions.RequestCacheEnabled;
                Injection = AppConfig.ServerOptions.Injection;
                InjectionNamespaces = AppConfig.ServerOptions.InjectionNamespaces;
                BreakeErrorThresholdPercentage = AppConfig.ServerOptions.BreakeErrorThresholdPercentage;
                BreakeSleepWindowInMilliseconds = AppConfig.ServerOptions.BreakeSleepWindowInMilliseconds;
                BreakerForceClosed = AppConfig.ServerOptions.BreakerForceClosed;
                BreakerRequestVolumeThreshold = AppConfig.ServerOptions.BreakerRequestVolumeThreshold;
                MaxConcurrentRequests = AppConfig.ServerOptions.MaxConcurrentRequests;
                FallBackName = AppConfig.ServerOptions.FallBackName;
            }
        }

        /// <summary>
        /// 故障转移次数
        /// </summary>
        public int FailoverCluster { get; set; } = 3;

        /// <summary>
        /// 是否强制断开断路器.
        /// </summary>
        public bool CircuitBreakerForceOpen { get; set; }

        /// <summary>
        /// 容错策略
        /// </summary>
        public StrategyType Strategy { get; set; }

        /// <summary>
        /// 执行超时时间
        /// </summary>
        public int ExecutionTimeoutInMilliseconds { get; set; } = 1000;

        /// <summary>
        /// 是否开启缓存
        /// </summary>
        public bool RequestCacheEnabled { get; set; }

        /// <summary>
        /// 注入
        /// </summary>
        public string Injection { get; set; } = "return null";

        /// <summary>
        /// 注入命名空间
        /// </summary>
        public string[] InjectionNamespaces { get; set; }

        /// <summary>
        /// 错误率达到多少开启熔断保护
        /// </summary>
        public int BreakeErrorThresholdPercentage { get; set; } = 50;

        /// <summary>
        /// 熔断多少秒后去尝试请求
        /// </summary>
        public int BreakeSleepWindowInMilliseconds { get; set; } = 60000;

        /// <summary>
        /// 是否强制关闭熔断
        /// </summary>
        public bool BreakerForceClosed { get; set; }

        /// <summary>
        /// 负载分流策略
        /// </summary>
        public AddressSelectorMode ShuntStrategy { get; set; } = AddressSelectorMode.Polling;

        /// <summary>
        /// IFallbackInvoker 实例名称
        /// </summary>
        public string FallBackName { get; set; }

        /// <summary>
        /// 断路器请求量阈值.
        /// </summary>
        public int BreakerRequestVolumeThreshold { get; set; } = 20;

        /// <summary>
        /// 信号量最大并发度
        /// </summary>
        public int MaxConcurrentRequests { get; set; } = 10;
    }
}