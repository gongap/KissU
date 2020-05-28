using Volo.Abp.Application.Dtos;

namespace KissU.Modules.TenantManagement
{
    public class GetTenantsInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}