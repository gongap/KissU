using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Modules.IdentityServer.Domain.UnitOfWorks;
using KissU.Util.Datas.Ef.Core;

namespace KissU.Modules.IdentityServer.Data.Repositories
{
    /// <summary>
    /// 设备流代码仓储
    /// </summary>
    public class DeviceFlowCodeRepository : RepositoryBase<DeviceFlowCode, int>, IDeviceFlowCodeRepository
    {
        /// <summary>
        /// 初始化设备流代码仓储
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        public DeviceFlowCodeRepository(IIdentityServerUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}