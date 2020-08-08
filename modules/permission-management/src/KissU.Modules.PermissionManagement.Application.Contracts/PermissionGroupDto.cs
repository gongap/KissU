using System.Collections.Generic;

namespace KissU.Modules.PermissionManagement.Application.Contracts
{
    public class PermissionGroupDto
    {
        public string Name { get; set; }

        public string DisplayName { get; set; }

        public List<PermissionGrantInfoDto> Permissions { get; set; }
    }
}