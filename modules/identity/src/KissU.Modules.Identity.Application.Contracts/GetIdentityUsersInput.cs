using Volo.Abp.Application.Dtos;

namespace KissU.Modules.Identity.Application.Contracts
{
    public class GetIdentityUsersInput : PagedAndSortedResultRequestDto
    {
        public string Filter { get; set; }
    }
}
