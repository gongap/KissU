using System;

namespace KissU.Util.Dependency
{
    /// <summary>
    /// 作用域
    /// </summary>
    public interface IScope : IDisposable
    {
        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T">实例类型</typeparam>
        /// <returns>T.</returns>
        T Create<T>();

        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="type">对象类型</param>
        /// <returns>System.Object.</returns>
        object Create(Type type);
    }
}
