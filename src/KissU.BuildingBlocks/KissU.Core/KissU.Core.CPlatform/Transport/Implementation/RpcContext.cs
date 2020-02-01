using System;
using System.Collections.Concurrent;
using System.Runtime.CompilerServices;
using System.Threading;

namespace KissU.Core.CPlatform.Transport.Implementation
{
    /// <summary>
    /// Rpc上下文.
    /// </summary>
    public class RpcContext
    {
        private ConcurrentDictionary<string, object> contextParameters;

        /// <summary>
        ///获取上下文参数.
        /// </summary>
        /// <returns>ConcurrentDictionary&lt;String, Object&gt;.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public ConcurrentDictionary<string, object> GetContextParameters()
        {
            return contextParameters;
        }

        /// <summary>
        /// 设置附件.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetAttachment(string key, object value)
        {
            contextParameters.AddOrUpdate(key, value, (k, v) => value);
        }

        /// <summary>
        /// 获取附件.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns>System.Object.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public object GetAttachment(string key)
        {
            contextParameters.TryGetValue(key, out object result);
            return result;
        }

        /// <summary>
        /// 设置上下文参数.
        /// </summary>
        /// <param name="contextParameters">The context parameters.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public void SetContextParameters(ConcurrentDictionary<string, object> contextParameters)
        {
            this.contextParameters = contextParameters;
        }

        private static AsyncLocal<RpcContext> rpcContextThreadLocal = new AsyncLocal<RpcContext>();

        /// <summary>
        /// 获取上下文.
        /// </summary>
        /// <returns>RpcContext.</returns>
        public static RpcContext GetContext()
        {
            var context = rpcContextThreadLocal.Value;

            if (context == null)
            {
                context = new RpcContext();
                context.SetContextParameters(new ConcurrentDictionary<string, object>());
                rpcContextThreadLocal.Value = context;
            }

            return rpcContextThreadLocal.Value;
        }

        /// <summary>
        /// 删除上下文.
        /// </summary>
        public static void RemoveContext()
        {
            rpcContextThreadLocal.Value = null;
        }

        private RpcContext()
        {
        }
    }
}