using KissU.Modules.IdentityServer.Application.Contracts.Dtos;
using KissU.Modules.IdentityServer.Application.Contracts.Queries;
using KissU.Util.Ddd.Application.Contracts;

namespace KissU.Modules.IdentityServer.Application.Contracts.Abstractions
{
    /// <summary>
    /// 设备流代码服务
    /// </summary>
    public interface IDeviceFlowCodeAppService : IDeleteService<DeviceFlowCodeDto, DeviceFlowCodeQuery>
    {
    }
}