using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Caching;
using Volo.Abp.MultiTenancy;
using KissU.ServiceProxy;
using KissU.Msm.Sample.Service.Contracts;
using KissU.Msm.Sample.Service.Contracts.Models;
using Microsoft.Extensions.Logging;

namespace KissU.Msm.Sample.Service.Implements
{
    public class ManagerService : ProxyServiceBase, IManagerService
    {
        private readonly ILogger<ManagerService> _logger;
        private readonly IDistributedCache<List<ClassCacheItem>> _distributedCache;
        private readonly IAuditingStore _auditingStore;
        private readonly ITenantStore _tenantStore;

        public ManagerService(ILogger<ManagerService> logger , IDistributedCache<List<ClassCacheItem>> distributedCache, IAuditingStore auditingStore, ITenantStore tenantStore)
        {
            _logger = logger;
            _distributedCache = distributedCache;
            _auditingStore = auditingStore;
            _tenantStore = tenantStore;
        }

        public async Task<string> SayHelloAsync(string name)
        {
            await  _auditingStore.SaveAsync(new AuditLogInfo{ ApplicationName = name});
            await _tenantStore.FindAsync(name);
            var model1 = new ClassCacheItem { Name =$"model1{RandomHelper.GetRandom()}" };
            var model2 = new ClassCacheItem { Name = $"model2{RandomHelper.GetRandom()}" };
            await _distributedCache.SetAsync("ddd", new List<ClassCacheItem>{model1,model2});
            var result = await _distributedCache.GetAsync("ddd");
            return $"{name} say:hello";
        }

        public Task<int> ReactiveTestAsync(int value)
        { 
            ISubject<int> subject = new ReplaySubject<int>();
            var result = 0;
            var exception = new Exception("");
            subject.Subscribe((temperature) => result = temperature, temperature => exception = temperature, async () => await Write(result, default, exception.Message));
             
            GetGenerateObservable().Subscribe(subject);
            return Task.FromResult<int>(default);
        }

        private static IObservable<int> GetGenerateObservable()
        { 
            return Observable.Return(30, ThreadPoolScheduler.Instance);
        }
    }
}
