﻿using System;
using System.Threading;
using System.Threading.Tasks;

namespace KissU.Core.ServiceHosting.Internal.Implementation
{
    /// <summary>
    /// 服务端用来阻止Host主线程退出，直到按下Ctrl+C
    /// </summary>
    public class ConsoleLifetime : IHostLifetime
    {
        private readonly ManualResetEvent _shutdownBlock = new ManualResetEvent(false);

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="applicationLifetime">应用生命周期</param>
        public ConsoleLifetime(IApplicationLifetime applicationLifetime)
        {
            ApplicationLifetime = applicationLifetime ?? throw new ArgumentNullException(nameof(applicationLifetime));
        }

        private IApplicationLifetime ApplicationLifetime { get; }

        /// <summary>
        /// 等待启动
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        public Task WaitForStartAsync(CancellationToken cancellationToken)
        {
            ApplicationLifetime.ApplicationStarted.Register(() =>
            {
                Console.WriteLine("服务已启动。 按下Ctrl + C关闭。");
            });

            AppDomain.CurrentDomain.ProcessExit += (sender, eventArgs) =>
            {
                ApplicationLifetime.StopApplication();
                //阻止程序主线程自动退出，等待退出信号
                _shutdownBlock.WaitOne();
            };

            //按下Ctrl+C退出程序
            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                _shutdownBlock.Set();
                ApplicationLifetime.StopApplication();
            };
            return Task.CompletedTask;
        }

        /// <summary>
        /// 停止
        /// </summary>
        /// <param name="cancellationToken">取消令牌</param>
        /// <returns><placeholder>A <see cref="Task"/> representing the asynchronous operation.</placeholder></returns>
        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            _shutdownBlock.Set();
        }
    }
}
