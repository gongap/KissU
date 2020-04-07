using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Ddd.Domain.Datas.Repositories;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 设备流代码仓储
    /// </summary>
    public interface IDeviceFlowCodeRepository : IRepository<DeviceFlowCode, int>
    {
    }
}