using System;

namespace KissU.Modules.TenantManagement.Domain.Shared
{
    [Serializable]
    public class TenantEto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
