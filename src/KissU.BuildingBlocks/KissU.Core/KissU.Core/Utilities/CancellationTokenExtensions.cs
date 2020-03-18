using System;
using System.Threading;
using System.Threading.Tasks;

namespace KissU.Surging.CPlatform.Utilities
{
    /// <summary>
    /// 取消令牌扩展.
    /// </summary>
    public static class CancellationTokenExtensions
    {
        /// <summary>
        /// Whens the canceled.
        /// </summary>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task.</returns>
        public static Task WhenCanceled(this CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            cancellationToken.Register(s => ((TaskCompletionSource<bool>) s).SetResult(true), tcs);
            return tcs.Task;
        }

        /// <summary>
        /// Withes the cancellation.
        /// </summary>
        /// <typeparam name="T">The result type</typeparam>
        /// <param name="task">The task.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <exception cref="TimeoutException"></exception>
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationToken cancellationToken)
        {
            var tcs = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(s => ((TaskCompletionSource<bool>) s).TrySetResult(true), tcs))
            {
                if (task != await Task.WhenAny(task, tcs.Task))
                {
                    throw new TimeoutException();
                }
            }

            return await task;
        }

        /// <summary>
        /// Withes the cancellation.
        /// </summary>
        /// <typeparam name="T">The result type</typeparam>
        /// <param name="task">The task.</param>
        /// <param name="cts">The CTS.</param>
        /// <param name="requestTimeout">The request timeout.</param>
        /// <returns>Task&lt;T&gt;.</returns>
        /// <exception cref="TimeoutException"></exception>
        public static async Task<T> WithCancellation<T>(this Task<T> task, CancellationTokenSource cts,
            int requestTimeout)
        {
            if (task == await Task.WhenAny(task, Task.Delay(requestTimeout, cts.Token)))
            {
                cts.Cancel();
                return await task;
            }

            throw new TimeoutException();
        }
    }
}