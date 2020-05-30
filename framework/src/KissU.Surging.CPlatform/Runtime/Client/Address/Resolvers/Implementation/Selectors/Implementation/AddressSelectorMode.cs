﻿namespace KissU.Surging.CPlatform.Runtime.Client.Address.Resolvers.Implementation.Selectors.Implementation
{
    /// <summary>
    /// 负载均衡模式
    /// </summary>
    public enum AddressSelectorMode
    {
        /// <summary>
        /// 哈希算法
        /// </summary>
        HashAlgorithm,

        /// <summary>
        /// 轮询
        /// </summary>
        Polling,

        /// <summary>
        /// 随机
        /// </summary>
        Random,

        /// <summary>
        /// 压力最小优先
        /// </summary>
        FairPolling,

        /// <summary>
        /// 权重轮询
        /// </summary>
        RoundRobin
    }
}