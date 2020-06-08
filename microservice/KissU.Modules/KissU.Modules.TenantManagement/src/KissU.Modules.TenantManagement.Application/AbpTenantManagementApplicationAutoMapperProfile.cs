using AutoMapper;
using KissU.Modules.TenantManagement.Application.Contracts;
using KissU.Modules.TenantManagement.Domain;

namespace KissU.Modules.TenantManagement.Application
{
    public class AbpTenantManagementApplicationAutoMapperProfile : Profile
    {
        public AbpTenantManagementApplicationAutoMapperProfile()
        {
            CreateMap<Tenant, TenantDto>()
                .MapExtraProperties();
        }
    }
}