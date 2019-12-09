// <copyright file="EventLogService.cs" company="KissU">
// Copyright (c) KissU. All Rights Reserved.
// </copyright>

namespace KissU.Modules.IdentityServer.Service.Implements
{
    using KissU.Modules.IdentityServer.Data.UnitOfWorks;
    using KissU.Modules.IdentityServer.Domain.Models.EventLog;
    using KissU.Modules.IdentityServer.Domain.Repositories;
    using KissU.Modules.IdentityServer.Service.Contracts.Abstractions;
    using KissU.Modules.IdentityServer.Service.Contracts.Dtos;
    using KissU.Modules.IdentityServer.Service.Contracts.Queries;
    using Util.Applications;
    using Util.Datas.Queries;
    using Util.Domains.Repositories;

    /// <summary>
    ///     授权日志服务
    /// </summary>
    public class EventLogService : CrudServiceBase<EventLog, EventLogDto, EventLogQuery>, IEventLogService
    {
        /// <summary>
        ///     初始化认证操作数据服务
        /// </summary>
        /// <param name="unitOfWork">工作单元</param>
        /// <param name="eventLogRepository">授权日志仓储</param>
        public EventLogService(IIdentityServerUnitOfWork unitOfWork, IEventLogRepository eventLogRepository)
            : base(unitOfWork, eventLogRepository)
        {
            EventLogRepository = eventLogRepository;
            UnitOfWork = unitOfWork;
        }

        /// <summary>
        ///     认证操作数据仓储
        /// </summary>
        public IEventLogRepository EventLogRepository { get; set; }

        /// <summary>
        ///     工作单元
        /// </summary>
        public IIdentityServerUnitOfWork UnitOfWork { get; set; }

        /// <summary>
        ///     创建查询对象
        /// </summary>
        /// <param name="param">认证操作数据查询实体</param>
        protected override IQueryBase<EventLog> CreateQuery(EventLogQuery param)
        {
            var query = new Query<EventLog>(param);

            if (string.IsNullOrWhiteSpace(param.Order))
            {
                query.OrderBy(x => x.TimeStamp, true);
            }

            if (param.EventId.HasValue)
            {
                query.And(x => x.EventId == param.EventId);
            }

            return query;
        }
    }
}
