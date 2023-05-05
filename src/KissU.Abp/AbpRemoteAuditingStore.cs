using Volo.Abp.Auditing;
using Volo.Abp.DependencyInjection;
using KissU.CPlatform.Routing;
using KissU.Dependency;
using KissU.ServiceProxy;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KissU.Abp
{
    [Dependency(ServiceLifetime.Transient, ReplaceServices = true)]
    [ExposeServices(typeof(IAuditingStore))]
    public class AbpRemoteAuditingStore : SimpleLogAuditingStore, IAuditingStore
    {
        private readonly ILogger<AbpRemoteAuditingStore> _logger;
        private readonly CPlatformContainer _cPlatformContainer;
        private readonly IServiceRouteProvider _serviceRouteProvider;

        public AbpRemoteAuditingStore(ILogger<AbpRemoteAuditingStore> logger, 
            CPlatformContainer cPlatformContainer,
            IServiceRouteProvider serviceRouteProvider)
        {
            _logger = logger;
            _cPlatformContainer = cPlatformContainer;
            _serviceRouteProvider = serviceRouteProvider;
        }

        public new async Task SaveAsync(AuditLogInfo auditInfo)
        {
            Logger.LogInformation(auditInfo.ToString());
            if (IsLocalExecute(out var auditingStore))
            {
                if (auditingStore != null)
                {
                    await auditingStore.SaveAsync(auditInfo);
                }

                return;
            }

            try
            {
                var routePath = $"{AppConfig.Options.AuditingRoutePath}/save";
                var serviceRoute = await _serviceRouteProvider.GetRouteByPath(routePath.ToLower());
                if (serviceRoute != null)
                {
                    var parameters = new Dictionary<string, object> {{"auditInfo", auditInfo}};
                    await ServiceLocator.GetService<IServiceProxyProvider>().Invoke<object>(parameters, routePath);
                    return;
                }
            }
            catch (Exception e)
            {
                _logger.LogWarning(e.Message);
            }

            await base.SaveAsync(auditInfo);
        }
        
        private bool IsLocalExecute(out IAuditingStore auditingStore)
        {
            var tenantStores = _cPlatformContainer.GetInstances<IEnumerable<IAuditingStore>>();
            auditingStore = tenantStores?.FirstOrDefault(x => !(x is AbpRemoteAuditingStore || x is SimpleLogAuditingStore));
            if (AppConfig.Options.IsEnabledRemoteAuditingStore && auditingStore == null)
            {
                return false;
            }

            return true;
        }
    }
}
