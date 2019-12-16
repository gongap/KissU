// <copyright file="IEventLogRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;
using KissU.Modules.IdentityServer.Domain.Models.EventLog;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    /// <summary>
    /// 仓储
    /// </summary>
    public interface IEventLogRepository : IRepository<EventLog>
    {
    }
}
