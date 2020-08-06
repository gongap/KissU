using System.Collections.Concurrent;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using Microsoft.CodeAnalysis.Scripting;

namespace KissU.CPlatform.Support.Implementation
{
    /// <summary>
    /// 服务命令基类.
    /// Implements the <see cref="IServiceCommandProvider" />
    /// </summary>
    /// <seealso cref="IServiceCommandProvider" />
    public abstract class ServiceCommandBase : IServiceCommandProvider
    {
        private readonly ConcurrentDictionary<string, object> scripts = new ConcurrentDictionary<string, object>();

        /// <summary>
        /// 获取命令
        /// </summary>
        /// <param name="serviceId">The service identifier.</param>
        /// <returns>ValueTask&lt;ServiceCommand&gt;.</returns>
        public abstract ValueTask<ServiceCommand> GetCommand(string serviceId);

        /// <summary>
        /// 运行.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <param name="InjectionNamespaces">The injection namespaces.</param>
        /// <returns>Task&lt;System.Object&gt;.</returns>
        public async Task<object> Run(string text, params string[] InjectionNamespaces)
        {
            object result = scripts;
            var scriptOptions = ScriptOptions.Default.WithImports("System.Threading.Tasks");
            if (InjectionNamespaces != null)
            {
                foreach (var injectionNamespace in InjectionNamespaces)
                {
                    scriptOptions = scriptOptions.WithReferences(injectionNamespace);
                }
            }

            if (!scripts.ContainsKey(text))
            {
                result = scripts.GetOrAdd(text, await CSharpScript.EvaluateAsync(text, scriptOptions));
            }
            else
            {
                scripts.TryGetValue(text, out result);
            }

            return result;
        }
    }
}