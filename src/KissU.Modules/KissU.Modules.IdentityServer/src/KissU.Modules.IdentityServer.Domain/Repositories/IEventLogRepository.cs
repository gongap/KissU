// <copyright file="IEventLogRepository.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Domain.Repositories
{
    using KissU.Modules.IdentityServer.Domain.Models.EventLog;
    using Util.Domains.Repositories;

    /// <summary>
    ///     仓储
    /// </summary>
    public interface IEventLogRepository : IRepository<EventLog>
    {
    }
}
