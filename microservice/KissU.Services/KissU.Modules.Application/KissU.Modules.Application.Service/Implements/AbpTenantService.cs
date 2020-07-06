﻿using System.Threading.Tasks;
using KissU.Extensions;
using KissU.Modules.Application.MultiTenancy;
using KissU.Modules.Application.Service.Contracts;
using KissU.Surging.ProxyGenerator;

namespace KissU.Modules.Application.Service.Implements
{
    public abstract class AbpTenantService : ProxyServiceBase, IAbpTenantService
    {
        private readonly IAbpTenantAppService _appService;

        public AbpTenantService(IAbpTenantAppService appService)
        {
            _appService = appService;
        }

        public Task<FindTenantResultDto> FindTenantByNameAsync(string name)
        {
            return _appService.FindTenantByNameAsync(name);
        }

        public Task<FindTenantResultDto> FindTenantByIdAsync(string id)
        {
            return _appService.FindTenantByIdAsync(id.ToGuid());
        }
    }
}