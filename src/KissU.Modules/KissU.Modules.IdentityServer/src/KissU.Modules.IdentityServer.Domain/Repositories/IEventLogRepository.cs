// <copyright file="IEventLogRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

using KissU.Util.Domains.Repositories;

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    using KissU.Modules.IdentityServer.Domain.Models.EventLog;

    /// <summary>
    /// 仓储
    /// </summary>
    public interface IEventLogRepository : IRepository<EventLog>
    {
    }
}
