// <copyright file="IPersistedGrantRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Modules.IdentityServer.Domain.Models;
using KissU.Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 设备流代码仓储
    /// </summary>
    public interface IDeviceFlowCodeRepository : IRepository<DeviceFlowCode, int>
    {
    }
}
