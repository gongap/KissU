using KissU.Modules.IdentityServer.Application.Dtos;
using KissU.Modules.IdentityServer.Application.Queries;
using KissU.Util.Applications;

namespace KissU.Modules.IdentityServer.Application.Abstractions
{
    /// <summary>
    /// 设备流代码服务
    /// </summary>
    public interface IDeviceFlowCodeAppService : IDeleteService<DeviceFlowCodeDto, DeviceFlowCodeQuery>
    {
    }
}