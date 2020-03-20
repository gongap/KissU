﻿namespace KissU.Util.Contexts
{
    /// <summary>
    /// 空上下文
    /// </summary>
    public class NullContext : IContext
    {
        /// <summary>
        /// 空上下文实例
        /// </summary>
        public static readonly NullContext Instance = new NullContext();

        /// <summary>
        /// 跟踪号
        /// </summary>
        public string TraceId => string.Empty;

        /// <summary>
        /// 添加对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        /// <param name="value">对象</param>
        public void Add<T>(string key, T value)
        {
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="key">键名</param>
        /// <returns>T.</returns>
        public T Get<T>(string key)
        {
            return default;
        }

        /// <summary>
        /// 移除对象
        /// </summary>
        /// <param name="key">键名</param>
        public void Remove(string key)
        {
        }
    }
}