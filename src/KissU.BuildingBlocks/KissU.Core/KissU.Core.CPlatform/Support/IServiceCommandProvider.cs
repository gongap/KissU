using System.Threading.Tasks;

namespace KissU.Core.CPlatform.Support
{
    /// <summary>
    /// 服务命令提供者
    /// </summary>
    public interface IServiceCommandProvider
    {
        /// <summary>
        /// 获取命令
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>ValueTask&lt;ServiceCommand&gt;.</returns>
        ValueTask<ServiceCommand> GetCommand(string serviceId);

        /// <summary>
        /// 运行.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="InjectionNamespaces">The injection namespaces.</param>
        /// <returns>Task&lt;System.Object&gt;.</returns>
        Task<object> Run(string text, params string[] InjectionNamespaces);
    }
}