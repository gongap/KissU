using KissU.Core.Domains.Repositories;
using KissU.Modules.IdentityServer.Domain.Models;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 设备流代码仓储
    /// </summary>
    public interface IDeviceFlowCodeRepository : IRepository<DeviceFlowCode, int>
    {
    }
}