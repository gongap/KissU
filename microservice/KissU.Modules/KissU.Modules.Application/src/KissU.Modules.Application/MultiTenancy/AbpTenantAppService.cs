﻿using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp.MultiTenancy;

namespace KissU.Modules.Application.MultiTenancy
{
    public class AbpTenantAppService : ApplicationService, IAbpTenantAppService
    {
        protected ITenantStore TenantStore { get; }

        public AbpTenantAppService(ITenantStore tenantStore)
        {
            TenantStore = tenantStore;
        }

        public async Task<FindTenantResultDto> FindTenantByNameAsync(string name)
        {
            var tenant = await TenantStore.FindAsync(name);

            if (tenant == null)
            {
                return new FindTenantResultDto { Success = false };
            }

            return new FindTenantResultDto
            {
                Success = true,
                TenantId = tenant.Id,
                Name = tenant.Name
            };
        }
        
        public async Task<FindTenantResultDto> FindTenantByIdAsync(Guid id)
        {
            var tenant = await TenantStore.FindAsync(id);

            if (tenant == null)
            {
                return new FindTenantResultDto { Success = false };
            }

            return new FindTenantResultDto
            {
                Success = true,
                TenantId = tenant.Id,
                Name = tenant.Name
            };
        }
    }
}