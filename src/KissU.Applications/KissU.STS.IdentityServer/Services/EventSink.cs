using System;
using System.Threading.Tasks;
using IdentityServer4.Events;
using IdentityServer4.Services;
using Microsoft.Extensions.Logging;
using KissU.Modules.IdentityServer.Data.UnitOfWorks;
using KissU.Modules.IdentityServer.Domain.Models.EventLog;
using KissU.Modules.IdentityServer.Domain.Repositories;
using KissU.Util.Helpers;
using KissU.Util.Logs;
using KissU.Util.Maps;

namespace KFNets.Microservices.IdentityServer.Services
{
    public class EventSink : DefaultEventSink, IEventSink
    {
        public EventSink(IIdentityServerUnitOfWork unitOfWork, IEventLogRepository eventLogRepository,ILog log, ILogger<DefaultEventService> logger) : base(logger)
        {
            UnitOfWork = unitOfWork;
            EventLogRepository = eventLogRepository;
            Log = log;
        }

        public IIdentityServerUnitOfWork UnitOfWork { get; }
        public IEventLogRepository EventLogRepository { get; }
        public ILog Log { get; }
        public ILogger<DefaultEventService> Logger { get; }

        public async Task PersistAsync(Event evt)
        {
            await base.PersistAsync(evt);
            try
            {
                var eventLog = evt.MapTo<EventLog>();
                eventLog.Init();
                eventLog.EventId = evt.Id;
                eventLog.Host = Web.Host;
                eventLog.Url = Web.Url;
                eventLog.Browser = Web.Browser;
                eventLog.TimeStamp = eventLog.TimeStamp.ToLocalTime();
                await EventLogRepository.AddAsync(eventLog);
                await UnitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                Log.Error(ex.Message);
            }
        }
    }
}