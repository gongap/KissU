using Volo.Abp.Application.Dtos;

namespace KissU.Modules.TenantManagement.Application.Contracts
{
    public class GetTenantsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}