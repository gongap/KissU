using System;
using System.Threading.Tasks;
using KissU.Core.Ioc;
using KissU.Modules.BookStore.Samples;
using KissU.Surging.CPlatform.Runtime.Server.Implementation.ServiceDiscovery.Attributes;

namespace KissU.Modules.BookStore.Service.Contracts
{
    /// <summary>
    /// 样例服务
    /// </summary>
    [ServiceBundle("api/{Service}")]
    public interface ISampleService : IServiceKey
    {
        /// <summary>
        /// 获取
        /// </summary>
        Task<SampleDto> GetAsync();
    }
}