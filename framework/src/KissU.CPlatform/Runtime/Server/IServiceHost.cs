﻿using System;
using System.Net;
using System.Threading.Tasks;

namespace KissU.CPlatform.Runtime.Server
{
    /// <summary>
    /// 一个抽象的服务主机。
    /// </summary>
    public interface IServiceHost : IDisposable
    {
        /// <summary>
        /// 启动主机。
        /// </summary>
        /// <param name="endPoint">主机终结点。</param>
        /// <returns>一个任务。</returns>
        Task StartAsync(EndPoint endPoint);

        /// <summary>
        /// 启动主机。
        /// </summary>
        /// <param name="ip">The ip.</param>
        /// <param name="port">The port.</param>
        /// <returns>Task.</returns>
        Task StartAsync(string ip, int port);
    }
}