using System;

namespace KissU.Modules.Application.Configurations
{
    [Serializable]
    public class CurrentUserDto
    {
        public bool IsAuthenticated { get; set; }

        public Guid? Id { get; set; }

        public Guid? TenantId { get; set; }

        public string UserName { get; set; }

        public string Email { get; set; }
    }
}
