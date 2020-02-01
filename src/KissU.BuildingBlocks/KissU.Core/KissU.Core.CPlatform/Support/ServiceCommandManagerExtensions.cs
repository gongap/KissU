using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissU.Core.CPlatform.Support
{
    /// <summary>
    /// 服务命令管理者扩展方法。
    /// </summary>
    public static class ServiceCommandManagerExtensions
    {
        /// <summary>
        /// get service commands as an asynchronous operation.
        /// </summary>
        /// <param name="serviceCommandManager">The service command manager.</param>
        /// <param name="serviceIds">The service ids.</param>
        /// <returns>Task&lt;IEnumerable&lt;ServiceCommandDescriptor&gt;&gt;.</returns>
        public static async Task<IEnumerable<ServiceCommandDescriptor>> GetServiceCommandsAsync(this IServiceCommandManager serviceCommandManager, params string[] serviceIds)
        {
            var result = await serviceCommandManager.GetServiceCommandsAsync();
            return result.Where(p => serviceIds.Contains(p.ServiceId));
        }
    }
}