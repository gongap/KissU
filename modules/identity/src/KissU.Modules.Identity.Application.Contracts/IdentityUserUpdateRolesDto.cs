using System.ComponentModel.DataAnnotations;

namespace KissU.Modules.Identity.Application.Contracts
{
    public class IdentityUserUpdateRolesDto
    {
        [Required]
        public string[] RoleNames { get; set; }
    }
}